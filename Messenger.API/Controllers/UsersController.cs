using AutoMapper;
using Messenger.API.Contracts;
using Messenger.Application.Services;
using Messenger.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Messenger.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly IHttpContextAccessor _context;
		private readonly IMapper _mapper;

		public UsersController(IUserService userService, IHttpContextAccessor context, IMapper mapper)
		{
			_userService = userService;
			_context = context;
			_mapper = mapper;
		}

		[HttpPost("register")]
		public async Task<ActionResult> Register([FromBody] RegisterUserRequest request)
		{
			if (!_userService.IsUniquePhone(request.Phone).Result)
				return BadRequest(new { message = "this phone is already use" });

			var cortage = await _userService.Register(request.UserName, request.Phone, request.Password);

			if (string.IsNullOrEmpty(cortage.error))
				return Ok();
			else
				return BadRequest(cortage.error);
		}

		[HttpPost("login")]
		public async Task<ActionResult> Login([FromBody] LoginUserRequest request)
		{
			var cortage = await _userService.Login(request.Phone, request.Password);

			if (string.IsNullOrEmpty(cortage.token))
				return BadRequest(new { message = "User name or password is incorrect " });

			LoginUserResponse respons = new LoginUserResponse(cortage.user, cortage.token);
			return Ok(respons);
		}

		[HttpPost("SearchUser")]
		public async Task<ActionResult<List<UserResponse>>> SearchUserByUserName([FromBody] string searchChat)
		{
			var users = await _userService.SearchByUserName(searchChat);

			if (users == null)
				return BadRequest(new { message = "User name is incorrect " });

			var response = _mapper.Map<List<UserResponse>>(users);
			return Ok(response);
		}


		[Authorize]
		[HttpGet("GetContacts")]
        public async Task<ActionResult<List<User>>> GetContacts()
		{
            var userId = User.FindFirst("userId")?.Value;

            if (userId == null)
            {
                return Unauthorized("Invalid token");
            }

			var contacts = await _userService.GetContacts(Guid.Parse(userId));

			if (contacts == null) return BadRequest(new { message = "Smth went wrong..." });

            return Ok(contacts);
        }



    }
}
