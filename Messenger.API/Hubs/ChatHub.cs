using Messenger.Core.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Text.RegularExpressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Messenger.API.Hubs
{
	public interface IChatClient
	{
		public Task ReceiveMessage(Message message);
	}
	public class ChatHub : Hub<IChatClient>
	{
		private static Dictionary<string, string> connections = new Dictionary<string, string>();

		public async Task JoinChat(UserConnection connection)
		{

			await Groups.AddToGroupAsync(Context.ConnectionId, connection.chatRoom);
			var stringConnection = JsonSerializer.Serialize(connection);

			connections.Add(Context.ConnectionId, stringConnection);

			await Clients.Group(connection.chatRoom).ReceiveMessage(Message.Create(Guid.NewGuid(), $"{connection.User.Phone} connected to the chat", Guid.NewGuid(),
				User.Create(Guid.NewGuid(), "Vlad", "+380964674274", "sdfsd", [], [], []).User, DateTime.UtcNow, []));
		}

		public async Task SendMessage(string message)
		{
			var stingConnection = connections[Context.ConnectionId];
			var connection = JsonSerializer.Deserialize<UserConnection>(stingConnection);

			if (connection is not null)
			{
				await Clients.Group(connection.chatRoom).ReceiveMessage(Message.Create(Guid.NewGuid(), $"{connection.User.Phone} : Write message", Guid.NewGuid(),
				User.Create(Guid.NewGuid(), "Vlad", "+380964674274", "sdfsd", [], [], []).User, DateTime.UtcNow, []));
			}
		}

		public override async Task OnDisconnectedAsync(Exception? exception)
		{
			var stingConnection = connections[Context.ConnectionId];
			var connection = JsonSerializer.Deserialize<UserConnection>(stingConnection);

			if (connection is not null)
			{
				connections.Remove(Context.ConnectionId);
				await Groups.RemoveFromGroupAsync(Context.ConnectionId, connection.chatRoom);
				await Clients.Group(connection.chatRoom).
					ReceiveMessage(Message.Create(Guid.NewGuid(), $"{connection.User.Phone} Disconected from {connection.chatRoom}", Guid.NewGuid(),
					User.Create(Guid.NewGuid(), "Admin", "+380967777777", "sdfsd", [], [], []).User, DateTime.UtcNow, []));
			}
		}
	}
}
