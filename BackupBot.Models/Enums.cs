using System;

namespace BackupBot.Models
{
    public class Enums
    {
        [Flags]
        public enum UserRights
        {
            None = 0,
            Pog = 1,
            Mod = 2,
            Admin = 4
        }

        public enum NoteTypes
        {
            Little,
            Severe,
            LastWarning
        }
    }
}
