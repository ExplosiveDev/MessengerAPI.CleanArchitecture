using Messenger.Core.Models;
using Messenger.DataAccess.Entities;
using System.Collections.Generic;


namespace Messenger.DataAccess.Seeder
{
	public static class SeedData
	{
		
		public static List<UserEntity> GetUser()
		{
			List<UserEntity> ListUsers = new List<UserEntity>()
			{
				new UserEntity {Id = Guid.Parse("6c0136a2-48d9-450f-9814-5cba270dce14"), Phone = "+380964674274", PasswordHash = "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", Messages = [], Roles = { new RoleEntity {Name = "Admin" } }, UserName = "VladGromovij" },
				new UserEntity {Id = Guid.Parse("57322de4-860d-4c50-950a-0e88f87d096c"), Phone = "+380963554053", PasswordHash = "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", Messages = [], Roles = { new RoleEntity {Name = "User" } }, UserName = "Tania" }
			};

			return ListUsers;
		}

	}
}

