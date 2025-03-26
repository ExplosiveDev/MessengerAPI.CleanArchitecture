using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Core.Models
{
    public class MediaMessage : Message
    {
        public List<MyFile> Content { get; set; }
        public string Caption { get; set; }
        public string MediaType { get; set; }
    }
}
