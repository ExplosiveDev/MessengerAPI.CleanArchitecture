using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Messenger.Core.Models;
using Messenger.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Messenger.DataAccess.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly MessengerStoreDBcontext _context;
        private readonly IMapper _mapper;
        public ChatRepository(MessengerStoreDBcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SearchedChats> GetSavedChats(Guid userId)
        {
            var userChatEntities = await _context.UserChats
                .Where(uc => uc.UserId == userId)
                .ToListAsync();

            var chatIds = userChatEntities.Select(uc => uc.ChatId).ToList();

            var privateChatsEntity = await _context.Chats
                .OfType<PrivateChatEntity>()
                .Where(c => chatIds.Contains(c.Id))
                .Include(c => c.User1)
                .Include(c => c.User2)
                .ToListAsync();

            var groupChatsEntity = await _context.Chats
                .OfType<GroupChatEntity>()
                .Where(c => chatIds.Contains(c.Id))
                .Include(gc => gc.UserChats)
                .ThenInclude(uc => uc.User) 
                .ToListAsync();

            SearchedChats savedChats = new SearchedChats()
            {
                PrivateChats = _mapper.Map<List<PrivateChat>>(privateChatsEntity),
                GroupChats = _mapper.Map<List<GroupChat>>(groupChatsEntity)
            };

            return savedChats;


        }

        public async Task<SearchedChats> GetGlobalChatsByName(Guid currentUserId, string name)
        {
            var currentUserEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == currentUserId);

            var usersEntity = await _context.Users
                .AsNoTracking()
                .Where(u => u.UserName.Contains(name) && u.Id != currentUserId)
                .ToListAsync();

            List<PrivateChat> privateChats = new List<PrivateChat>();
            if (usersEntity.Count > 0)
            {
                var users = _mapper.Map<List<User>>(usersEntity);
                var currentUser = _mapper.Map<User>(currentUserEntity);

                foreach (var user in users) 
                {
                    PrivateChat privateChat = new PrivateChat()
                    {
                        Id = Guid.NewGuid(),
                        User1Id = user.Id,
                        User1 = user,
                        User2Id = currentUser.Id,
                        User2 = currentUser,
                    };
                    privateChats.Add(privateChat);
                }
            }

            var groupChatsEntity = await _context.Chats
                .OfType<GroupChatEntity>()
                .Where(gc => gc.GroupName.Contains(name))
                .ToListAsync();

            SearchedChats searchedGlobalChats = new SearchedChats()
            {
                PrivateChats = privateChats,
                GroupChats = _mapper.Map<List<GroupChat>>(groupChatsEntity)
            };

            return searchedGlobalChats;
        }

        public async Task<Chat> Get(Guid chatId)
        {
            var chatEntity = await _context.Chats
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == chatId);
            
            return _mapper.Map<Chat>(chatEntity);

        }
    }
}
