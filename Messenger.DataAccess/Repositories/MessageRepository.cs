using AutoMapper;
using Messenger.Core.Models;
using Messenger.DataAccess;
using Messenger.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Messenger.DataAccess.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly MessengerDBcontext _context;
        private readonly IMapper _mapper;
        public MessageRepository(MessengerDBcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private async Task ValidateMessageConditions(Guid chatId, Guid senderId)
        {
            // 1. Перевірка користувача
            var senderExists = await _context.Users.AnyAsync(u => u.Id == senderId);
            if (!senderExists)
                throw new ArgumentException("Користувач не знайдений", nameof(senderId));

            // 2. Перевірка чату
            var chatExists = await _context.Chats.AnyAsync(c => c.Id == chatId);
            if (!chatExists)
                throw new ArgumentException("Чат не знайдено", nameof(chatId));

            // 3. Перевірка учасника чату
            bool isMember = await _context.UserChats
                .AnyAsync(uc => uc.UserId == senderId && uc.ChatId == chatId);

            if (!isMember)
                throw new ArgumentException("Користувач не є учасником чату", nameof(senderId));
        }

        public async Task<TextMessage> AddTextMessage(string content, Guid chatId, Guid senderId)
        {
            await ValidateMessageConditions(chatId, senderId);

            var textMessageEntity = new TextMessageEntity
            {
                SenderId = senderId,
                ChatId = chatId,
                Content = content,
                Timestamp = DateTime.Now,
            };

            _context.TextMessages.Add(textMessageEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<TextMessage>(textMessageEntity);
        }

        public async Task<MediaMessage> AddMediaMessage(string caption, Guid fileId, Guid senderId, Guid chatId)
        {
            await ValidateMessageConditions(chatId, senderId);

            var fileEntity = await _context.Files
                .FirstOrDefaultAsync(f => f.Id == fileId);

            var mediaMessageEntity = new MediaMessageEntity { 
                SenderId = senderId,
                ChatId = chatId,
                Content = new List<FileEntity> { fileEntity },
                Caption = caption,
                Timestamp = DateTime.Now,
                MediaType = fileEntity.ContentType,
                
            };

            var entity = _context.MediaMessages.Add(mediaMessageEntity).Entity;

            fileEntity.MediaMessage = entity;
            fileEntity.MediaMessageId = entity.Id;

            await _context.SaveChangesAsync();

            return _mapper.Map<MediaMessage>(mediaMessageEntity);
        }



        public async Task<List<Message>> Get()
        {
            var messagesEntity = await _context.Messages
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<List<Message>>(messagesEntity);
        }

        private async Task<List<Guid>> GetMessageIds(Guid chatId)
        {
            var ids = await _context.Messages
                .Where(m => m.ChatId == chatId)
                .AsNoTracking()
                .Select(m => m.Id)
                .ToListAsync();

            return ids;
        }

        public async Task<SearchedMessages> GetMessagesByChatId(Guid chatId)
        { 
            var mesageIds = await GetMessageIds(chatId);

            var textMessagesEntity = await _context.Messages
                .OfType<TextMessageEntity>()
                .Where(m => mesageIds.Contains(m.Id))
                .AsNoTracking()
                .ToListAsync();

            var mediaMessagesEntity = await _context.Messages
                .OfType<MediaMessageEntity>()
                .Where(m => mesageIds.Contains(m.Id))
                .Include(m => m.Content)
                .AsNoTracking()
                .ToListAsync();

            var textMessages = _mapper.Map<List<TextMessage>>(textMessagesEntity);
            var mediaMessages = _mapper.Map<List<MediaMessage>>(mediaMessagesEntity);

            return new SearchedMessages {TextMessages = textMessages, MediaMessages = mediaMessages };
        }

        public async Task SetIsReaded(List<Guid> ids)
        {
            var messagesEntity = await _context.Messages
                .Where(m => ids.Contains(m.Id))
                .ToListAsync();

            messagesEntity.ForEach((MessageEntity msg) => { msg.IsReaded = true; });
            await _context.SaveChangesAsync();

        }
    }
}
