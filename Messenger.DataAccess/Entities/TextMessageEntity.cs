using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Entities
{
    public class TextMessageEntity : MessageEntity
    {
        public string Content { get; set; }
    }
}
