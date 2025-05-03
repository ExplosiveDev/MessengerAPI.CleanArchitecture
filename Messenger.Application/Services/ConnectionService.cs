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
	public class ConnectionService : IConnectionService
	{
		private readonly IConnectionRepository _connectionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IChatRepository _chatRepository;

        public ConnectionService(IConnectionRepository connectionRepository, IUserRepository userRepository, IChatRepository chatRepository)
		{
			_connectionRepository = connectionRepository;
			_userRepository = userRepository;
			_chatRepository = chatRepository;
		}

		public async Task CreateConnection(Guid userGuid, string connectionId, string stringConnection)
		{
            if (!await _userRepository.IsUserExists(userGuid)) throw new ArgumentException("Користувач не знайдений", nameof(userGuid));

            await _connectionRepository.CreateConnection(Connection.Create(userGuid, connectionId, stringConnection));
		}

		public async Task DeleteConnection(Guid userGuid)
		{
            await _connectionRepository.DeleteUserConnection(userGuid);
		}

		public async Task<List<Connection>> GetConnections(Guid chatGuid)
		{
            var userIds = await _chatRepository.GetChatUserIds(chatGuid);

			return await _connectionRepository.GetChatConnections(userIds);
		}

		public async Task<Connection> GetConnection(string connectionId)
		{
			return await _connectionRepository.GetConnection(connectionId);
		}

        public async Task<Connection> GetUserConnection(string userId)
        {
            var userGuid = Guid.Parse(userId);
            if (!await _userRepository.IsUserExists(userGuid)) throw new ArgumentException("Користувач не знайдений", nameof(userGuid));
            return await _connectionRepository.GetConnectionByUserId(userGuid);
        }
    }
}
