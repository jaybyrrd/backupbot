﻿namespace BackupBot.Core.Models
{
    public class User
    {
        public ulong UserId { get; set; }
        public Enums.UserRights Rights { get; set; }
    }
}
