using Messenger.Core.Models;

namespace Messenger.DataAccess.Repositories
{
	public interface IMessageRepository
	{
        Task<MediaMessage> AddMediaMessage(string caption, Guid fileId, Guid senderId, Guid chatId);
        Task<TextMessage> AddTextMessage(string content, Guid chatId, Guid senderId);
        Task<List<MediaMessage>> GetMediaMessages(List<Guid> messageIds);
        Task<List<Guid>> GetChatMessageIds(Guid chatId);
        Task<List<TextMessage>> GetTextMessages(List<Guid> messageIds);
		Task SetIsReaded(List<Guid> ids);
    }
}