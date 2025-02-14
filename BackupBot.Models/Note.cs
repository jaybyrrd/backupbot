﻿using System;
using static BackupBot.Models.Enums;

namespace BackupBot.Models
{
    public class Note : INote 
    {

        public Note(ulong userId, string description, ulong createdBy, DateTime date, NoteTypes type)
        {
            UserId = userId;
            Description = description;
            CreatedBy = createdBy;
            Date = date;
            Type = type;
        }

        public ulong UserId { get; }

        public string Description { get; }

        public ulong CreatedBy { get; }
        
        public DateTime Date { get; }

        public NoteTypes Type { get; set; }
    }
}
