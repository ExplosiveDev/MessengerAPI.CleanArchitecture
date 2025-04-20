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
        private readonly IFileRepository _fileRepository;
        private readonly IChatRepository _chatRepository;

		public MessageService(IMessageRepository messageRepository, IChatRepository chatRepository, IFileRepository fileRepository)
		{
			_messageRepository = messageRepository;
			_chatRepository = chatRepository;
			_fileRepository = fileRepository;
		}

		public async Task<TextMessage> AddTextMessage(string content, string chatId, string senderId)
		{
			var chatGuid = Guid.Parse(chatId);
			var senderGuid = Guid.Parse(senderId);
			var textMessage = await _messageRepository.AddTextMessage(content, chatGuid, senderGuid);
			return textMessage;

        }

		public async Task<MediaMessage> AddMediaMessage(string caption, string fileId, string senderId, string chatId)
		{
            var fileGuid = Guid.Parse(fileId);
            var chatGuid = Guid.Parse(chatId);
            var senderGuid = Guid.Parse(senderId);
            var mediaMessage = await _messageRepository.AddMediaMessage(caption, fileGuid, senderGuid, chatGuid);

			return mediaMessage;
		}

        public async Task<SearchedMessages> GetMessagesByChatId(Guid chatId)
        {
			if(_chatRepository.Get(chatId) is not null)
				return await _messageRepository.GetMessagesByChatId(chatId);
			return null;
        }

		public async Task SetIsReaded(List<string> msgIds)
		{
			if (msgIds is null) return;

			List<Guid> msgIdsToRead = new List<Guid>();
			foreach (var msgId in msgIds)
				msgIdsToRead.Add(Guid.Parse(msgId));

			await _messageRepository.SetIsReaded(msgIdsToRead);


		
        }
    }
}
