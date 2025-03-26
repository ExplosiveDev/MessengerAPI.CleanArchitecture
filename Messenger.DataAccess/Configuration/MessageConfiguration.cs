using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Messenger.DataAccess.Entities;
using System;
using System.Reflection.Emit;

namespace Messenger.DataAccess.Configuration
{
	public class MessageConfiguration : IEntityTypeConfiguration<MessageEntity>
	{
		public void Configure(EntityTypeBuilder<MessageEntity> builder)
		{
			builder
				.HasKey(m => m.Id);


			builder
				.HasOne(m => m.Sender)
				.WithMany()
				.HasForeignKey(m => m.SenderId)
				.OnDelete(DeleteBehavior.NoAction);

            builder
				.HasOne(m => m.Chat)
				.WithMany(c => c.Messages)
				.HasForeignKey(m => m.ChatId);




            //builder.HasData(
            //	new MessageEntity
            //	{
            //		Id = Guid.NewGuid(),
            //		Content = "Hello, how are you?",
            //		Timestamp = DateTime.UtcNow,
            //		SenderId = Guid.Parse("6c0136a2-48d9-450f-9814-5cba270dce14"),
            //		ReceiverId = Guid.Parse("57322de4-860d-4c50-950a-0e88f87d096c")

            //	},
            //	new MessageEntity
            //	{
            //		Id = Guid.NewGuid(),
            //		Content = "I'm good, thanks!",
            //		Timestamp = DateTime.UtcNow,
            //		SenderId = Guid.Parse("57322de4-860d-4c50-950a-0e88f87d096c"),
            //                 ReceiverId = Guid.Parse("6c0136a2-48d9-450f-9814-5cba270dce14")
            //             },
            //	new MessageEntity
            //	{
            //		Id = Guid.NewGuid(),
            //		Content = "What's new?",
            //		Timestamp = DateTime.UtcNow,
            //		SenderId = Guid.Parse("6c0136a2-48d9-450f-9814-5cba270dce14"),
            //		ReceiverId = Guid.Parse("57322de4-860d-4c50-950a-0e88f87d096c")
            //	},
            //	new MessageEntity
            //	{
            //		Id = Guid.NewGuid(),
            //		Content = "Not much, just working on a project.",
            //		Timestamp = DateTime.UtcNow,
            //		SenderId = Guid.Parse("57322de4-860d-4c50-950a-0e88f87d096c"),
            //                 ReceiverId = Guid.Parse("6c0136a2-48d9-450f-9814-5cba270dce14")
            //             },
            //	new MessageEntity
            //	{
            //		Id = Guid.NewGuid(),
            //		Content = "Sounds interesting, tell me more!",
            //		Timestamp = DateTime.UtcNow,
            //		SenderId = Guid.Parse("6c0136a2-48d9-450f-9814-5cba270dce14"),
            //                 ReceiverId = Guid.Parse("57322de4-860d-4c50-950a-0e88f87d096c")
            //             },
            //	new MessageEntity
            //	{
            //		Id = Guid.NewGuid(),
            //		Content = "It's a web app with a real-time chat feature.",
            //		Timestamp = DateTime.UtcNow,
            //		SenderId = Guid.Parse("57322de4-860d-4c50-950a-0e88f87d096c"),
            //                 ReceiverId = Guid.Parse("6c0136a2-48d9-450f-9814-5cba270dce14")
            //             },
            //	new MessageEntity
            //	{
            //		Id = Guid.NewGuid(),
            //		Content = "Cool! What stack are you using?",
            //		Timestamp = DateTime.UtcNow,
            //		SenderId = Guid.Parse("6c0136a2-48d9-450f-9814-5cba270dce14"),
            //                 ReceiverId = Guid.Parse("57322de4-860d-4c50-950a-0e88f87d096c")
            //             },
            //	new MessageEntity
            //	{
            //		Id = Guid.NewGuid(),
            //		Content = "I'm using ASP.NET Core for the backend and React for the frontend.",
            //		Timestamp = DateTime.UtcNow,
            //		SenderId = Guid.Parse("57322de4-860d-4c50-950a-0e88f87d096c"),
            //                 ReceiverId = Guid.Parse("6c0136a2-48d9-450f-9814-5cba270dce14")
            //             },
            //	new MessageEntity
            //	{
            //		Id = Guid.NewGuid(),
            //		Content = "Nice choice! Let me know if you need help.",
            //		Timestamp = DateTime.UtcNow,
            //		SenderId = Guid.Parse("6c0136a2-48d9-450f-9814-5cba270dce14"),
            //                 ReceiverId = Guid.Parse("57322de4-860d-4c50-950a-0e88f87d096c")
            //             },
            //	new MessageEntity
            //	{
            //		Id = Guid.NewGuid(),
            //		Content = "Thanks! I'll keep that in mind.",
            //		Timestamp = DateTime.UtcNow,
            //		SenderId = Guid.Parse("57322de4-860d-4c50-950a-0e88f87d096c"),
            //		ReceiverId = Guid.Parse("6c0136a2-48d9-450f-9814-5cba270dce14")
            //             }
            //);
        }
    }
}
