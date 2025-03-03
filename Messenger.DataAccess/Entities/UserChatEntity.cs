using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Core.Models;

namespace Messenger.DataAccess.Entities
{
    public class UserChatEntity
    {
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public Guid ChatId { get; set; }
        public ChatEntity Chat { get; set; }
    }
}
