using BackupBot.Repositories;
using Discord.Commands;
using System.Threading.Tasks;

namespace BackupBot.Core.Modules
{
    // Not sure about this name but what I mean to indicate is that this module can only affect the entity User
    public class UserCommands : ModuleBase<SocketCommandContext>
    {
        private IUserRepository _userRepository;

        public UserCommands(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task BanUserAsync([Remainder] string arg)
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