using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using BackupBot.Data;
using BackupBot.Data.Repositories;
using BackupBot.Services.Moderation;
using Discord;
using Discord.Commands;

namespace BackupBot.Core.Modules
{

    [Name("Moderation")]
    [Summary("Commands for moderating activities.")]
    public class ModerationCommands : ModuleBase
    {
        private IModerationService _service = new ModerationService(new NoteRepository(new GcContext()));
        
        // To-Do: Add DI 
        /*public ModerationCommands(IModerationService service)
        {
            _service = service;
        }*/

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
