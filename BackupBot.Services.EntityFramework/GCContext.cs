using BackupBot.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackupBot.Services.EntityFramework
{
    /// <summary>
    /// Be sure this is added to the container as Transient or as Scoped.
    /// </summary>
    public class GcContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GCBot;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<Note> Notes { get; set; }

    }
}
