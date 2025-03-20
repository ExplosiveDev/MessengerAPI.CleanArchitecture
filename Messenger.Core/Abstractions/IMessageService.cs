using Messenger.Core.Models;

namespace Messenger.Application.Services
{
	public interface IMessageService
	{
		Task<Message> AddMessage(string content, string photoId, Guid chatId, Guid senderId);
		Task<List<Message>> GetAllMessages();
		Task<List<Message>> GetMessagesByChatId(Guid chatId);
		Task SetIsReaded(List<string> msgIds);

    }
}