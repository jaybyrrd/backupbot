using System;

namespace BackupBot.Models
{
    public class Enums
    {
        [Flags]
        public enum UserRights
        {
            Mvp = 0,
            Mod = 1,
            Admin = 2
        }

        public enum NoteTypes
        {
            Little,
            Severe,
            LastWarning
        }
    }
}
