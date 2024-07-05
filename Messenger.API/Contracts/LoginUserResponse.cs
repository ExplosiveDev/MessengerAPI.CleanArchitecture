using Messenger.Core.Models;

namespace Messenger.API.Contracts
{
	public record LoginUserResponse(
	User user,
	string token);
}
