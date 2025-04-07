using Messenger.Core.Models;

namespace Messenger.DataAccess.Repositories
{
    public interface IFileRepository
    {
        Task<MyFile> UploadAvatar(MyFile file);
        Task<Guid> UploadFile(MyFile file);
    }
}