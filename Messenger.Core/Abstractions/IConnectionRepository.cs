using Messenger.Core.Models;

namespace Messenger.DataAccess.Repositories
{
	public interface IConnectionRepository
	{
		Task CreateConnection(Connection connection);
		Task DeleteConnection(Guid userId);
		Task<List<User>> GetMessageRecipientsAsync(Guid chatId);
        Task<List<Connection>> GetConnections(Guid chatId);
		Task<Connection> GetConnection(string connectionId);
		Task<Connection> GetConnectionByUserId(Guid userId);
	}
}