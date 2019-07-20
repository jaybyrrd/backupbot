using System;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace BackupBot.Core.Backup
{
    public interface IBackupMaker : IDisposable
    {
        Task AddMessageAsync(SocketMessage msg);
    }
}