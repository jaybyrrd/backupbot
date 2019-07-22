using System;
using System.Collections.Generic;
using System.Text;
using Discord;

namespace BackupBot.Models
{
    public class User : IEntity<ulong>
    {
        public ulong Id { get; }

        public User(ulong id)
        {
            Id = id;
        }

        public static User FromIUser(IUser user) => new User(user.Id);
    }
}
