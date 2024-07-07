
using Messenger.Core.Models;

namespace Messenger.Application.Services
{
	public interface IUserService
	{
		Task<(User user, string token)> Login(string phone, string password);
		Task<(User user, string error)> Register(string userName, string phone, string password);
		Task<bool> IsUniquePhone(string phone);
		Task<User> GetById(Guid userId);
		Task<List<User>> SearchByUserName(string userName);
	}
}