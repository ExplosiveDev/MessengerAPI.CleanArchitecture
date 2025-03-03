using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Core.Models;
using Messenger.DataAccess.Repositories;

namespace Messenger.Application.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task<SearchedChats> GetSavedChats(Guid userId)
        {
            return await _chatRepository.GetSavedChats(userId);
        }

        public async Task<SearchedChats> GetGlobalChatsByName(Guid currentUserId, string name)
        {
            return await _chatRepository.GetGlobalChatsByName(currentUserId, name);
        }
    }
}
