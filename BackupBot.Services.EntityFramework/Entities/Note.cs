using System;

namespace BackupBot.Data.Entities
{
    public class Note
    {
        public ulong EntityId { get; set; }
        public ulong UserId { get; set; }

        public string Description { get; set; }

        public ulong CreatedBy { get; set; }

        public DateTime Date { get; set; }

        public NoteTypes NoteType { get; set; }

    }
}
