using Messenger.Core.Models;

namespace Messenger.DataAccess.Repositories
{
	public interface IMessageRepository
	{
		Task<Message> Add(string content, Guid chatId, Guid senderId);
		Task<List<Message>> Get();
		Task<List<Message>> GetMessagesByChatId(Guid chatId);
    }
}