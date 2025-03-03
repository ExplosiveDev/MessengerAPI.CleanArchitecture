using Messenger.Core.Models;

namespace Messenger.API.Contracts
{
	public record MessageResponse(
		Guid Id,
		Guid SenderId,
		string Content,
		string Timestamp,
		User Sender);
}