using Messenger.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Entities
{
	public class ChatEntity
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = string.Empty;

		public ICollection<MessageEntity> Messages { get; set; } = [];
		public ICollection<UserEntity> Users { get; set; } = [];
	}
}
