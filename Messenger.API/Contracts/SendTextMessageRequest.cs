namespace Messenger.API.Contracts
{
    public record SendTextMessageRequest(
        string content, 
        string chatId
        );
}
