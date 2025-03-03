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
		private readonly MessengerStoreDBcontext _context;
		private readonly IMapper _mapper;
		public UserRepository(MessengerStoreDBcontext context, IMapper mapper)
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

		public async Task<User> GetByPhone(string phone)
		{
			var userEntity = await _context.Users
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


			if (userEntity != null)
				return User.Create(userEntity.Id, userEntity.UserName, userEntity.Phone, userEntity.PasswordHash, roles, [], []).User;

			return null;
		}
		public async Task<User> GetById(Guid userId)
		{
			var userEntity = await _context.Users
				.AsNoTracking()
				.FirstOrDefaultAsync(x => x.Id == userId) ?? throw new Exception();

			ICollection<string> roles = [];

			foreach (var role in userEntity.Roles)
				roles.Add(role.Name);

			if (userEntity != null)
				return User.Create(userEntity.Id, userEntity.UserName, userEntity.Phone, userEntity.PasswordHash, roles, []/*_mapper.Map<ICollection<Product>>(userEntity.Products)*/, []).User;

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
			var userEntity = _context.Users
					.AsNoTracking()
					.Where(x => x.UserName.Contains(userName))
					.ToList();

			var mapped = _mapper.Map<List<User>>(userEntity);
			return mapped;
		}
	}
}
