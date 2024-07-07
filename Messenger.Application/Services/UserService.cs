using Messenger.Core.Abstractions;
using Messenger.Core.Models;
using Messenger.DataAccess.Repositories;
using Messenger.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Application.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IPasswordHasher _passwordHasher;
		private readonly IJwtProvider _jwtProvider;

		public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
		{
			_userRepository = userRepository;
			_passwordHasher = passwordHasher;
			_jwtProvider = jwtProvider;
		}

		public async Task<(User user, string error)> Register(string userName, string phone, string password)
		{
			var hashedPassword = _passwordHasher.Generate(password);

			var user = User.Create(Guid.NewGuid(), userName, phone, hashedPassword, new[] {"User"}, [], []);

			if (user.Error == string.Empty)
				await _userRepository.Add(user.User);

			return user;
		}

		public async Task<(User user, string token)> Login(string phone, string password)
		{
			var user = await _userRepository.GetByPhone(phone);

			var result = _passwordHasher.Verify(password, user.PasswordHash);

			if (result == false)
			{
				throw new Exception("Fail to login");
			}

			var token = _jwtProvider.GenerateToken(user);

			return (User.Create(user.Id,user.UserName,user.Phone,"password", user.Roles, user.Messages, user.Chats).User, token);
		}
		public async Task<bool> IsUniquePhone(string phone)
		{
			return await _userRepository.IsUniquePhone(phone);
		}

		public async Task<User> GetById(Guid userId)
		{
			return await _userRepository.GetById(userId);
		}
		public async Task<List<User>> SearchByUserName(string userName)
		{
			return await _userRepository.SearchByUserName(userName);
		}
	}
}
