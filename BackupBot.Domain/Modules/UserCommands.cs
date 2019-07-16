using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BackupBot.Data;
using BackupBot.Data.Entities;
using BackupBot.Data.Repositories;
using Discord.Commands;

namespace BackupBot.Domain.Modules
{
    // Not sure about this name but what I mean to indicate is that this module can only affect the entity User
    public class UserCommands : ModuleBase<SocketCommandContext>
    {
        private IRepository<IUser> _repository;

        //public UserCommands(IRepository<IUser> repository)
        //{
        //    _repository = repository;
        //}

        public async Task BanUser([Remainder] string arg)
        {
            ulong userToBan = ulong.MinValue;

            ulong.TryParse(arg, out userToBan);
            if (userToBan != ulong.MinValue)
            {
                ulong user = Context.User.Id;
                
            }
            else
            {

            }
        }

       // private async Task<bool> CanUserBan(ulong id)
        //{
     //       int result = await GetUserRights(id);
      //      return result.CompareTo(Enums.UserRights.Admin) || result.CompareTo(Enums.UserRights.Mod);
      //  }

       /* private async Task<int> GetUserRights(ulong id)
        {

        }*/

    }
}