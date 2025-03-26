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
    public class TextMessageConfiguration : IEntityTypeConfiguration<TextMessageEntity>
    {
        public void Configure(EntityTypeBuilder<TextMessageEntity> builder)
        {
            builder
                .HasBaseType<MessageEntity>();
        }
    }
}
