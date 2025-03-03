using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Messenger.Core.Models;

namespace Messenger.DataAccess.Configuration
{
    public class PrivateChatConfiguration : IEntityTypeConfiguration<PrivateChatEntity>
    {
        public void Configure(EntityTypeBuilder<PrivateChatEntity> builder)
        {
            builder
                .HasBaseType<ChatEntity>();

            builder
                .HasOne(pc => pc.User1)
                .WithMany()
                .HasForeignKey(pc => pc.User1Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(pc => pc.User2)
                .WithMany()
                .HasForeignKey(pc => pc.User2Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new PrivateChatEntity()
                {
                    Id = Guid.Parse("a2872c6e-2e30-4566-9ab4-1515be72b7c5"),
                    User1Id = Guid.Parse("6c0136a2-48d9-450f-9814-5cba270dce14"),
                    User2Id = Guid.Parse("57322de4-860d-4c50-950a-0e88f87d096c"),             
                },
                new PrivateChatEntity()
                {
                    Id = Guid.Parse("53d3f541-fa16-47f6-9e95-1e1cba92419e"),
                    User1Id = Guid.Parse("6c0136a2-48d9-450f-9814-5cba270dce14"),
                    User2Id = Guid.Parse("f9a74d03-b637-4787-bdf2-930eff19c944"),
                }, 
                new PrivateChatEntity()
                {
                    Id = Guid.Parse("e99beb51-6653-4079-aa32-0d896ea309ff"),
                    User1Id = Guid.Parse("6c0136a2-48d9-450f-9814-5cba270dce14"),
                    User2Id = Guid.Parse("46028997-952e-4f9c-9282-4ebd7526ea9c"),
                }
            );


        }
    }
}
