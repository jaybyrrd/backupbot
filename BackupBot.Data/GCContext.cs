using BackupBot.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackupBot.Data
{
    public class GcContext : DbContext
    {

        public GcContext()
        {
            
        }

        public DbSet<NoteEntity> NoteEntities { get; set; }

    }
}
