using BackupBot.Core.Backup;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Xunit;

namespace BackupBot.Test.BackupBot.Core.Backup
{
    public class BackupMakerTest
    {
        /*
        [Fact]
        public async Task Add_Message_Async_FileExists_Ok()
        {
            var backupDir = new DirectoryInfo("D:\\backup\\");
           var handler = new BackupMaker(backupDir);
           var msg = new SocketUserMessage();
           await handler.AddMessageAsync();
        }
        */

        [Fact]
        public void Add_Message_Async_NoFile_Ok()
        {

        }
    }
}
