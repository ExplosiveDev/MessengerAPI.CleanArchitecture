namespace Messenger.API.Contracts
{
	public record LoginUserRequest(
		string Phone,
		string Password);
}
