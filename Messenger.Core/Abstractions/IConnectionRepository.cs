using Messenger.Core.Models;

namespace Messenger.DataAccess.Repositories
{
	public interface IConnectionRepository
	{
		Task CreateConnection(Connection connection);
		Task DeleteConnection(string connectionId);
		Task<Connection> GetConnection(string connectionId);
	}
}