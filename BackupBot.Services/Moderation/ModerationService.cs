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
        private readonly INoteRepository _noteRepository;
        private readonly IStaffRepository _staffRepository;

        public ModerationService(INoteRepository noteRepository, IStaffRepository staffRepository)
        {
            _noteRepository = noteRepository;
            _staffRepository = staffRepository;
        }
        
        public async Task<bool> AddNoteAsync(INote note)
        {
            throw new NotImplementedException();
            //await _noteRepository.AddNoteAsync(note);
        }

        public async Task<bool> DeleteNoteAsync(int id)
        {
            // ToDo: check if note exists
            throw new NotImplementedException();
        }

        public IList<INote> GetNotes(User user)
        {
            throw new NotImplementedException();
        }

        public bool IsUserAdmin(ulong user)
        {
            return GetRights(user).HasFlag(Enums.UserRights.Admin);
        }

        public bool IsUserModerator(ulong user)
        {
            throw new NotImplementedException();
        }

        public bool IsUserPog(ulong user)
        {
            throw new NotImplementedException();
        }

        private Enums.UserRights GetRights(ulong userId)
        {
            return _staffRepository.GetRights(userId);
        }

    }
}