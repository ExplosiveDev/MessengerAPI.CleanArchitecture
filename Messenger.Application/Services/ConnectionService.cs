using Messenger.Core.Models;
using Messenger.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Application.Services
{
	public class ConnectionService : IConnectionService
	{
		private readonly IConnectionRepository _connectionRepository;

		public ConnectionService(IConnectionRepository connectionRepository)
		{
			_connectionRepository = connectionRepository;
		}

		public async Task CreateConnection(Guid userId, string connectionId, string stringConnection)
		{
			await _connectionRepository.CreateConnection(Connection.Create(userId, connectionId, stringConnection));
		}

		public async Task DeleteConnection(Guid userId)
		{
			await _connectionRepository.DeleteConnection(userId);
		}

		public async Task<Connection> GetConnection(Guid userId)
		{
			return await _connectionRepository.GetConnection(userId);
		}

		public async Task<Connection> GetConnection(string connectionId)
		{
			return await _connectionRepository.GetConnection(connectionId);
		}
		//aa
	}
}
