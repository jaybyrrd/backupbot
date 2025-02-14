﻿using System;
using BackupBot.Models;

namespace BackupBot.Data.Entities
{
    public class NoteEntity
    {
        public NoteEntity() { }

        public long EntityId { get; set; }

        public ulong UserId { get; set;  }

        public string Description { get; set; }

        public ulong CreatedBy { get; set;  }

        public DateTime Date { get; set;  }

        public Enums.NoteTypes NoteType { get; set; }

    }
}
