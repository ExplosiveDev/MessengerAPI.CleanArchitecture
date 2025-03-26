using Messenger.Core.Models;

namespace Messenger.API.Contracts
{
	public record MessagesResponse(
		List<TextMessage> TextMessages,
		List<MediaMessage> MediaMessages
		);
}