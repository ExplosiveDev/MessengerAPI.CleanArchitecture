using Messenger.Core.Models;

namespace Messenger.Application.Services
{
	public interface IMessageService
	{
        Task<MediaMessage> AddMediaMessage(string caption, string fileId, string senderId, string chatId);
        Task<TextMessage> AddTextMessage(string content, string chatId, string senderId);
		Task<SearchedMessages> GetMessagesByChatId(Guid chatId);
		Task SetIsReaded(List<string> msgIds);

    }
}