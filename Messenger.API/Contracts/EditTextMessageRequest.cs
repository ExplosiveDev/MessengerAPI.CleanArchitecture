namespace Messenger.API.Contracts
{
    public record EditTextMessageRequest(
        string textMessageId,
        string newTextMessageContent
        );
}
