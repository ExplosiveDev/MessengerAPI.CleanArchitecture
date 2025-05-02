using Messenger.Core.Enums;
using Messenger.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Core.Abstractions
{
	public interface IUserRepository
	{
		public Task Add(User user);
		public Task<User> GetByPhone(string email);
		Task<User> GetUserWithAvatar(Guid userId);
        Task<List<User>> GetUsersWithAvatars(List<Guid> userIds);
        public Task<bool> IsUniquePhone(string email);
		Task<List<User>> SearchByUserName(string userName);
        Task<List<User>> GetContacts(Guid userId);
		Task<string> ChangeUserFields(Guid userId, string newUserName);
        Task<List<User>> GetUsersByNameWithAvatar(string userName);
    }
}
