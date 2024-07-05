using Messenger.API.Contracts;
using Messenger.Application.Services;
using Messenger.Core.Models;
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
		public UsersController(IUserService userService, IHttpContextAccessor context)
		{
			_userService = userService;
			_context = context;
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
			
			if(string.IsNullOrEmpty(cortage.token)) 
				return BadRequest(new {message = "User name or password is incorrect "});

			LoginUserResponse respons = new LoginUserResponse(cortage.user,cortage.token);
			return Ok(respons);
		}
	}
}
