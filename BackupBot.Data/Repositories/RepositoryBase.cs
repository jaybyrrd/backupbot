using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BackupBot.Data.Repositories
{
    public class RepositoryBase
    {
        protected GcContext Context { get; }

        public RepositoryBase(GcContext context)
        {
            Context = context;
        }
    }
}
