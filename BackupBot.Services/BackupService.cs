using System;
using System.Threading.Tasks;

namespace BackupBot.Services
{
    class BackupRepository : IBackupService
    {
        public Task AddMessageAsync(Message message)
        {
            throw new NotImplementedException();
        }

        public Task GetMessageByChannelName()
        {
            throw new NotImplementedException();
        }
    }
}
