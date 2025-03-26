using Messenger.API.Contracts;
using Messenger.Application.Services;
using Messenger.Core.Abstractions;
using Messenger.Core.Models;
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
        [HttpGet("GetMessagesByChat")]
        public async Task<ActionResult<List<Message>>> GetMessagesByChatId([FromQuery] string chatId)
        {
            var messages = await _messageService.GetMessagesByChatId(Guid.Parse(chatId));
			if (messages is null)
				return BadRequest(new { message = "No messages or no chat is exist" });
            return Ok(messages);
        }
    }
}
