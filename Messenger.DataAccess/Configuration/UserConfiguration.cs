using Messenger.Core.Models;
using Messenger.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Configuration
{
	public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
	{
		public void Configure(EntityTypeBuilder<UserEntity> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.UserName)
				.HasMaxLength(User.MAX_NAME_LENGHT)
				.IsRequired();

			builder.Property(x => x.Phone)
				.IsRequired();

			builder.Property(x => x.PasswordHash)
				.IsRequired();

			builder.HasMany(u => u.Chats)
				.WithMany(c => c.Users);

			builder.HasMany(u => u.Messages)
				.WithOne(m => m.Sender)
				.HasForeignKey(m => m.SenderId);


			//Seed data
			builder.HasData(
				new UserEntity
				{
					Id = Guid.Parse("6c0136a2-48d9-450f-9814-5cba270dce14"),
					Phone = "+380964674274",
					PasswordHash = "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a",
					UserName = "VladGromovij"
				},
				new UserEntity
				{
					Id = Guid.Parse("57322de4-860d-4c50-950a-0e88f87d096c"),
					Phone = "+380963554053",
					PasswordHash = "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a",
					UserName = "Saller"
				}
			);
		}
	}
}
