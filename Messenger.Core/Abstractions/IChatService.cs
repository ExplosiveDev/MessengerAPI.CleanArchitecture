using Messenger.Core.Models;

namespace Messenger.Application.Services
{
    public interface IChatService
    {
        Task<SearchedChats> GetGlobalChatsByName(Guid currentUserId, string name);

        Task<SearchedChats> GetSavedChats(Guid userId);
    }
}