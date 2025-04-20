using Messenger.API.Contracts;
using Messenger.Application.Services;
using Messenger.Core.Models;
using Messenger.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

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


        [Authorize]
        [HttpGet("GetChat")]
        public async Task<ActionResult<Chat>> GetChat([FromQuery] string chatId)
        {
            var userId = User.FindFirst("userId")?.Value;
            if (userId == null)
            {
                return Unauthorized("Invalid token");
            }
            var chat = await _chatService.GetChat(Guid.Parse(chatId), Guid.Parse(userId));

            return Ok(chat);
        }

        [Authorize]
        [HttpPost("CreatePrivateChat")]
        public async Task<ActionResult<PrivateChat>> CreatePrivateChat([FromQuery] string user2Id)
        {
            var userId = User.FindFirst("userId")?.Value;

            if (userId == null)
            {
                return Unauthorized("Invalid token");
            }
            var privateChat = await _chatService.CreatePrivateChat(Guid.Parse(userId), Guid.Parse(user2Id));

            if (privateChat == null) return BadRequest("One or both users do not exist.");

            return privateChat;

        }

        [Authorize]
        [HttpPost("CreateGroupChat")]
        public async Task<ActionResult<GroupChat>> CreateGroupChat([FromBody] CreateGroupChatRequest createGroupChatRequest)
        {
            var userId = User.FindFirst("userId")?.Value;

            if (userId == null)
            {
                return Unauthorized("Invalid token");
            }
            List<string> userIds = createGroupChatRequest.selectedContacts.ToList();
            var groupName = createGroupChatRequest.groupName;

            var groupChat = await _chatService.CreateGroupChat(userId, userIds, groupName);

            return Ok(groupChat);
        }

        [Authorize]
        [HttpPost("RemoveMember")]
        public async Task<ActionResult> RemoveMember([FromBody] RemoveMemberRequest data)
        {
            var userId = User.FindFirst("userId")?.Value;

            if (userId == null)
            {
                return Unauthorized("Invalid token");
            }

            if(await _chatService.IsChatOwner(userId, data.chatId))
            {
                var memberGuid = await _chatService.RemoveMember(data.memberId, data.chatId);
                if(memberGuid != Guid.Empty) return Ok(memberGuid);
            }

            return BadRequest();
        }

    }
}
