using System;

namespace Messenger.Core.Models
{
	public class Message
	{
        public Message()
        {
            
        }
        protected Message(Guid id, string content, Guid userId, Guid receiverId, User user, User reveiver, DateTime timestamp, ICollection<Chat> chats)
		{
			Id = id;
			Content = content;
			Timestamp = timestamp;
            ReceiverId = receiverId;
			SenderId = userId;
			Sender = user;
            Receive = reveiver;
            Chats = chats;
		}

		public Guid Id { get; set; }
		public string Content { get; set; }
		public DateTime Timestamp { get; set; }

		public Guid SenderId { get; set; }
		public Guid ReceiverId { get; set; }
		public User Sender { get; set; }
		public User Receive { get; set; }
		public ICollection<Chat> Chats { get; set; } = [];

		public static Message Create(Guid id, string content, Guid userId, Guid receiverId, User user, User reveiver, DateTime timestamp, ICollection<Chat> chats)
		{
			var message = new Message(id, content, userId, receiverId, user, reveiver, timestamp,chats);
			return message;
		}
	}
}