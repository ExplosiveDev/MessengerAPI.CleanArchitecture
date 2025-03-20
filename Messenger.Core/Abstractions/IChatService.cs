using Messenger.Core.Models;

namespace Messenger.Application.Services
{
    public interface IChatService
    {
        Task<SearchedChats> GetGlobalChatsByName(Guid currentUserId, string name);

        Task<SearchedChats> GetSavedChats(Guid userId);
        Task<PrivateChat> CreatePrivateChat(Guid user1Id, Guid user2Id);
    }
}