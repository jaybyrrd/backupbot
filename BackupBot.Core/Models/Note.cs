using System;

namespace BackupBot.Models
{
    public class Note
    {

        public ulong NoteId { get; set; }
        public ulong UserId { get; set; }

        public string Description { get; set; }

        public ulong CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public NoteTypes NoteType { get; set; }

    }
}
