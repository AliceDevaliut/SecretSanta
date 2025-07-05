using NotificationSender.Application;
using OnlineShop.Application;
using System.Reflection;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using TemplateService.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTemplateInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ITelegramBotClient>(_ =>
    new TelegramBotClient(""));
builder.Services.AddSingleton<ITelegramBotService, TelegramBotHandlers>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Telegram 
var botClient = app.Services.GetRequiredService<ITelegramBotClient>();
var botHandlerUpdate = app.Services.GetRequiredService<ITelegramBotService>();
var lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();



var receiverOptions = new ReceiverOptions
{
    AllowedUpdates = Array.Empty<UpdateType>(),
    ThrowPendingUpdates = true,
};

botClient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandleErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: lifetime.ApplicationStopping
);

// 
async Task HandleUpdateAsync(ITelegramBotClient client, Telegram.Bot.Types.Update update, CancellationToken ct)
    => await botHandlerUpdate.HandleUpdateAsync(client, update, ct);

async Task HandleErrorAsync(ITelegramBotClient client, Exception error, CancellationToken ct)
    => await botHandlerUpdate.HandleErrorAsync(client, error, ct);

// 
//var me = await botClient.GetMeAsync();


app.Run();
