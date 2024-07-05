using Messenger.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Entities
{
	public class MessageEntity
	{
		public Guid Id { get; set; }
		public string Content { get; set; } = string.Empty;
		public DateTime Timestamp { get; set; }

		public Guid SenderId { get; set; }
		public UserEntity Sender { get; set; }
		public ICollection<ChatEntity> Chats { get; set; } = [];
	}
}
