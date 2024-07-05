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
	public class ChatConfiguration : IEntityTypeConfiguration<ChatEntity>
	{
		public void Configure(EntityTypeBuilder<ChatEntity> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Name)
				.IsRequired();

			builder.HasMany(c => c.Messages)
				  .WithMany(m => m.Chats);

			builder.HasMany(c => c.Users)
				   .WithMany(u => u.Chats);
		}
	}
}
