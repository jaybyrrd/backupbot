using BackupBot.Models;
using System;
using System.Threading.Tasks;

namespace BackupBot.Services.EntityFramework
{
    public class NoteService : INoteService
    {
        private readonly GcContext _context;

        public NoteService(GcContext context)
        {
            _context = context;
        }

        public async Task AddNoteAsync(Note note)
        {
            throw new NotImplementedException();
        }
    }
}
