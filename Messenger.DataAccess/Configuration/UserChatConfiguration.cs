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
    public class UserChatConfiguration : IEntityTypeConfiguration<UserChatEntity>
    {
        public void Configure(EntityTypeBuilder<UserChatEntity> builder)
        {
            builder
                .HasKey(uc => new { uc.UserId, uc.ChatId });

            builder
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserChats)
                .HasForeignKey(uc => uc.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(uc => uc.Chat)
                .WithMany(m => m.UserChats)
                .HasForeignKey(uc => uc.ChatId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                    new UserChatEntity
                    {
                        UserId = Guid.Parse("6c0136a2-48d9-450f-9814-5cba270dce14"),
                        ChatId = Guid.Parse("a2872c6e-2e30-4566-9ab4-1515be72b7c5")
                    },
                    new UserChatEntity
                    {
                        UserId = Guid.Parse("57322de4-860d-4c50-950a-0e88f87d096c"),
                        ChatId = Guid.Parse("a2872c6e-2e30-4566-9ab4-1515be72b7c5")
                    },
                    new UserChatEntity
                    {
                        UserId = Guid.Parse("6c0136a2-48d9-450f-9814-5cba270dce14"),
                        ChatId = Guid.Parse("53d3f541-fa16-47f6-9e95-1e1cba92419e")
                    },
                    new UserChatEntity
                    {
                        UserId = Guid.Parse("f9a74d03-b637-4787-bdf2-930eff19c944"),
                        ChatId = Guid.Parse("53d3f541-fa16-47f6-9e95-1e1cba92419e")
                    },
                    new UserChatEntity
                    {
                        UserId = Guid.Parse("6c0136a2-48d9-450f-9814-5cba270dce14"),
                        ChatId = Guid.Parse("e99beb51-6653-4079-aa32-0d896ea309ff")
                    }, 
                    new UserChatEntity
                    {
                        UserId = Guid.Parse("46028997-952e-4f9c-9282-4ebd7526ea9c"),
                        ChatId = Guid.Parse("e99beb51-6653-4079-aa32-0d896ea309ff")
                    }
                );
        }


    }
}
