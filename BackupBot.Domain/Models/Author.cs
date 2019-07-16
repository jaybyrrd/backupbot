using System;
using System.Collections.Generic;
using System.Text;

namespace BackupBot.Domain.Models
{
    [Serializable]
    public readonly struct Author
    {
        public ulong Id { get; }
        public string UserName { get; }

        public Author(ulong id, string userName)
        {
            Id = id;
            UserName = userName;
        }
    }
}
