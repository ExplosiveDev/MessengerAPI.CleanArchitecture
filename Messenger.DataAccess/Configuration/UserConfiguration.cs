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
			builder
				.HasKey(u => u.Id);

			builder
				.Property(u => u.UserName)
				.HasMaxLength(User.MAX_NAME_LENGHT)
				.IsRequired();

			builder
				.Property(u => u.Phone)
				.IsRequired();

			builder.Property(u => u.PasswordHash)
				.IsRequired();

            builder
				.HasMany(u => u.UserChats)
				.WithOne(uc => uc.User)
				.HasForeignKey(u => u.UserId);



            //Seed data
            var passwordHash = "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a";

			builder.HasData(
				new UserEntity
				{
					Id = Guid.Parse("6c0136a2-48d9-450f-9814-5cba270dce14"),
					Phone = "+380964674274",
					PasswordHash = passwordHash,
					UserName = "Vlad Gromovij"
				},
				new UserEntity
				{
					Id = Guid.Parse("f9a74d03-b637-4787-bdf2-930eff19c944"),
					Phone = "+380963554053",
					PasswordHash = passwordHash,
					UserName = "Saller"
				},
				new UserEntity
				{
					Id = Guid.Parse("46028997-952e-4f9c-9282-4ebd7526ea9c"),
                    Phone = "+380961111111",
					PasswordHash = passwordHash,
					UserName = "John Doe"
				},
				new UserEntity
				{
					Id = Guid.Parse("57322de4-860d-4c50-950a-0e88f87d096c"),
                    Phone = "+380962222222",
					PasswordHash = passwordHash,
					UserName = "Jane Smith"
				},
				new UserEntity
				{
					Id = Guid.NewGuid(),
					Phone = "+380963333333",
					PasswordHash = passwordHash,
					UserName = "Alice Johnson"
				},
				new UserEntity
				{
					Id = Guid.NewGuid(),
					Phone = "+380964444444",
					PasswordHash = passwordHash,
					UserName = "Bob Brown"
				},
				new UserEntity
				{
					Id = Guid.NewGuid(),
					Phone = "+380965555555",
					PasswordHash = passwordHash,
					UserName = "Charlie Davis"
				},
				new UserEntity
				{
					Id = Guid.NewGuid(),
					Phone = "+380966666666",
					PasswordHash = passwordHash,
					UserName = "David Evans"
				}
			);
		}
	}
}
