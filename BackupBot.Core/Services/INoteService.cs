using BackupBot.Models;
using System;
using System.Threading.Tasks;

namespace BackupBot.Services
{
    public interface INoteService
    {
        Task AddNoteAsync(Note note);
        Task AddNoteAsync(ulong userId, string description, ulong createdBy, DateTime dateCreated, NoteTypes type);
    }
}