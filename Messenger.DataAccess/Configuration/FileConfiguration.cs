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
    public class FileConfiguration : IEntityTypeConfiguration<FileEntity>
    {
        public void Configure(EntityTypeBuilder<FileEntity> builder)
        {
            builder.HasData(
                new FileEntity
                {
                    Id = Guid.Parse("beaac0ce-6668-4be8-a3a2-80f47544200d"),
                    FileName = "user.png",
                    FilePath = "wwwroot\\uploads\\user.png",
                    FileSize = 19456,
                    ContentType = "image/png",
                    URL = "http://192.168.0.100:5187/uploads/user.png",
                }
            );

        }
    }
}
