using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Entities
{
    public class MediaMessageEntity : MessageEntity
    {
        public List<FileEntity> Content { get; set; }
        public string Caption { get; set; }
        public string MediaType { get; set; }
    }
}
