using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Core.Models
{
    public class SearchedMessages
    {
        public List<TextMessage> TextMessages { get; set; }
        public List<MediaMessage> MediaMessages { get; set; }
    }
}
