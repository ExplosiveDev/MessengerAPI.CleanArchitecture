namespace Messenger.API.Contracts
{
    public record RemoveMemberRequest(
        string memberId,
        string chatId
        );
}
