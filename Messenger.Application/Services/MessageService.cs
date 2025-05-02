using Messenger.Core.Abstractions;
using Messenger.Core.Models;
using Messenger.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
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
        private readonly IUserRepository _userRepository;

        public MessageService(IMessageRepository messageRepository, IChatRepository chatRepository, IFileRepository fileRepository, IUserRepository userRepository)
        {
            _messageRepository = messageRepository;
            _chatRepository = chatRepository;
            _fileRepository = fileRepository;
            _userRepository = userRepository;
        }
        private async Task ValidateMessageConditions(Guid userGuid, Guid chatGuid)
        {
            if (!await _userRepository.IsUserExists(userGuid))
                throw new ArgumentException("Користувач не знайдений", nameof(userGuid));

            if (!await _chatRepository.IsChatExists(chatGuid))
                throw new ArgumentException("Чат не знайдено", nameof(chatGuid));

            if (!await _chatRepository.IsChatMember(chatGuid, userGuid))
                throw new ArgumentException("Користувач не є учасником чату", nameof(userGuid));
        }
        private async Task ValidateMessageConditions(Guid userGuid, Guid chatGuid, Guid fileGuid)
        {
            await ValidateMessageConditions(userGuid, chatGuid);

            if (!await _fileRepository.IsFileExists(fileGuid))
                throw new ArgumentException("Файл не знайдено", nameof(fileGuid));
        }
        public async Task<TextMessage> AddTextMessage(string content, string chatId, string senderId)
        {
            var senderGuid = Guid.Parse(senderId);
            var chatGuid = Guid.Parse(chatId);

            await ValidateMessageConditions(senderGuid, chatGuid);

            var textMessage = await _messageRepository.AddTextMessage(content, chatGuid, senderGuid);
            return textMessage;

        }
        public async Task<MediaMessage> AddMediaMessage(string caption, string fileId, string senderId, string chatId)
        {
            var fileGuid = Guid.Parse(fileId);
            var chatGuid = Guid.Parse(chatId);
            var senderGuid = Guid.Parse(senderId);

            await ValidateMessageConditions(senderGuid, chatGuid, fileGuid);

            var mediaMessage = await _messageRepository.AddMediaMessage(caption, fileGuid, senderGuid, chatGuid);

            return mediaMessage;
        }
        public async Task<SearchedMessages> GetMessagesByChatId(Guid chatId)
        {
            var messageIds = await _messageRepository.GetChatMessageIds(chatId);

            var textMessages = await _messageRepository.GetTextMessages(messageIds);

            var mediaMessages = await _messageRepository.GetMediaMessages(messageIds);

            return new SearchedMessages { TextMessages = textMessages, MediaMessages = mediaMessages };
        }
        public async Task SetIsReaded(List<string> msgIds)
        {
            List<Guid> msgIdsToRead = msgIds.Select(Guid.Parse).ToList();

            await _messageRepository.SetIsReaded(msgIdsToRead);
        }
    }
}
