using Messenger.Core.Abstractions;
using Messenger.Core.Models;
using Messenger.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Application.Services
{
	public class MessageService : IMessageService
	{
		private readonly IMessageRepository _messageRepository;
		private readonly IChatRepository _chatRepository;

		public MessageService(IMessageRepository messageRepository, IChatRepository chatRepository)
		{
			_messageRepository = messageRepository;
			_chatRepository = chatRepository;
		}

		public async Task<Message> AddMessage(string content, Guid chatId, Guid senderId)
		{
			return await _messageRepository.Add(content, chatId, senderId);
		}
		public async Task<List<Message>> GetAllMessages()
		{
			return await _messageRepository.Get();
		}

        public Task<List<Message>> GetMessagesByChatId(Guid chatId)
        {
			if(_chatRepository.Get(chatId) is not null)
				return _messageRepository.GetMessagesByChatId(chatId);
			return null;
        }
    }
}
