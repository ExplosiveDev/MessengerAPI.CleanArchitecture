using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Core.Models
{
    public class MyFile
    {
        public Guid Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty; // Шлях до файлу на сервері
        public long FileSize { get; set; }
        public string ContentType { get; set; } = string.Empty; // MIME-тип

        public Guid MessageId { get; set; }
        public Message Message { get; set; }
    }
}
