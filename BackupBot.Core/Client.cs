using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using BackupBot.Core.Backup;

namespace BackupBot.Core
{
    public class Client
    {
        public DiscordSocketClient SocketClient { get; }

        private readonly CommandService _commands;
        private readonly IServiceProvider _services;
        private readonly IBackupMaker _backupHandler;

        public Client()
        {
            SocketClient = new DiscordSocketClient();
            _commands = new CommandService();
            _services = new ServiceCollection()
                .AddSingleton(SocketClient)
                .AddSingleton(_commands)
                .BuildServiceProvider();
            _backupHandler = new BackupMaker(new DirectoryInfo("D:/backup"));
        }

        public async Task RunAsync()
        {
            SocketClient.Log += Log;
            await RegisterCommandsAsync();
            await SocketClient.LoginAsync(Discord.TokenType.Bot, GetToken());
            await SocketClient.StartAsync();

            await Task.Delay(-1);
        }

        public async Task RegisterCommandsAsync()
        {
            SocketClient.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var msg = arg as SocketUserMessage;
            int argPos = 0;

            if (msg is null) return;

            await _backupHandler.AddMessageAsync(msg);

            if (!msg.Author.IsBot && msg.HasCharPrefix('*', ref argPos))
            {
                var context = new SocketCommandContext(SocketClient, msg);
                var result = await _commands.ExecuteAsync(context, argPos, _services);
                if (!result.IsSuccess) return;
            }

            ulong test = msg.Id;
            var options = new RequestOptions { RetryMode = RetryMode.AlwaysRetry };
            //await msg.DeleteAsync(options);
        }

        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        private string GetToken()
        {
            return File.ReadAllText("D:/workspace/token.txt");
        }
    }
}