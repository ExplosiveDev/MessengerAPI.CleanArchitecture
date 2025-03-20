using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Core.Models
{
    public class PrivateChat : Chat
    {
        public Guid User1Id { get; set; }
        public User User1 { get; set; }
        public Guid User2Id { get; set; }
        public User User2 { get; set; }
    }
}
