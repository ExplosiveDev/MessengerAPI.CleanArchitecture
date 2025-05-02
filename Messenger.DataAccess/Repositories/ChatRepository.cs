using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Execution;
using Messenger.Core.Models;
using Messenger.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Messenger.DataAccess.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly MessengerDBcontext _context;
        private readonly IMapper _mapper;
        public ChatRepository(MessengerDBcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GroupChat>> GetGroupChatsByGroupName(string groupName)
        {
            var groupChatsEntity = await _context.Chats
                .OfType<GroupChatEntity>()
                .Include(gc => gc.ActiveIcon)
                .Where(gc => gc.GroupName.Contains(groupName))
                .ToListAsync();

            return _mapper.Map<List<GroupChat>>(groupChatsEntity);
        }

        private async Task GetDefaultGroupIcon(GroupChatEntity userEntity)
        {
            var defaultAvatar = await _context.Files.FirstOrDefaultAsync(f => f.FileName == "groups.png");
            if (defaultAvatar != null)
            {
                userEntity.ActiveIcon = defaultAvatar;
                userEntity.ActiveIconId = defaultAvatar.Id;
            }
        }

        public async Task<(Message, int)> GetLastMessageAndCountOfUnreaded(Guid chatId, Guid userId)
        {
            //*При викорисатнні await з ToListAsync вилітає Exeption
            var messagesEnity = _context.Messages
                .Where(m => m.ChatId == chatId)
                .Include(m => (m as MediaMessageEntity).Content)
                .ToList();

            var lastMessage = messagesEnity
                .OrderByDescending(m => m.Timestamp)
                .FirstOrDefault();

            var unreadCount = messagesEnity
                .Where(m =>
                m.SenderId != userId &&
                           !m.IsReaded)
                .Count();

            Message resultMessage = lastMessage switch
            {
                TextMessageEntity textMsg => _mapper.Map<TextMessage>(textMsg),
                MediaMessageEntity mediaMsg => _mapper.Map<MediaMessage>(mediaMsg),
                _ => null
            };
            return (resultMessage, unreadCount);
        }

        public async Task<PrivateChat> CreatePrivateChat(Guid user1Id, Guid user2Id)
        {
            var newPrivateChatEntity = new PrivateChatEntity()
            {
                User1Id = user1Id,
                User2Id = user2Id,
            };

            var privateChatEntity = _context.PrivateChats.Add(newPrivateChatEntity).Entity;
            if (privateChatEntity != null)
            {
                var user1Chat = new UserChatEntity { ChatId = privateChatEntity.Id, UserId = user1Id };
                var user2Chat = new UserChatEntity { ChatId = privateChatEntity.Id, UserId = user2Id };
                _context.UserChats.Add(user1Chat);
                _context.UserChats.Add(user2Chat);
            }


            await _context.SaveChangesAsync();

            return _mapper.Map<PrivateChat>(privateChatEntity);
        }

        public async Task<Chat> Get(Guid chatId)
        {
            var privateChatEntity = await _context.Chats
                .OfType<PrivateChatEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == chatId);

            if (privateChatEntity != null)
            {
                return _mapper.Map<PrivateChat>(privateChatEntity);
            }

            var groupChatEntity = await _context.Chats
                 .OfType<GroupChatEntity>()
                 .Include(gc => gc.ActiveIcon)
                 .AsNoTracking()
                 .FirstOrDefaultAsync(c => c.Id == chatId);

            if (groupChatEntity != null)
            {
                return _mapper.Map<GroupChat>(groupChatEntity);
            }

            throw new ArgumentException("Chat is not exist");


        }

        public async Task<List<Guid>> GetChatUserIds(Guid chatId)
        {
            return await _context.UserChats
                .Where(uc => uc.ChatId == chatId)
                .Select(uc => uc.UserId)
                .ToListAsync();
        }

        public async Task<List<Guid>> GetUserChatIds(Guid userId)
        {
            return await _context.UserChats
                .Where(uc => uc.UserId == userId)
                .Select(uc => uc.ChatId)
                .ToListAsync();
        }

        public async Task AddMember(Guid chatId, Guid userId)
        {
            _context.UserChats.Add(new UserChatEntity { ChatId = chatId, UserId = userId });
            await _context.SaveChangesAsync();
        }

        public async Task AddMembers(Guid chatId, List<Guid> userIds)
        {
            var userChatEntities = userIds.Select(u => new UserChatEntity
            {
                ChatId = chatId,
                UserId = u,
            }).ToList();

            _context.UserChats.AddRange(userChatEntities);

            await _context.SaveChangesAsync();

        }

        public async Task<GroupChat> CreateGroupChat(Guid ownerId, string groupName)
        {
            var newGroupChatEntity = new GroupChatEntity()
            {
                AdminId = ownerId,
                GroupName = groupName,
            };
            await GetDefaultGroupIcon(newGroupChatEntity);

            var groupChatEntity = _context.GroupChat.Add(newGroupChatEntity).Entity;

            var groupChat = _mapper.Map<GroupChat>(groupChatEntity);

            return groupChat;
        }

        public async Task<bool> IsChatOwner(Guid userId, Guid chatId)
        {
            var groupChat = _context.GroupChat
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == chatId);

            if (groupChat != null && groupChat.AdminId == userId) return true;
            return false;
        }

        public async Task<Guid> RemoveMember(Guid memberId, Guid chatId)
        {
            var chatEntity = _context.UserChats
                .FirstOrDefault(uc => uc.UserId == memberId && uc.ChatId == chatId);

            if (chatEntity == null) return Guid.Empty;

            _context.UserChats.Remove(chatEntity);
            await _context.SaveChangesAsync();

            return memberId;
        }

        public async Task<string> ChangeChatName(string newChatName, Guid chatId)
        {
            var chatEntity = _context.GroupChat
                .FirstOrDefault(c => c.Id == chatId);

            if (chatEntity == null)
                throw new Exception("Chat not found");

            chatEntity.GroupName = newChatName;

            await _context.SaveChangesAsync();

            return chatEntity.GroupName;
        }

        public async Task<bool> IsChatExists(Guid chatId) => await _context.Chats.AnyAsync(c => c.Id == chatId);
        public async Task<bool> IsChatMember(Guid chatId, Guid userId) => await _context.UserChats.AnyAsync(uc => uc.UserId == userId && uc.ChatId == chatId);

    }
}
