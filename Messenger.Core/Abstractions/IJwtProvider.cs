using Messenger.Core.Models;

namespace Messenger.Infrastructure
{
	public interface IJwtProvider
	{
		string GenerateToken(User user);
	}
}