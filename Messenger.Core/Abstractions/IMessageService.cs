using Messenger.Core.Models;

namespace Messenger.Application.Services
{
	public interface IMessageService
	{
		Task AddMessage(Message message);
		Task<List<Message>> GetAllMessages();
	}
}