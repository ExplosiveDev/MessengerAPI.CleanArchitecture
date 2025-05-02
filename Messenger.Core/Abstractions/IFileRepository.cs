using Messenger.Core.Models;

namespace Messenger.DataAccess.Repositories
{
    public interface IFileRepository
    {
        Task<bool> IsFileExists(Guid fileId);
        Task<MyFile> UploadAvatar(MyFile file);
        Task<Guid> UploadFile(MyFile file);
    }
}