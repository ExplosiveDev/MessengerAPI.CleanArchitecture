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

		public MessageService(IMessageRepository messageRepository)
		{
			_messageRepository = messageRepository;
		}

		public async Task AddMessage(Message message)
		{
			await _messageRepository.Add(message);
		}
		public async Task<List<Message>> GetAllMessages()
		{
			return await _messageRepository.Get();
		}
	}
}
