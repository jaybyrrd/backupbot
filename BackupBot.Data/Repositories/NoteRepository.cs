using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BackupBot.Data.Entities;
using BackupBot.Models;

namespace BackupBot.Data.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private GcContext _context;

        public NoteRepository(GcContext context)
        {
            _context = context;
        }

        public async Task AddNoteAsync(INote note)
        {
            await _context.NoteEntities.AddAsync(NoteToEntity(note));
        }

        private static NoteEntity NoteToEntity(INote note) => new NoteEntity()
            {
                EntityId = DateTime.Now.Ticks,
                UserId = note.UserId,
                Description =  note.Description,
                CreatedBy = note.CreatedBy,
                Date = note.Date,
                NoteType = note.Type
            };


    }
}
