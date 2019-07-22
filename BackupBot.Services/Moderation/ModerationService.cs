using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BackupBot.Core.Services;
using BackupBot.Data.Entities;
using BackupBot.Data.Repositories;
using BackupBot.Models;

namespace BackupBot.Services.Moderation
{
    public class ModerationService : IModerationService
    {
        private readonly INoteRepository _repository;

        public ModerationService(INoteRepository repository)
        {
            _repository = repository;
        }

        public async Task AddNoteAsync(ulong userId, string description,
            ulong createdBy, DateTime dateCreated, Enums.NoteTypes type)
        {
            INote note = new Note(userId, description, createdBy, dateCreated, type);
            await _repository.AddNoteAsync(note);
        }

    }
}