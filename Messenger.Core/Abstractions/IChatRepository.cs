using Messenger.Core.Models;
using Messenger.DataAccess.Entities;

namespace Messenger.DataAccess.Repositories
{
    public interface IChatRepository
    {
        Task<(Message, int)> GetLastMessageAndCountOfUnreaded(Guid chatId, Guid userId);
        Task<Chat> Get(Guid chatId);
        Task<PrivateChat> CreatePrivateChat(Guid user1Id, Guid user2Id);
        Task<GroupChat> CreateGroupChat(Guid ownerId, string groupName);
        Task<bool> IsChatOwner(Guid userId, Guid chatId);
        Task<Guid> RemoveMember(Guid memberId, Guid chatId);
        Task<string> ChangeChatName(string newChatName, Guid chatId);
        Task<List<Guid>> GetChatUserIds(Guid chatId);
        Task<List<Guid>> GetUserChatIds(Guid userId);
        Task AddMembers(Guid chatId, List<Guid> userIds);
        Task<bool> IsChatExists(Guid chatId);
        Task<bool> IsChatMember(Guid chatId, Guid userId);
        Task<List<PrivateChat>> GetPrivateChats(List<Guid> chatIds);
    }
}