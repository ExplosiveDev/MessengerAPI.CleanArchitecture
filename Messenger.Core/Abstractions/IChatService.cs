using Messenger.Core.Models;
using Messenger.DataAccess.Entities;

namespace Messenger.Application.Services
{
    public interface IChatService
    {
        Task<SearchedChats> GetGlobalChatsByName(Guid currentUserId, string name);

        Task<SearchedChats> GetSavedChats(Guid userId);
        Task<PrivateChat> CreatePrivateChat(Guid user1Id, Guid user2Id);
        Task<GroupChat> CreateGroupChat(string ownerId, List<string> userIds, string groupName);
        Task<Chat> GetChat(Guid chatId, Guid userId);
        Task<bool> IsChatOwner(string userId, string chatId);
        Task<Guid> RemoveMember(string memberId, string chatId);
    }
}