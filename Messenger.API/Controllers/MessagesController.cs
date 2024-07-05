using Messenger.API.Contracts;
using Messenger.Application.Services;
using Messenger.Core.Abstractions;
using Messenger.DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MessagesController : ControllerBase
	{
		private readonly IMessageService _messageService;

		public MessagesController(IMessageService messageService)
		{
			_messageService = messageService;
		}

		[Authorize]
		[HttpGet("GetMessages")]
		public async Task<ActionResult<List<MessageResponse>>> GetAllMessages()
		{
			var messages = await _messageService.GetAllMessages();

			var response = messages.Select(p => new MessageResponse(p.Id,p.SenderId,p.Content,p.Timestamp,p.Sender));
			return Ok(response);
		}
	}
}
