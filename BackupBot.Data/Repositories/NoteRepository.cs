using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task InsertNoteAsync(INote note)
        {
            await _context.NoteEntities.AddAsync(NoteToEntity(note));
        }

        public async Task DeleteNoteAsync(int id)
        {
            var note = new NoteEntity() { EntityId = id};
            _context.NoteEntities.Attach(note);
            _context.NoteEntities.Remove(note);
            await _context.SaveChangesAsync();
        }

        public List<INote> SelectNotes(User user)
        {
            List<INote> noteList = new List<INote>();
            _context.NoteEntities.Where(x => x.UserId == user.Id)
                .ToList()
                .ForEach(y => noteList.Add(EntityToNote(y)));

            return noteList;
        }

        private static NoteEntity NoteToEntity(INote note) => new NoteEntity()
        {
            EntityId = DateTime.Now.Ticks,
            UserId = note.UserId,
            Description = note.Description,
            CreatedBy = note.CreatedBy,
            Date = note.Date,
            NoteType = note.Type
        };

        private static INote EntityToNote(NoteEntity entity) => new Note(entity.UserId, 
            entity.Description, entity.CreatedBy, entity.Date, entity.NoteType);
    }
}
