using Messenger.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Messenger.DataAccess.Configuration
{
	public class ChatConfiguration : IEntityTypeConfiguration<ChatEntity>
	{
		public void Configure(EntityTypeBuilder<ChatEntity> builder)
		{
			builder
				.HasKey(c=> c.Id);

			builder
				.HasMany(c => c.Messages)
				.WithOne(m => m.Chat)
				.HasForeignKey(m => m.ChatId);

            builder
				.HasMany(c => c.UserChats)
				.WithOne(uc => uc.Chat)
				.HasForeignKey(uc => uc.ChatId);

        }
    }
}
