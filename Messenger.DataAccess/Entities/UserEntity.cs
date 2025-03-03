
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Entities
{
	public class UserEntity
	{
		public Guid Id { get; set; }
		public string UserName { get;  set; } = string.Empty;
		public string PasswordHash { get; set; } = string.Empty;
		public string Phone { get; set; } = string.Empty;

        public ICollection<UserChatEntity> UserChats { get; set; } = [];
        public ICollection<RoleEntity> Roles { get; set; } = [];
	}
}
