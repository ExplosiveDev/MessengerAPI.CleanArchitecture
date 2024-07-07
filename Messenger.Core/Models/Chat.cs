using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Core.Models
{
	public class Chat
	{
        public Chat()
        {
            
        }
        public Chat(Guid id, string name, ICollection<Message> messages, ICollection<User> users)
        {
            Id = id;
			Name = name;
			Messages = messages; 
			Users = users;
        }

        public Guid Id { get; set; }
		public string Name { get; set; } = string.Empty;

		public ICollection<Message> Messages { get; set; } = [];
		public ICollection<User> Users { get; set; } = [];

		public static Chat Create(Guid id, string name, ICollection<Message> messages, ICollection<User> users)
		{
			var chat = new Chat(id, name, messages,users);

			return chat;
		}
	}
}
