using System;
using System.Threading.Tasks;

namespace BackupBot.Services.EntityFramework
{
    public class NoteRepository : INoteService
    {
        private readonly GcContext _context;
        public NoteRepository(GcContext context)
        {
            _context = context;
        }

        public Task AddNoteAsync(Models.Note note)
        {
            throw new NotImplementedException();
        }
    }
}
