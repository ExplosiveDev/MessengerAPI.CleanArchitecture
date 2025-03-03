using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Core.Models;

namespace Messenger.Core.Abstractions
{
    public interface IUserMessageRepository
    {
        public Task Add(Message message);
    }
}
