using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Messenger.DataAccess.Configuration
{
    public class GroupChatConfiguration : IEntityTypeConfiguration<GroupChatEntity>
    {
        public void Configure(EntityTypeBuilder<GroupChatEntity> builder)
        {
            builder
                .HasBaseType<ChatEntity>();

            builder
                .HasOne(g => g.ActiveIcon)
                .WithMany()
                .HasForeignKey(g => g.ActiveIconId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }

}
