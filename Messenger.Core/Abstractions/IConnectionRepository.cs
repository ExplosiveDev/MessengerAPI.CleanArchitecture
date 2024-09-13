using Messenger.Core.Models;

namespace Messenger.DataAccess.Repositories
{
	public interface IConnectionRepository
	{
		Task CreateConnection(Connection connection);
		Task DeleteConnection(Guid userId);
		Task<Connection> GetConnection(Guid userId);
		Task<Connection> GetConnection(string connectionId);
	}
}