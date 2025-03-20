using Messenger.Core.Abstractions;
using Messenger.Core.Models;
using Messenger.DataAccess;
using Messenger.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.DataAccess
{
	public static class DataAccessExtension
	{
		public static IServiceCollection AddDataAccess(
		this IServiceCollection services,
		IConfiguration configuration)
		{
			services.AddDbContext<MessengerDBcontext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString(nameof(MessengerDBcontext)));
			});

			services.AddTransient<MessengerDBcontext>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IMessageRepository, MessageRepository>();
			services.AddScoped<IConnectionRepository, ConnectionRepository>();
			services.AddScoped<IChatRepository, ChatRepository>();
			services.AddScoped<IFileRepository, FileRepository>();

			return services;
		}
	}
}
