namespace Messenger.API.Contracts
{
	public record UserResponse(
			Guid Id,
			string UserName,
			string PasswordHash,
			string Phone
		);
}
