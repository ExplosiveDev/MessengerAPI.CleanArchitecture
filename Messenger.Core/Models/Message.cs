using System;

namespace Messenger.Core.Models
{
	public class Message
	{
		protected Message(Guid id, string content, Guid userId, User user, DateTime timestamp)
		{
			Id = id;
			Content = content;
			Timestamp = timestamp;
			SenderId = userId;
			Sender = user;
		}

		public Guid Id { get; set; }
		public string Content { get; set; }
		public DateTime Timestamp { get; set; }
		public Guid SenderId { get; set; }
		public User Sender { get; set; }

		public static Message Create(Guid id, string content, Guid userId, User user, DateTime timestamp)
		{
			var message = new Message(id, content, userId, user, timestamp);
			return message;
		}
	}
}