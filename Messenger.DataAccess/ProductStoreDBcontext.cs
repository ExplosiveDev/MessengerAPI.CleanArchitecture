using Microsoft.EntityFrameworkCore;
using Messenger.DataAccess.Entities;
using Messenger.DataAccess.Seeder;
using Microsoft.Extensions.Options;
using Messenger.DataAccess;
using Messenger.DataAccess.Configuration;
using Messenger.Core.Models;

namespace Messenger.DataAccess
{
	public class ProductStoreDBcontext(
		DbContextOptions<ProductStoreDBcontext> options,
		IOptions<AuthorizationOption> authOptions) : DbContext(options)
	{

		public DbSet<ChatEntity> Chats { get; set; }
		public DbSet<UserEntity> Users { get; set; }
		public DbSet<RoleEntity> Roles { get; set; }
		public DbSet<UserRoleEntity> UserRoles { get; set; }
		public DbSet<MessageEntity> Messages { get; set; }
		public DbSet<ConnectionEntity> Connections { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductStoreDBcontext).Assembly);
		}
	}
}
