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
        private readonly IChatRepository _chatRepository;
        private readonly IPasswordHasher _passwordHasher;
		private readonly IJwtProvider _jwtProvider;

		public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider, IChatRepository chatRepository)
		{
			_userRepository = userRepository;
			_chatRepository = chatRepository;
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
			var user = await _userRepository.GetUserByPhoneWithAvatar(phone);

			var result = _passwordHasher.Verify(password, user.PasswordHash);

			if (result == false)
			{
				throw new Exception("Fail to login");
			}

			var token = _jwtProvider.GenerateToken(user);

            user.PasswordHash = "Pass";

            return (user, token);
		}
		public async Task<bool> IsUniquePhone(string phone)
		{
			return await _userRepository.IsUniquePhone(phone);
		}
		public async Task<User> Get(string userId)
		{
            var userGuid = Guid.Parse(userId);
            if (!await _userRepository.IsUserExists(userGuid)) throw new ArgumentException("Користувач не знайдений", nameof(userGuid));
            return await _userRepository.GetUserWithAvatar(userGuid);
		}
		public async Task<List<User>> SearchByUserName(string userName)
		{
			return await _userRepository.GetByUserNameWithAvatar(userName);
		}
        public async Task<List<User>> GetContacts(string userId)
        {
			var userGuid = Guid.Parse(userId);
            if (!await _userRepository.IsUserExists(userGuid)) throw new ArgumentException("Користувач не знайдений", nameof(userGuid));

            var chatIds = await _chatRepository.GetUserChatIds(userGuid);

			var privateChats = await _chatRepository.GetPrivateChats(chatIds);

			var contactIds = privateChats
				.Select(pc => pc.User1Id == userGuid ? pc.User2Id : pc.User1Id)
				.Select(u => u)
				.ToList();

			var contacts = await _userRepository.GetUsersWithAvatars(contactIds);

            return contacts;
        }
        public async Task<string> ChangeUserFields(string userId, string newUserName)
        {
            Guid userGuid = Guid.Parse(userId);
            if (!await _userRepository.IsUserExists(userGuid)) throw new ArgumentException("Користувач не знайдений", nameof(userGuid));

            return await _userRepository.ChangeUserFields(userGuid, newUserName);
        }
    }
}
