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

		public async Task CreateConnection(string connectionId, string stringConnection)
		{
			await _connectionRepository.CreateConnection(Connection.Create(connectionId, stringConnection));
		}

		public async Task DeleteConnection(string connectionId)
		{
			await _connectionRepository.DeleteConnection(connectionId);
		}

		public async Task<Connection> GetConnection(string connectionId)
		{
			return await _connectionRepository.GetConnection(connectionId);
		}
	}
}
