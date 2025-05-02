namespace Messenger.API.Contracts
{
    public record AddMembersRequest(
        string[] memberIds,
        string chatId
    );
}
