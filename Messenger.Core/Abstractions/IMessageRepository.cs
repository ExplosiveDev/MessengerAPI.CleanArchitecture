using Messenger.Core.Models;

namespace Messenger.DataAccess.Repositories
{
	public interface IMessageRepository
	{
        Task<MediaMessage> AddMediaMessage(string caption, Guid fileId, Guid senderId, Guid chatId);
        Task<TextMessage> AddTextMessage(string content, Guid chatId, Guid senderId);
		Task<List<Message>> Get();
		Task<SearchedMessages> GetMessagesByChatId(Guid chatId);
		Task SetIsReaded(List<Guid> ids);
    }
}