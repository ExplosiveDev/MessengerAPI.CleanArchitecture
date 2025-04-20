using Messenger.Application.Services;
using Messenger.Core.Models;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using Connection = Messenger.Core.Models.Connection;

namespace Messenger.API.Hubs
{
    public record sendMediaMessagePayload(string caption, string fileId, string senderId, string chatId);
    public record messagesReadedPayload(string chatId, string userId, List<string> messegeIds);
    public record removeChatPayload(string chatId, string userId);
    public interface IChatClient
    {
        public Task ReceiveMessage(Message message, int status);
        public Task ReceiveReadedMessageIds(IEnumerable<string> ids);
        public Task ReceiveSystemMessage(Message message);
        public Task ReceiveRemovedChatId(string chatId);
    }
    public class ChatHub : Hub<IChatClient>
    {
        private readonly IConnectionService _connectionService;
        private readonly IMessageService _messageService;

       public ChatHub(IConnectionService connectionService, IMessageService messageService)
        {
            _connectionService = connectionService;
            _messageService = messageService;
        }

        public async Task JoinChat(UserConnection connection)
        {

            await Groups.AddToGroupAsync(Context.ConnectionId, connection.chatRoom);
            var stringConnection = JsonSerializer.Serialize(connection);

            await _connectionService.CreateConnection(connection.User.Id, Context.ConnectionId, stringConnection);

        }

        public async Task SendTextMessage(TextMessage textMessage)
        {
            List<Connection> connections = await _connectionService.GetConnections(textMessage.ChatId);

            if (connections is not null)
            {          
                foreach (var connection in connections)
                {
                    await Clients.Client(connection.ConnectionId).ReceiveMessage(textMessage, 200);
                }
            }
        }

        public async Task SendMediaMessage(MediaMessage mediaMessage)
        {
            List<Connection> connections = await _connectionService.GetConnections(mediaMessage.ChatId);
            if (connections is not null)
            {
                foreach (var connection in connections)
                {
                    await Clients.Client(connection.ConnectionId).ReceiveMessage(mediaMessage, 200);
                }
            }
        }
        public async Task RemoveChat(removeChatPayload data)
        {
            Connection connection = await _connectionService.GetConnectionByUserId(data.userId);
            if (connection is not null) {
                await Clients.Client(connection.ConnectionId).ReceiveRemovedChatId(data.chatId);
            }
        }

        public async Task MessagesReaded(messagesReadedPayload data)
        {
            Guid userId = Guid.Parse(data.userId);
            List<Connection> connections = await _connectionService.GetConnections(Guid.Parse(data.chatId));
            if (connections is not null)
            {
                await _messageService.SetIsReaded(data.messegeIds);
                foreach (var connection in connections)
                {
                    if(connection.UserId != userId)
                        await Clients.Client(connection.ConnectionId).ReceiveReadedMessageIds(data.messegeIds);
                }
            }
        }


        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            Connection connections = await _connectionService.GetConnection(Context.ConnectionId);

            if (connections is null)
                return;

            var connection = JsonSerializer.Deserialize<UserConnection>(connections.StingConnection);

            if (connection is not null)
            {
                await _connectionService.DeleteConnection(connection.User.Id);
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, connection.chatRoom);
            }
        }
    }
}
