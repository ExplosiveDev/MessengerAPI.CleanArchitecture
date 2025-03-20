using Messenger.Core.Models;

namespace Messenger.Application.Services
{
    public interface IFileService
    {
        Task<Guid> Upload(MyFile file);
    }
}