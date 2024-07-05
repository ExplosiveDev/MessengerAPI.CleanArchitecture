using Messenger.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Configuration
{
	public class UserRoleConfiguration : IEntityTypeConfiguration<UserRoleEntity>
	{
		public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
		{
			builder.HasKey(ur => new { ur.UserId, ur.RoleId });

			builder.HasData(
				new UserRoleEntity
				{
					UserId = Guid.Parse("6c0136a2-48d9-450f-9814-5cba270dce14"),
					RoleId = 1
				},
				new UserRoleEntity
				{
					UserId = Guid.Parse("57322de4-860d-4c50-950a-0e88f87d096c"),
					RoleId = 3
				}
			);
		}
	}
}
