using Messenger.Core.Models;

namespace Messenger.DataAccess.Repositories
{
    public interface IChatRepository
    {
        Task<SearchedChats> GetGlobalChatsByName(Guid currentUserId, string name);
        Task<SearchedChats> GetSavedChats(Guid userId);
        Task<Chat> Get(Guid chatId, Guid userId);
        Task<Chat> Get(Guid chatId);
        Task<PrivateChat> CreatePrivateChat(Guid user1Id, Guid user2Id);
    }
}