using Messenger.Core.Models;

namespace Messenger.API.Contracts
{

	public record RegisterUserRequest(
	string UserName,
	string Phone,
	string Password);

}
