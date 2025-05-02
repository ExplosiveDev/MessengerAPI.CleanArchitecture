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

        public async Task<TextMessage> AddTextMessage(string content, Guid chatId, Guid senderId)
        {

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

        public async Task<List<Guid>> GetChatMessageIds(Guid chatId)
        {
            var ids = await _context.Messages
                .Where(m => m.ChatId == chatId)
                .AsNoTracking()
                .Select(m => m.Id)
                .ToListAsync();

            return ids;
        }

        public async Task<List<TextMessage>> GetTextMessages(List<Guid> messageIds) 
        {
            var textMessagesEntity = await _context.Messages
                .OfType<TextMessageEntity>()
                .Where(m => messageIds.Contains(m.Id))
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<List<TextMessage>>(textMessagesEntity);
        }

        public async Task<List<MediaMessage>> GetMediaMessages(List<Guid> messageIds)
        {
            var mediaMessagesEntity = await _context.Messages
                .OfType<MediaMessageEntity>()
                .Where(m => messageIds.Contains(m.Id))
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<List<MediaMessage>>(mediaMessagesEntity);
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
