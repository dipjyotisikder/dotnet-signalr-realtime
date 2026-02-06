using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using SignalR.Api.MessagingModule.Services;
using SignalR.Api.UserModule.Services;
using SignalR.Api.Hubs.Services;
using SignalR.Api.Data.SqLite;
using SignalR.Api.Hubs;
using SignalR.Api.Constants;
using SignalR.Api.Infrastructure.DependencyInjection;
using SignalR.Api.Configuration;

// SERVICE CONTAINER
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCors();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = AuthenticationConstants.ISSUER,
            ValidAudience = AuthenticationConstants.AUDIENCE,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthenticationConstants.TOKEN_SECRET_KEY)),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services
    .AddSqLiteDatabase(builder.Configuration);
// .AddInMemoryDatabase(builder.Configuration);

builder.Services.AddScoped<ICurrentUser, CurrentUser>();

builder.Services.AddScoped<IHubService, HubService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IConversationService, ConversationService>();
builder.Services.AddScoped<IMessageService, MessageService>();

builder.Services.AddInfrastructureDependencies();

// Register AppConfiguration from appsettings
var appConfiguration = new AppConfiguration();
builder.Configuration.GetSection("AppConfiguration").Bind(appConfiguration);
builder.Services.AddSingleton(appConfiguration);

// PIPELINE
WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

var allowedOrigins = appConfiguration.AllowedOrigins;
app.UseCors(corsBuilder => corsBuilder
    .WithOrigins(allowedOrigins)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

app.UseRouting();

app.UseMiddleware<HubMiddleWare>();

app.UseAuthentication();
app.UseAuthorization();

app.UseWebSockets();
app.MapControllers();
app.MapControllerRoute("default", "{controller}/{action}/{id?}");

app.MapHub<ApplicationHub>(HubConstants.HUB_ENDPOINT);

// Apply database migrations on startup
using (var scope = app.Services.CreateScope())
{
    try
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<SqLiteDataContext>();
        dbContext.Database.MigrateAsync().Wait();
        Console.WriteLine("Database migrations applied successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error applying database migrations: {ex.Message}");
    }
}

app.Run();
