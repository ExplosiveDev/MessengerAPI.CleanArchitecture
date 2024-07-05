using AutoMapper;
using Messenger.Core.Models;
using Messenger.DataAccess;
using Messenger.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Messenger.DataAccess.Repositories
{
	public class MessageRepository : IMessageRepository
	{
		private readonly ProductStoreDBcontext _context;
		private readonly IMapper _mapper;
		public MessageRepository(ProductStoreDBcontext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task Add(Message message)
		{
			var messageEntity = _mapper.Map<MessageEntity>(message);
			await _context.Messages.AddAsync(messageEntity);
			await _context.SaveChangesAsync();
		}
		public async Task<List<Message>> Get()
		{
			var messagesEntity = await _context.Messages
				.AsNoTracking()
				.ToListAsync();

			return _mapper.Map<List<Message>>(messagesEntity);
		}
	}
}
