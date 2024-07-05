using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Messenger.DataAccess.Entities;
using Messenger.Core.Models;

namespace Messenger.DataAccess.Configuration
{
	public class MessageConfiguration : IEntityTypeConfiguration<MessageEntity>
	{
		public void Configure(EntityTypeBuilder<MessageEntity> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Content)
				.IsRequired();

			builder.HasMany(m => m.Chats)
				.WithMany(c => c.Messages);

			builder.HasOne(e => e.Sender)
				.WithMany(u => u.Messages);
		}
	}
}
