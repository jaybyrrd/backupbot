using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using BackupBot.Core.Models;
using Discord;
using Discord.WebSocket;
using Newtonsoft.Json;

namespace BackupBot.Core.Backup
{
    public class BackupHandler : IBackupHandler
    {
        private FileStream _stream;
        private readonly IFormatter _formatter = new BinaryFormatter();

        private readonly DirectoryInfo _backupDir;

        public BackupHandler(DirectoryInfo dir)
        {
            _backupDir = dir;
        }

        public async Task AddMessageAsync(SocketMessage msg)
        {
            string channelName = msg.Channel.Name;
            string path = _backupDir + channelName;

            bool isBackupNeeded = !File.Exists(path);

            // This creates the file if it does not exist, so we have to check before that
            InitializeStream(channelName, path);

            if (isBackupNeeded)
            {
                await BackupCachedMessagesAsync(msg);
            }
            else
            {
                await Task.Run(() => WriteMsgToFile(new Message(msg)));
            }

        }

        private void InitializeStream(string channel, string path)
        {
            if (_stream is null || _stream.Name != path)
            {
                _stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            }
        }

        private async Task BackupCachedMessagesAsync(SocketMessage msg)
        {
            var messages = await msg.Channel.GetMessagesAsync(1000).FlattenAsync();

            foreach (var message in messages)
            {
                await Task.Run(() => WriteMsgToFile(new Message((SocketMessage)message)));
            }

            await _stream.FlushAsync();
        }


        private void WriteMsgToFile(IMsg obj)
        {
            _formatter.Serialize(_stream, obj);
        }

        public void Dispose()
        {
            _stream?.Dispose();
        }
    }
}
