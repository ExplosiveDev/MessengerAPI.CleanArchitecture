
using Messenger.Core.Models;

namespace Messenger.Application.Services
{
	public interface IConnectionService
	{
		Task CreateConnection(Guid userId, string connectionId, string stringConnection);
		Task DeleteConnection(Guid userId);
		Task<Connection> GetConnection(Guid userId);
		Task<Connection> GetConnection(string connectionId);

	}
}