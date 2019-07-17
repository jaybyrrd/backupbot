using System;
using System.Threading.Tasks;
using BackupBot.Domain.Models;
using Discord.WebSocket;

namespace BackupBot.Core.Backup
{
    public interface IBackupHandler : IDisposable
    {
        Task AddMessageAsync(SocketMessage msg);
    }
}