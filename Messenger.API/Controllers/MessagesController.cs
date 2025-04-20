using Messenger.API.Contracts;
using Messenger.Application.Services;
using Messenger.Core.Abstractions;
using Messenger.Core.Models;
using Messenger.DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        [Authorize]
        [HttpPost("SendTextMessage")]
		public async Task<ActionResult<Message>> SendTextMessage([FromBody] SendTextMessageRequest data)
		{
            var userId = User.FindFirst("userId")?.Value;

            if (userId == null)
            {
                return Unauthorized("Invalid token");
            }

            var textMessage = await _messageService.AddTextMessage(data.content, data.chatId, userId);

            if (textMessage is null) return BadRequest();

            return Ok(textMessage);

        }

        [Authorize]
        [HttpPost("SendMediaMessage")]
        public async Task<ActionResult<Message>> SendMediaMessage([FromBody] SendMediaMessageRequest data)
        {
            var userId = User.FindFirst("userId")?.Value;

            if (userId == null)
            {
                return Unauthorized("Invalid token");
            }

            var mediaMessage = await _messageService.AddMediaMessage(data.caption, data.fileId, userId, data.chatId);


            if (mediaMessage is null) return BadRequest();

            return Ok(mediaMessage);

        }
    }
}
