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
	public class ConnectionConfiguration : IEntityTypeConfiguration<ConnectionEntity>
	{
		public void Configure(EntityTypeBuilder<ConnectionEntity> builder)
		{
			builder.HasKey(x => x.ConnectionId);

			builder.Property(x => x.stingConnection)
				.IsRequired();

		}
	}
}
