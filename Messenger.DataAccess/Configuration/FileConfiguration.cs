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
    public class FileConfiguration : IEntityTypeConfiguration<FileEntity>
    {
        public void Configure(EntityTypeBuilder<FileEntity> builder)
        {
            builder
                .HasOne(f => f.User)
                .WithMany(u => u.Avatars) 
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(f => f.GroupChat)
                .WithMany(g => g.GroupIcons)
                .HasForeignKey(f => f.GroupChatId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasData(
                new FileEntity
                {
                    Id = Guid.Parse("a7674d3f-d622-4656-9499-d46e0c7ea61a"),
                    FileName = "user.png",
                    FilePath = "wwwroot\\uploads\\user.png",
                    FileSize = 19456,
                    ContentType = "image/png",
                    URL = "http://192.168.0.100:5187/uploads/user.png",
                },
                new FileEntity
                {
                    Id = Guid.Parse("813c1973-8109-44e8-b583-b4a26452ea6e"),
                    FileName = "groups.png",
                    FilePath = "wwwroot\\uploads\\groups.png",
                    FileSize = 19000,
                    ContentType = "image/png",
                    URL = "http://192.168.0.100:5187/uploads/groups.png",
                }
            );

        }
    }
}
