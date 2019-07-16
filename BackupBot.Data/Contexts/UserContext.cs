using System;
using System.Collections.Generic;
using System.Text;
using BackupBot.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackupBot.Data.Contexts
{
    public class UserContext : DbContext
    {

        private readonly string _connectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GCBot;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public UserContext()
        {
            
        }

        public UserContext(string connectionString)
        {
            _connectionString = _connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        public DbSet<IUser> Users { get; set; }

    }
}
