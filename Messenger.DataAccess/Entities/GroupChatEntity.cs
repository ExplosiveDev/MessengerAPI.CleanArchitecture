using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Core.Models;

namespace Messenger.DataAccess.Entities
{
    public class GroupChatEntity : ChatEntity
    {
        public string GroupName { get; set; }
        public Guid AdminId { get; set; }
        public UserEntity Admin { get; set; }
    }
}
