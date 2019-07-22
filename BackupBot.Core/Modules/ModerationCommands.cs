using BackupBot.Services;
using Discord.Commands;
using System.Threading.Tasks;

namespace BackupBot.Core.Modules
{

    [Name("Moderation")]
    [Summary("Commands for moderating activities.")]
    public class ModerationCommands : ModuleBase
    {
        private readonly INoteService _noteService;


        public ModerationCommands(INoteService noteService)
        {
            _noteService = noteService;
        }

        [Command("note")]
        [Summary("Add a note to a member's record of bad behaviour. (RBB)")]
        public async Task AddNote([Remainder] string user)
        {
            ulong id;

        }


        //public async IUser GetUser(string userTxt)
        //{
        //} 
    }
}
