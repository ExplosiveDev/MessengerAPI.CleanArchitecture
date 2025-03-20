using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.DataAccess.Entities;

namespace Messenger.Core.Models
{
	public class Chat
	{
        public Guid Id { get; set; }

		public ICollection<Message> Messages { get; set; } = [];
		public ICollection<UserChat> UserChats { get; set; } = [];
		public Message TopMessage { get; set; }
		public int UnReaded { get; set; }

    }
}
