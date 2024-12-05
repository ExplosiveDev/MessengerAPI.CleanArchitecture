using AutoMapper;
using Messenger.Core.Models;
using Messenger.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Repositories
{
	public class ConnectionRepository : IConnectionRepository
	{
		private readonly ProductStoreDBcontext _context;
		private readonly IMapper _mapper;
		public ConnectionRepository(ProductStoreDBcontext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task CreateConnection(Connection connection)
		{
			var connectionEntity = await _context.Connections
					.FirstOrDefaultAsync(c => c.UserId == connection.UserId);

			if (connectionEntity != null)
			{
				// Якщо потрібно оновити інші поля
				// Оновлюйте лише ті, що не є PK
				_context.Connections.Remove(connectionEntity); // Видалення старого запису
				connectionEntity = _mapper.Map<ConnectionEntity>(connection); // Створення нового з новим ConnectionId
				await _context.Connections.AddAsync(connectionEntity); // Додавання нового запису
			}
			else
			{
				connectionEntity = _mapper.Map<ConnectionEntity>(connection);
                await _context.Connections.AddAsync(connectionEntity);
			}

			await _context.SaveChangesAsync();
		}


		public async Task DeleteConnection(Guid userId)
		{
			var connectionEntity = _context.Connections.FirstOrDefault(x => x.UserId == userId);
			if (connectionEntity != null)
			{
				_context.Connections.Remove(connectionEntity);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<Connection> GetConnection(Guid userId)
		{
			var connectionEntity = _context.Connections.FirstOrDefault(x => x.UserId == userId); 
			return _mapper.Map<Connection>(connectionEntity);
		}

		public async Task<Connection> GetConnection(string connectionId)
		{
			var connectionEntity = _context.Connections.FirstOrDefault(x => x.ConnectionId == connectionId);
			return _mapper.Map<Connection>(connectionEntity);
		}
	}
}
