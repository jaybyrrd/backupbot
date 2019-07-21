using System;
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
            throw new NotImplementedException();
        }
    }
}
