using System;
using System.Threading.Tasks;
using BackupBot.Data.Entities;
using BackupBot.Models;

namespace BackupBot.Services.Moderation
{
    public interface IModerationService
    {
        Task AddNoteAsync(ulong userId, string description,
            ulong createdBy, DateTime dateCreated, Enums.NoteTypes type);
    }
}
