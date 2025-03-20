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

        public async Task<Message> Add(string content, Guid chatId, Guid senderId)
        {
            // 1. Перевіряємо, чи існує такий користувач
            var sender = await _context.Users.FindAsync(senderId);
            if (sender == null) throw new Exception("Користувач не знайдений");

            // 2. Перевіряємо, чи існує такий чат
            var chat = await _context.PrivateChats.FindAsync(chatId);
            if (chat == null) throw new Exception("Чат не знайдено");

            // 3. Перевіряємо, чи користувач є учасником чату
            bool isMember = await _context.UserChats
                .AnyAsync(uc => uc.UserId == senderId && uc.ChatId == chatId);

            if (!isMember) throw new Exception("Користувач не є учасником чату");

            // 4. Створюємо нове повідомлення
            var messageEntity = new MessageEntity
            {
                SenderId = senderId,
                ChatId = chatId,
                Content = content,
                Timestamp = DateTime.Now,
            };

            _context.Messages.Add(messageEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<Message>(messageEntity);
        }



        public async Task<List<Message>> Get()
        {
            var messagesEntity = await _context.Messages
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<List<Message>>(messagesEntity);
        }

        public async Task<List<Message>> GetMessagesByChatId(Guid chatId)
        {
            var messagesEntity = await _context.Messages
                .Where(x => x.ChatId == chatId)
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<List<Message>>(messagesEntity);
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
