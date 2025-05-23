﻿using System.Linq;
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
        private async Task GetDefaultAvatar(UserEntity userEntity)
        {
            var defaultAvatar = await _context.Files.FirstOrDefaultAsync(f => f.FileName == "user.png");
            if (defaultAvatar != null)
            {
                userEntity.ActiveAvatar = defaultAvatar;
                userEntity.ActiveAvatarId = defaultAvatar.Id;
            }
        }
        public async Task<User> GetUserWithAvatar(Guid userId)
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
        public async Task<List<User>> GetUsersWithAvatars(List<Guid> userIds)
        {
            var users = new List<User>();
            foreach (var userId in userIds)
            {
                users.Add(await GetUserWithAvatar(userId));
            }
            return users;
        }
        public async Task<List<User>> GetUsersByNameWithAvatar(string name)
        {
            var userEntity = await _context.Users
                .Include(x => x.ActiveAvatar)
                .AsNoTracking()
                .Where(u => u.UserName.Contains(name))
                .ToListAsync();

            return _mapper.Map<List<User>>(userEntity);

        }
        public async Task<User> GetUserByPhoneWithAvatar(string phone)
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
        public async Task<bool> IsUniquePhone(string phone)
        {
            return !await _context.Users
                .AsNoTracking()
                .AnyAsync(x => x.Phone == phone);
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
        public async Task<List<User>> GetByUserNameWithAvatar(string userName)
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
        public async Task<string> ChangeUserFields(Guid userId, string newUserName)
        {
			var userEntity = _context.Users.FirstOrDefault(u => u.Id == userId);

			userEntity.UserName = newUserName;

			await _context.SaveChangesAsync();

			return userEntity.UserName;
        }
        public async Task<bool> IsUserExists(Guid userId) => await _context.Users.AnyAsync(c => c.Id == userId);

    }
}
