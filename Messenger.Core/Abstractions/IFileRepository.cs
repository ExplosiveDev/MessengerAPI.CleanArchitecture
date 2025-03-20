using Messenger.Core.Models;

namespace Messenger.DataAccess.Repositories
{
    public interface IFileRepository
    {
        Task<Message> AddPhotosToMessage(Guid messageId, Guid photoId);
        Task<Guid> UploadFile(MyFile file);
    }
}