using System;
using System.Collections.Generic;
using System.Text;
using BackupBot.Data.Entities;
using BackupBot.Data.Repositories;
using Discord.Commands;

namespace BackupBot.Domain.Modules
{
    public class DefaultCommands : ModuleBase<SocketCommandContext>
    {
        private IRepository<User> _repository;

        //public DefaultCommands(IRepository<User> repository)
       // {
       //     _repository = repository;
        //}


    }
}
