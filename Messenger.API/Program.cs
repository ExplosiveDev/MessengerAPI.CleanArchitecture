
using Messenger.DataAccess.Mapping;
using Messenger.API.Extensions;
using Messenger.Application.Services;
using Messenger.DataAccess;
using Messenger.Infrastructure;
using Microsoft.AspNetCore.CookiePolicy;
using Messenger.API.Hubs;
using Messenger.API.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
builder.Services.Configure<AuthorizationOption>(builder.Configuration.GetSection(nameof(AuthorizationOption)));

builder.Services.AddHttpContextAccessor();

builder.Services.AddApiAuthentication(builder.Configuration);
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));


//User service
builder.Services.AddScoped<IUserService, UserService>();

//Message service
builder.Services.AddScoped<IMessageService, MessageService>();

//Connection service
builder.Services.AddScoped<IConnectionService, ConnectionService>();

//Jwt provider
builder.Services.AddScoped<IJwtProvider, JwtProvider>();

//Password hasher
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

//Data Access
builder.Services.AddDataAccess(builder.Configuration);

//Mappers
builder.Services.AddAutoMapper(typeof(DataBaseMapping));
builder.Services.AddAutoMapper(typeof(ContractsMapping));

builder.Services.AddCors(options =>
{
	options.AddPolicy("CorsPolicy",
		builder => builder
			.WithOrigins("http://localhost:5173")
			.AllowAnyMethod()
			.AllowAnyHeader()
			.AllowCredentials());
});
builder.Services.AddSignalR();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCookiePolicy(new CookiePolicyOptions
{
	MinimumSameSitePolicy = SameSiteMode.Strict,
	HttpOnly = HttpOnlyPolicy.Always,
	Secure = CookieSecurePolicy.Always
});

app.MapControllers();

app.MapHub<ChatHub>("/chat");

app.Run();
