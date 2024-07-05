using Messenger.Core.Models;
using Messenger.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Core.Enums;

namespace Messenger.DataAccess.Configuration
{
	public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
	{
		public void Configure(EntityTypeBuilder<RoleEntity> builder)
		{
			builder.HasKey(x => x.Id);

			var roles = Enum
				.GetValues<Role>()
				.Select(x => new RoleEntity
				{
					Id = (int)x,
					Name = x.ToString()
				});

			builder.HasData(roles);
		}
	}
}
