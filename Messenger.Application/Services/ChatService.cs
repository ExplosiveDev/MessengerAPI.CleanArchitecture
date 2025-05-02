
using Messenger.Core.Abstractions;
using Messenger.Core.Models;
using Messenger.DataAccess.Entities;
using Messenger.DataAccess.Repositories;

namespace Messenger.Application.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IUserRepository _userRepository;
        public ChatService(IChatRepository chatRepository, IUserRepository userRepository)
        {
            _chatRepository = chatRepository;
            _userRepository = userRepository;
        }

        public async Task<SearchedChats> GetSavedChats(string userId)
        {
            Guid userGuid = Guid.Parse(userId);

            var chatIds = await _chatRepository.GetUserChatIds(userGuid);

            var savedChats = new SearchedChats
            {

                PrivateChats = [],
                GroupChats = []
            };

            foreach (var chatId in chatIds)
            {
                var chat = await _chatRepository.Get(chatId);
                if (chat is PrivateChat privateChat)
                    savedChats.PrivateChats.Add(chat as PrivateChat);

                if (chat is GroupChat groupChat)
                    savedChats.GroupChats.Add(chat as GroupChat);
            }

            var userIds = new HashSet<Guid>();

            foreach (var chat in savedChats.PrivateChats)
            {
                userIds.Add(chat.User1Id);
                userIds.Add(chat.User2Id);
            }

            foreach (var groupChat in savedChats.GroupChats)
            {
                var groupUserIds = await _chatRepository.GetChatUserIds(groupChat.Id);
                groupChat.UserChats = groupUserIds.Select(u => new UserChat { UserId = u }).ToList();
                groupUserIds.ForEach((userId) => userIds.Add(userId));
            }

            var users = await _userRepository.GetUsersWithAvatars(userIds.ToList());

            foreach (var chat in savedChats.PrivateChats)
            {
                chat.User1 = users.FirstOrDefault(u => u.Id == chat.User1Id);
                chat.User2 = users.FirstOrDefault(u => u.Id == chat.User2Id);

                var (lastMessage, unreaded) = await _chatRepository.GetLastMessageAndCountOfUnreaded(chat.Id, userGuid);
                chat.TopMessage = lastMessage;
                chat.UnReaded = unreaded;
            }

            foreach (var groupChat in savedChats.GroupChats)
            {
                foreach (var userChat in groupChat.UserChats)
                {
                    userChat.User = users.FirstOrDefault(u => u.Id == userChat.UserId);
                }

                var (lastMessage, unreaded) = await _chatRepository.GetLastMessageAndCountOfUnreaded(groupChat.Id, userGuid);
                groupChat.TopMessage = lastMessage;
                groupChat.UnReaded = unreaded;
            }

            return savedChats;
        }

        public async Task<SearchedChats> GetGlobalChatsByName(string requesterUserId, string userName)
        {
            Guid requesterUserGuid = Guid.Parse(requesterUserId);
            var requesterUser = await _userRepository.GetUserWithAvatar(requesterUserGuid);
            var users = await _userRepository.GetUsersByNameWithAvatar(userName);
            users.RemoveAll(u => u.Id == requesterUserGuid);

            List<PrivateChat> privateChats = [];
            foreach (var user in users)
            {
                PrivateChat privateChat = new PrivateChat()
                {
                    Id = Guid.NewGuid(),
                    User1Id = user.Id,
                    User1 = user,
                    User2Id = requesterUser.Id,
                    User2 = requesterUser,
                };
                privateChats.Add(privateChat);
            }

            SearchedChats searchedChats = new SearchedChats()
            {
                PrivateChats = privateChats,
                GroupChats = []
            };

            return searchedChats;
        }

        public async Task<PrivateChat> CreatePrivateChat(string user1Id, string user2Id)
        {
            Guid user1Guid = Guid.Parse(user1Id);
            Guid user2Guid = Guid.Parse(user2Id);

            var user1 = await _userRepository.GetUserWithAvatar(user1Guid);
            var user2 = await _userRepository.GetUserWithAvatar(user2Guid);

            if (user1 == null || user2 == null) throw new ArgumentException("User not found.");

            var privateChat = await _chatRepository.CreatePrivateChat(user1Guid, user2Guid);
            privateChat.User1 = user1;
            privateChat.User2 = user2;

            return privateChat;
        }

        public async Task<Chat> GetChat(string chatId, string userId)
        {
            Guid chatGuid = Guid.Parse(chatId);
            Guid userGuid = Guid.Parse(userId);

            var chat = await _chatRepository.Get(chatGuid);
            if (chat is PrivateChat privateChat)
            {
                privateChat.User1 = await _userRepository.GetUserWithAvatar(privateChat.User1Id);
                privateChat.User2 = await _userRepository.GetUserWithAvatar(privateChat.User2Id);
            }

            if (chat is GroupChat groupChat)
            {
                var userIds = await _chatRepository.GetChatUserIds(chatGuid);
                var users = await _userRepository.GetUsersWithAvatars(userIds);
                groupChat.UserChats = users.Select(u => new UserChat { User = u, UserId = u.Id }).ToList();
            }

            var (lastMessage, unreaded) = await _chatRepository.GetLastMessageAndCountOfUnreaded(chat.Id, userGuid);
            chat.TopMessage = lastMessage;
            chat.UnReaded = unreaded;

            return chat;
        }

        public async Task<GroupChat> CreateGroupChat(string ownerId, List<string> userIds, string groupName)
        {
            Guid ownerGuid = Guid.Parse(ownerId);
            var ownerUser = await _userRepository.GetUserWithAvatar(ownerGuid);
            if (ownerUser == null) throw new ArgumentException("Owner user not found.");

            List<Guid> userGuids = userIds.Select(Guid.Parse).ToList();
            var chatMembers = await _userRepository.GetUsersWithAvatars(userGuids);
            if (chatMembers.Count != userIds.Count) throw new ArgumentException("One or more users not found.");

            var groupChat = await _chatRepository.CreateGroupChat(ownerGuid, groupName);
            if (groupChat == null) throw new ArgumentException("Error with creating chat.");

            userGuids.Add(ownerGuid);
            chatMembers.Add(ownerUser);
            await _chatRepository.AddMembers(groupChat.Id, userGuids);

            chatMembers.ForEach(chatMember => groupChat.UserChats.Add(new UserChat { User = chatMember, ChatId = groupChat.Id }));

            return groupChat;
        }

        public async Task<bool> IsChatOwner(string userId, string chatId)
        {
            Guid userGuid = Guid.Parse(userId);
            Guid chatGuid = Guid.Parse(chatId);

            return await _chatRepository.IsChatOwner(userGuid, chatGuid);
        }

        public async Task<Guid> RemoveMember(string memberId, string chatId)
        {
            Guid chatGuid = Guid.Parse(chatId);
            Guid memberGuid = Guid.Parse(memberId);

            return await _chatRepository.RemoveMember(memberGuid, chatGuid);
        }

        public async Task<string> ChangeChatName(string newChatName, string chatId)
        {
            Guid chatGuid = Guid.Parse(chatId);
            return await _chatRepository.ChangeChatName(newChatName, chatGuid);
        }

        public async Task<List<User>> AddMembers(string[] memberIds, string chatId)
        {
            Guid chatGuid = Guid.Parse(chatId);
            List<Guid> userGuids = memberIds.Select(Guid.Parse).ToList();

            var chatMembers = await _userRepository.GetUsersWithAvatars(userGuids);
            if (userGuids.Count != chatMembers.Count) throw new ArgumentException("One or more users not found.");

            await _chatRepository.AddMembers(chatGuid, userGuids);

            return chatMembers;
        }
    }
}
