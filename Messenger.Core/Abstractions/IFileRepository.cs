using Messenger.Core.Models;

namespace Messenger.DataAccess.Repositories
{
    public interface IFileRepository
    {
        Task<Guid> UploadFile(MyFile file);
    }
}