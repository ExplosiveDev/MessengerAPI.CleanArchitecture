using Messenger.API.Contracts;
using Messenger.Application.Services;
using Messenger.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatsController : ControllerBase
    {
        private readonly IChatService _chatService;
        public ChatsController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [Authorize]
        [HttpGet("GetGlobalChatsByName")]
        public async Task<ActionResult<SearchedChats>> GetGlobalChatsByName([FromQuery] string name)
        {
            var userId = User.FindFirst("userId")?.Value;

            if (userId == null)
            {
                return Unauthorized("Invalid token");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Search name cannot be empty");
            }

            var searchedGlobalChats = await _chatService.GetGlobalChatsByName(Guid.Parse(userId), name);

            return Ok(searchedGlobalChats);
        }

        [Authorize]
        [HttpGet("GetSavedChats")]
        public async Task<ActionResult<SearchedChats>> GetSavedChats()
        {
            var userId = User.FindFirst("userId")?.Value;

            if (userId == null)
            {
                return Unauthorized("Invalid token");
            }

            var savedChats = await _chatService.GetSavedChats(Guid.Parse(userId));

            return Ok(savedChats);
        }
    }
}
