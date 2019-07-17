using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace BackupBot
{
    public class Client : DiscordSocketClient
    {
        private readonly CommandService _commands = new CommandService();
        private readonly string _token;
        private ILogger _logger;

        public IServiceProvider Services { get; }

        public Client(string token, ServiceCollection serviceDescriptors)
        {
            _token = token;
            _commands = new CommandService();
            Services = serviceDescriptors
                .AddSingleton(_commands)
                .AddLogging()
                .BuildServiceProvider();
        }

        public async Task RunAsync()
        {

            _logger = Services.GetRequiredService<ILogger<Client>>();
            await RegisterCommandsAsync();
            await LoginAsync(Discord.TokenType.Bot, _token);
            await StartAsync();

            await Task.Delay(-1);
        }

        public async Task RegisterCommandsAsync()
        {
            Log += Client_Log;
            MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), Services);
        }

        private Task Client_Log(Discord.LogMessage arg)
        {
            switch (arg.Severity)
            {
                case Discord.LogSeverity.Critical:
                    _logger.LogCritical(arg.Message);
                    break;
                case Discord.LogSeverity.Error:
                    _logger.LogError(arg.Message);
                    break;
                case Discord.LogSeverity.Warning:
                    _logger.LogWarning(arg.Message);
                    break;
                case Discord.LogSeverity.Info:
                    _logger.LogInformation(arg.Message);
                    break;
                case Discord.LogSeverity.Verbose:
                    _logger.LogTrace(arg.Message);
                    break;
                case Discord.LogSeverity.Debug:
                    _logger.LogDebug(arg.Message);
                    break;
                default:
                    break;
            }
            return Task.CompletedTask;
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            //var msg = arg as SocketUserMessage;
            //int argPos = 0;

            //if (msg is null) return;

            //await _backupHandler.AddMessageAsync(msg);

            //if (!msg.Author.IsBot && msg.HasCharPrefix('*', ref argPos))
            //{
            //    var context = new SocketCommandContext(SocketClient, msg);
            //    var result = await _commands.ExecuteAsync(context, argPos, _services);
            //    if (!result.IsSuccess) return;
            //}

            //ulong test = msg.Id;
            //var options = new RequestOptions { RetryMode = RetryMode.AlwaysRetry };



            //await msg.DeleteAsync(options);
        }

    }
}