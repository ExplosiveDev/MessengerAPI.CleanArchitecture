
using Messenger.Core.Models;

namespace Messenger.Application.Services
{
	public interface IConnectionService
	{
		Task CreateConnection(string connectionId, string stringConnection);
		Task DeleteConnection(string connectionId);
		Task<Connection> GetConnection(string connectionId);
	}
}