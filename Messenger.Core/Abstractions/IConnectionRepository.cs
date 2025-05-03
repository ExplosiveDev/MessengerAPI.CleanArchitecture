using Messenger.Core.Models;

namespace Messenger.DataAccess.Repositories
{
	public interface IConnectionRepository
	{
		Task CreateConnection(Connection connection);
		Task DeleteUserConnection(Guid userId);
        Task<List<Connection>> GetChatConnections(List<Guid> userIds);
		Task<Connection> GetConnection(string connectionId);
		Task<Connection> GetConnectionByUserId(Guid userId);
	}
}