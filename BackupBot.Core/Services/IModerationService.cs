using System;
using System.Threading.Tasks;

namespace BackupBot.Services
{
    public interface IModerationService
    {
        Task AddNoteAsync(ulong userId, string description,
            ulong createdBy, DateTime dateCreated, NoteTypes type);
    }
}
