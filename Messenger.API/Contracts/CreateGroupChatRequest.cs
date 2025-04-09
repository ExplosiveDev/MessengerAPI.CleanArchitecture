namespace Messenger.API.Contracts
{ 
    public record CreateGroupChatRequest(
        string[] selectedContacts,
        string groupName
        );
}
