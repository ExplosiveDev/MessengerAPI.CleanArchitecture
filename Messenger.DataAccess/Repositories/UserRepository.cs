using System.Linq;
using AutoMapper;
using Messenger.Core.Abstractions;
using Messenger.Core.Enums;
using Messenger.Core.Models;
using Messenger.DataAccess;
using Messenger.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Messenger.DataAccess.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly MessengerDBcontext _context;
		private readonly IMapper _mapper;
		public UserRepository(MessengerDBcontext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public async Task Add(User user)
		{

			var role = _context.Roles.FirstOrDefault(x => x.Id == (int)Role.User);

			var userEntity = new UserEntity()
			{
				Id = user.Id,
				UserName = user.UserName,
				PasswordHash = user.PasswordHash,
				Phone = user.Phone,
				Roles = { role },
			};

			await _context.Users.AddAsync(userEntity);
			await _context.SaveChangesAsync();
		}

		private async Task GetDefaultAvatar(UserEntity userEntity)
		{
            var defaultAvatar = await _context.Files.FirstOrDefaultAsync(f => f.FileName == "user.png");
            if (defaultAvatar != null)
            {
                userEntity.ActiveAvatar = defaultAvatar;
                userEntity.ActiveAvatarId = defaultAvatar.Id;
            }
        }

		public async Task<User> GetByPhone(string phone)
		{
			var userEntity = await _context.Users
                .Include(x => x.ActiveAvatar)
                .AsNoTracking()
				.FirstOrDefaultAsync(x => x.Phone == phone) ?? throw new Exception();

			var userRoles = _context.UserRoles.Where(ur => ur.UserId == userEntity.Id).ToList();

			ICollection<string> roles = [];

			foreach (var userRole in userRoles)
			{
				var roleName = Enum.GetName(typeof(Role), userRole.RoleId);
				if (!string.IsNullOrEmpty(roleName))
				{
					roles.Add(roleName);
				}
			}

			if (userEntity.ActiveAvatar == null) 
			{
				await GetDefaultAvatar(userEntity);
            }


			if (userEntity != null)
				return _mapper.Map<User>(userEntity);

			return null;
		}
		public async Task<User> GetById(Guid userId)
		{
			var userEntity = await _context.Users
				.Include(x => x.ActiveAvatar)
				.AsNoTracking()
				.FirstOrDefaultAsync(x => x.Id == userId) ?? throw new Exception();

			ICollection<string> roles = [];

			foreach (var role in userEntity.Roles)
				roles.Add(role.Name);


            if (userEntity.ActiveAvatar == null)
            {
                await GetDefaultAvatar(userEntity);
            }

            if (userEntity != null)
				return _mapper.Map<User>(userEntity);

            return null;
		}
		public async Task<bool> IsUniquePhone(string phone)
		{
			var user = await _context.Users
				.AsNoTracking()
				.FirstOrDefaultAsync(x => x.Phone == phone);
			if (user != null) return false;
			else return true;
		}

		public async Task<List<User>> SearchByUserName(string userName)
		{
			var usersEntity = _context.Users
					.Include(x => x.ActiveAvatar)
                    .AsNoTracking()
					.Where(x => x.UserName.Contains(userName))
					.ToList();

			if(usersEntity.Count > 0)
			{
                var defaultAvatar = await _context.Files.FirstOrDefaultAsync(f => f.FileName == "user.png");
                foreach (var userEntity in usersEntity)
                {
                    if (defaultAvatar != null && userEntity.ActiveAvatar == null)
                    {
                        userEntity.ActiveAvatar = defaultAvatar;
                        userEntity.ActiveAvatarId = defaultAvatar.Id;
                    }
                }
            }


            var mapped = _mapper.Map<List<User>>(usersEntity);
			return mapped;
		}

        public async Task<List<User>> GetContacts(Guid userId)
        {
            var chatIds = await _context.UserChats
                .AsNoTracking()
                .Where(uc => uc.UserId == userId)
                .Select(uc => uc.ChatId)
                .ToListAsync();

            var contacts = await _context.PrivateChats
                .Include(c => c.User1)
                .ThenInclude(c => c.ActiveAvatar)
                .Include(c => c.User2)
                .ThenInclude(c => c.ActiveAvatar)
                .AsNoTracking()
                .Where(pc => chatIds.Contains(pc.Id))
                .Select(pc => pc.User1Id == userId ? pc.User2 : pc.User1)
                .ToListAsync();

			return _mapper.Map<List<User>>(contacts);

        }

        public async Task<string> ChangeUserFields(Guid userId, string newUserName)
        {
			var userEntity = _context.Users.FirstOrDefault(u => u.Id == userId);

			if (userEntity == null) return null;

			userEntity.UserName = newUserName;
			await _context.SaveChangesAsync();
			return userEntity.UserName;
        }
    }
}
