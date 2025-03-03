using Messenger.Application.Services;
using Messenger.Core.Models;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Messenger.API.Hubs
{
    public record sendMessagePayload(string content, string senderId, string chatId);
    public interface IChatClient
    {
        public Task ReceiveMessage(Message message, int status);
        public Task ReceiveSystemMessage(Message message);
    }
    public class ChatHub : Hub<IChatClient>
    {
        private readonly IConnectionService _connectionService;
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;

        public ChatHub(IConnectionService connectionService, IUserService userService, IMessageService messageService)
        {
            _connectionService = connectionService;
            _userService = userService;
            _messageService = messageService;
        }

        public async Task JoinChat(UserConnection connection)
        {

            await Groups.AddToGroupAsync(Context.ConnectionId, connection.chatRoom);
            var stringConnection = JsonSerializer.Serialize(connection);

            await _connectionService.CreateConnection(connection.User.Id, Context.ConnectionId, stringConnection);

        }

        public async Task SendMessage(sendMessagePayload data)
        {
            List<Connection> connections = await _connectionService.GetConnections(Guid.Parse(data.chatId));
            var sender = await _userService.GetById(Guid.Parse(data.senderId));

            if (connections is not null)
            {

                var message = await _messageService.AddMessage(data.content, Guid.Parse(data.chatId), Guid.Parse(data.senderId));
                foreach (var connection in connections)
                {
                    await Clients.Client(connection.ConnectionId).ReceiveMessage(message, 200);
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
