using System;
using System.Collections.Generic;
using System.Text;

namespace BackupBot.Data.Entities
{
    public class User : IUser
    {
        public ulong ID { get; set; }
        public Enums.UserRights Rights { get; set; }
    }
}
