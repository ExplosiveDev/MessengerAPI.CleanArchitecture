using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.DataAccess.Entities;

namespace Messenger.Core.Models
{
    public class SearchedChats
    {
        public List<PrivateChat> PrivateChats { get; set; }
        public List<GroupChat> GroupChats { get; set; }
    }
}
