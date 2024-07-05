using Messenger.Core.Models;

namespace Messenger.DataAccess.Repositories
{
	public interface IMessageRepository
	{
		Task Add(Message message);
		Task<List<Message>> Get();
	}
}