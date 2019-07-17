using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace BackupBot
{
    public class Client : DiscordSocketClient
    {
        private readonly CommandService _commands;
        private readonly IServiceProvider _services;
        private readonly string _token;

        public IServiceProvider Services { get; }

        public Client(string token)
        {
            _token = token;
            _services = new ServiceCollection()
                .AddSingleton<CommandService>()
                .BuildServiceProvider();
        }


        public async Task RunAsync()
        {
            await RegisterCommandsAsync();
            await LoginAsync(Discord.TokenType.Bot, _token);
            await StartAsync();

            await Task.Delay(-1);
        }

        public async Task RegisterCommandsAsync()
        {
            MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
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