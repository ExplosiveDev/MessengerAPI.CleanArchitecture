namespace Messenger.API.Contracts
{
    public record SendMediaMessageRequest(
        string fileId,
        string caption,
        string chatId
        );
}
