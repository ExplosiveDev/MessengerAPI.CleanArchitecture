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
    public record sendTextMessagePayload(string content, string senderId, string chatId);
    public record sendMediaMessagePayload(string caption, string fileId, string senderId, string chatId);
    public record messagesReadedPayload(string chatId, string userId, List<string> messegeIds);
    public interface IChatClient
    {
        public Task ReceiveMessage(Message message, int status);
        public Task ReceiveReadedMessageIds(IEnumerable<string> ids);
        public Task ReceiveSystemMessage(Message message);
    }
    public class ChatHub : Hub<IChatClient>
    {
        private readonly IConnectionService _connectionService;
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;
        private readonly IFileService _fileService;

       public ChatHub(IConnectionService connectionService, IUserService userService, IMessageService messageService, IFileService fileService)
        {
            _connectionService = connectionService;
            _userService = userService;
            _messageService = messageService;
            _fileService = fileService;
        }

        public async Task JoinChat(UserConnection connection)
        {

            await Groups.AddToGroupAsync(Context.ConnectionId, connection.chatRoom);
            var stringConnection = JsonSerializer.Serialize(connection);

            await _connectionService.CreateConnection(connection.User.Id, Context.ConnectionId, stringConnection);

        }

        public async Task SendTextMessage(sendTextMessagePayload data)
        {
            List<Connection> connections = await _connectionService.GetConnections(Guid.Parse(data.chatId));
            var sender = await _userService.GetById(Guid.Parse(data.senderId));

            if (connections is not null)
            {

                var textMessage = await _messageService.AddTextMessage(data.content, Guid.Parse(data.chatId), Guid.Parse(data.senderId));
                foreach (var connection in connections)
                {
                    await Clients.Client(connection.ConnectionId).ReceiveMessage(textMessage, 200);
                }
            }
        }

        public async Task SendMediaMessage(sendMediaMessagePayload data)
        {
            List<Connection> connections = await _connectionService.GetConnections(Guid.Parse(data.chatId));
            var sender = await _userService.GetById(Guid.Parse(data.senderId));
            if (connections is not null)
            {

                var mediaMessage = await _messageService.AddMediaMessage(data.caption, Guid.Parse(data.fileId), Guid.Parse(data.senderId), Guid.Parse(data.chatId));
                foreach (var connection in connections)
                {
                    await Clients.Client(connection.ConnectionId).ReceiveMessage(mediaMessage, 200);
                }
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
