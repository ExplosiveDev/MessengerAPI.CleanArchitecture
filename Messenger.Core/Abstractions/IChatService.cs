using Messenger.Core.Models;
using Messenger.DataAccess.Entities;

namespace Messenger.Application.Services
{
    public interface IChatService
    {
        Task<SearchedChats> GetGlobalChatsByName(string currentUserId, string name);
        Task<SearchedChats> GetSavedChats(string userId);
        Task<PrivateChat> CreatePrivateChat(string user1Id, string user2Id);
        Task<GroupChat> CreateGroupChat(string ownerId, List<string> userIds, string groupName);
        Task<Chat> GetChat(string chatId, string userId);
        Task<bool> IsChatOwner(string userId, string chatId);
        Task<Guid> RemoveMember(string memberId, string chatId);
        Task<List<User>> AddMembers(string[] memberIds, string chatId);
        Task<string> ChangeChatName(string newChatName, string chatId);
    }
}