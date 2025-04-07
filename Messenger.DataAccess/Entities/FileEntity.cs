using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Entities
{
    public class FileEntity
    {
        public Guid Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty; // Шлях до файлу на сервері
        public string URL { get; set; } = string.Empty; // Шлях до файлу на сервері
        public long FileSize { get; set; } 
        public string ContentType { get; set; } = string.Empty; // MIME-тип

        public Guid? MediaMessageId { get; set; }
        public MediaMessageEntity? MediaMessage { get; set; }
        public Guid? UserId { get; set; }
        public UserEntity? User { get; set; }
    }

}
