using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BackupBot.Data.Entities;

namespace BackupBot.Services.Infrastructure
{
    public interface IModerationService
    {
        Task AddNoteAsync(ulong userId, string description,
            ulong createdBy, DateTime dateCreated, NoteTypes type);
    }
}
