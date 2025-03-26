using System;
using System.Text.Json.Serialization;

namespace Messenger.Core.Models
{
	public class Message
	{
        public Message()
        {
            
        }
        protected Message
			(Guid id, Guid userId, User user, Guid chatId, Chat chat, string timestamp)
		{
			Id = id;
			Timestamp = timestamp;
			SenderId = userId;
			Sender = user;
			ChatId = chatId;
			Chat = chat;
		}

		public Guid Id { get; set; }
		public string Timestamp { get; set; }

		public Guid SenderId { get; set; }
        [JsonIgnore] // або міняти налаштування Json.SerializerSettings -> options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        public User Sender { get; set; }
        public Guid ChatId { get; set; }
        [JsonIgnore] // або міняти налаштування Json.SerializerSettings -> options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        public Chat Chat { get; set; }
		public bool isReaded { get; set; } = false;

        public static Message Create
			(Guid id, Guid senderId, User sender, Guid chatId, Chat chat, string timestamp)
		{
			var message = new Message(id, senderId, sender, chatId, chat, timestamp);
			return message;
		}
	}
}