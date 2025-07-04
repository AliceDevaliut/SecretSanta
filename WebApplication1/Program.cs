using NotificationSender.Application;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TemplateService.Infrastructure.Extensions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTemplateInfrastructure(builder.Configuration);

builder.Services.AddSingleton<ITelegramBotClient>(_ =>
    new TelegramBotClient(""));
builder.Services.AddSingleton<ITelegramBotService, TelegramBotHandlers>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// Запускаем Telegram бота
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

// Локальные функции-адаптеры
async Task HandleUpdateAsync(ITelegramBotClient client, Telegram.Bot.Types.Update update, CancellationToken ct)
    => await botHandlerUpdate.HandleUpdateAsync(client, update, ct);

async Task HandleErrorAsync(ITelegramBotClient client, Exception error, CancellationToken ct)
    => await botHandlerUpdate.HandleErrorAsync(client, error, ct);

// Получаем информацию о боте
//var me = await botClient.GetMeAsync();

//app.Logger.LogInformation($"Telegram bot {me.FirstName} запущен");

app.Run();
