using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Core.Models;

namespace Messenger.DataAccess.Entities
{
    public class GroupChat : Chat
    {
        public string GroupName { get; set; }
        public Guid AdminId { get; set; }
        public User Admin { get; set; }
        public Guid? ActiveIconId { get; set; }
        public MyFile? ActiveIcon { get; set; }
    }
}
