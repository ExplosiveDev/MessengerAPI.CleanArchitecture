using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Core.Models;

namespace Messenger.DataAccess.Entities
{
    public class PrivateChatEntity : ChatEntity
    {
        public Guid User1Id { get; set; }
        public UserEntity User1 { get; set; }
        public Guid User2Id { get; set; }
        public UserEntity User2 { get; set; }
    }
}
