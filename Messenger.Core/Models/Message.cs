using System;

namespace Messenger.Core.Models
{
	public class Message
	{
        public Message()
        {
            
        }
        protected Message(Guid id, string content, Guid userId, User user, DateTime timestamp, ICollection<Chat> chats)
		{
			Id = id;
			Content = content;
			Timestamp = timestamp;
			SenderId = userId;
			Sender = user;
			Chats = chats;
		}

		public Guid Id { get; set; }
		public string Content { get; set; }
		public DateTime Timestamp { get; set; }

		public Guid SenderId { get; set; }
		public User Sender { get; set; }
		public ICollection<Chat> Chats { get; set; } = [];

		public static Message Create(Guid id, string content, Guid userId, User user, DateTime timestamp, ICollection<Chat> chats)
		{
			var message = new Message(id, content, userId, user, timestamp,chats);
			return message;
		}
	}
}