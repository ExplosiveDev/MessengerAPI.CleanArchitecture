namespace Messenger.API.Contracts
{
    public record ChangeChatNameRequest(
        string newName,
        string chatId
    );
}
