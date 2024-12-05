using Messenger.Application.Services;
using Messenger.Core.Models;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Messenger.API.Hubs
{
	public record sendMessagePayload(string message, string senderUserId, string receiverUserId);
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

			await Clients.Group(connection.chatRoom).ReceiveSystemMessage(Message.Create(Guid.NewGuid(), $"{connection.User.Phone} connected to the chat", Guid.NewGuid(), Guid.NewGuid(),
				User.Create(Guid.NewGuid(), "Vlad", "+380964674274", "sdfsd", [], [], []).User, null, DateTime.UtcNow, []));
		}

		public async Task SendMessage(sendMessagePayload data)
		{
			Connection connection = await _connectionService.GetConnection(Guid.Parse(data.receiverUserId));
			var sender = await _userService.GetById(Guid.Parse(data.senderUserId));
			var receiver = await _userService.GetById(connection.UserId);

            if (connection is not null)
			{
				var message = Message.Create(Guid.NewGuid(), data.message, sender.Id, receiver.Id, 
					sender, receiver, DateTime.UtcNow, []);

                await Clients.Client(connection.ConnectionId).ReceiveMessage(message, 200);
                await Clients.Client(Context.ConnectionId).ReceiveMessage(message, 200);

                //await _messageService.AddMessage(message);
            }
		}

		//public async Task SendMessage((string message, string userId) data)
		//{
		//	Connection connections = await _connectionService.GetConnection(Context.ConnectionId);

		//	var connection = JsonSerializer.Deserialize<UserConnection>(connections.StingConnection);

		//	if (connection is not null)
		//	{
		//		await Clients.Group(connection.chatRoom).ReceiveMessage(Message.Create(Guid.NewGuid(), $"{connection.User.Phone} : {message}", Guid.NewGuid(),
		//		User.Create(Guid.NewGuid(), "Vlad", "+380964674274", "sdfsd", [], [], []).User, DateTime.UtcNow, []));
		//	}
		//}

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
				await Clients.Group(connection.chatRoom).
                    ReceiveSystemMessage(Message.Create(Guid.NewGuid(), $"{connection.User.Phone} Disconected from {connection.chatRoom}", Guid.NewGuid(), Guid.NewGuid(),
                    User.Create(Guid.NewGuid(), "Admin", "+380967777777", "sdfsd", [], [], []).User, null, DateTime.UtcNow, []));
			}
		}
	}
}
