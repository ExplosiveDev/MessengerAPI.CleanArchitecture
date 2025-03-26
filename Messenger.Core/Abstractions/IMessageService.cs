using Messenger.Core.Models;

namespace Messenger.Application.Services
{
	public interface IMessageService
	{
        Task<MediaMessage> AddMediaMessage(string caption, Guid fileId, Guid senderId, Guid chatId);
        Task<TextMessage> AddTextMessage(string content, Guid chatId, Guid senderId);
		Task<SearchedMessages> GetMessagesByChatId(Guid chatId);
		Task SetIsReaded(List<string> msgIds);

    }
}