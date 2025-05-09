﻿using Messenger.Core.Models;
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
		public DateTime Timestamp { get; set; }

        public Guid SenderId { get; set; }
        public UserEntity Sender { get; set; }

        public Guid ChatId { get; set; }
        public ChatEntity Chat { get; set; }

		public bool IsReaded { get; set; }
    }
}
