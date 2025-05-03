
using Messenger.Core.Models;

namespace Messenger.Application.Services
{
	public interface IConnectionService
	{
		Task CreateConnection(Guid userId, string connectionId, string stringConnection);
		Task DeleteConnection(Guid userId);
        Task<List<Connection>> GetConnections(Guid chatId);
		Task<Connection> GetConnection(string connectionId);
		Task<Connection> GetUserConnection(string userId);

	}
}