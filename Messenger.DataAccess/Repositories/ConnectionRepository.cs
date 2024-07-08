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
			var connectionEntity = _mapper.Map<ConnectionEntity>(connection);

			_context.Connections.Add(connectionEntity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteConnection(string connectionId)
		{
			var connectionEntity = await _context.Connections.FindAsync(connectionId);
			if (connectionEntity != null)
			{
				_context.Connections.Remove(connectionEntity);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<Connection> GetConnection(string connectionId)
		{
			var connectionEntity = await _context.Connections.FindAsync(connectionId);	
			return _mapper.Map<Connection>(connectionEntity);
		}
	}
}
