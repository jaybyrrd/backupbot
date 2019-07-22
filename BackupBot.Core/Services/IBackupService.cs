using BackupBot.Models;
using System.Threading.Tasks;

namespace BackupBot.Services
{
    public interface IBackupService
    {
        Task AddMessageAsync(Message message);
        Task GetMessageByChannelName();
    }
}
