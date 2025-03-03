using Messenger.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Entities
{
	public abstract class ChatEntity
	{
		public Guid Id { get; set; }

		public ICollection<MessageEntity> Messages { get; set; } = [];
		public ICollection<UserChatEntity> UserChats { get; set; } = [];
	}
}
