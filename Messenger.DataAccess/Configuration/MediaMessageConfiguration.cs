using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Messenger.DataAccess.Configuration
{
    public class MediaMessageConfiguration : IEntityTypeConfiguration<MediaMessageEntity>
    {
        public void Configure(EntityTypeBuilder<MediaMessageEntity> builder)
        {
            builder
                .HasBaseType<MessageEntity>();
            
            builder
                .HasMany(m => m.Content)
                .WithOne(f => f.MediaMessage)
                .HasForeignKey(f => f.MediaMessageId);
        }
    }
}
