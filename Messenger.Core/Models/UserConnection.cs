using Messenger.Core.Models;

namespace Messenger.API.Hubs
{
	public record UserConnection(User User, string chatRoom);
}
