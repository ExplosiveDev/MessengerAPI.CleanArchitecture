using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Core.Abstractions;
using Messenger.Core.Models;
using Messenger.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

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

        public async Task<SearchedChats> GetSavedChats(Guid userId)
        {
            return await _chatRepository.GetSavedChats(userId);
        }

        public async Task<SearchedChats> GetGlobalChatsByName(Guid currentUserId, string name)
        {
            return await _chatRepository.GetGlobalChatsByName(currentUserId, name);
        }

        public async Task<PrivateChat> CreatePrivateChat(Guid user1Id, Guid user2Id)
        {
            var user1 = await _userRepository.GetById(user1Id);
            var user2 = await _userRepository.GetById(user2Id);

            // Перевірка, чи існують користувачі
            if (user1 == null || user2 == null) return null;
            return await _chatRepository.CreatePrivateChat(user1Id, user2Id);
        }

        public async Task<Chat> GetChat(Guid chatId, Guid userId)
        {
            return await _chatRepository.Get(chatId, userId);   
        }
    }
}
