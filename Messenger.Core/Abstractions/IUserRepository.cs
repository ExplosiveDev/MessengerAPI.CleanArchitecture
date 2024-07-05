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
		Task<User> GetById(Guid userId);
		public Task<bool> IsUniquePhone(string email);
	}
}
