using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using BackupBot.Core.Services;
using BackupBot.Models;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace BackupBot.Core.Modules
{
    /// <summary>
    /// ToDo: have internal admin rights and check if userToKick is admin in our system, also check if an admin is being tried to be punished
    /// </summary>
    [Name("Moderation")]
    [Summary("Commands for moderating activities.")]
    public class ModerationCommands : ModuleBase
    {
        private IModerationService _service;

        private const char SPACE = ' ';

        public ModerationCommands(IModerationService service)
        {
            _service = service;
        }

        [Command("AddNote")]
        [Alias("Note add", "Add Note")]
        [Summary("Add a note to member's record of bad behaviour (RBB).")]
        public async Task AddNote(User user, [Remainder] string description)
        {
            if (!_service.IsUserModerator(Context.User.Id))
            {
                await SendUserNotEnoughRights();
                return;
            }

            const int REQUIRED_ARGUMENT_COUNT = 2;
            string[] arguments = description.Split(SPACE);

            if (arguments.Length != REQUIRED_ARGUMENT_COUNT)
            {
                await ReplyAsync("Command is not valid. Syntax: Note [userToKick] [type] [description].");
            }

            Enums.NoteTypes type;
            bool isSuccessful = Enum.TryParse<Enums.NoteTypes>(arguments[0], out type);

            if(isSuccessful)
                await ReplyAsync("UserId or NoteType is invalid. Or both.");
            

            INote note = new Note(user.Id, arguments[1], Context.User.Id, DateTime.Now , type);
            await _service.AddNoteAsync(note);

            await ReplyAsync("Note has been successfully added to userToKick's history.");
        }

        [Command("RemoveNote")]
        [Alias("Note Remove", "Remove Note")]
        [Summary(("Remove a note from member's record of bad behaviour (RBB)."))]
        public async Task RemoveNote([Remainder] int id)
        {
            if (!_service.IsUserModerator(Context.User.Id))
            {
                await SendUserNotEnoughRights();
                return;
            }

            bool isNoteDeleted = await _service.DeleteNoteAsync(id);

            if (isNoteDeleted)
            {
                await ReplyAsync($"Note {id} has been removed from userToKick's history.");
            }
            else
            {
                await ReplyAsync($"Note {id} could not be removed from userToKick's history. ");
            }
        }

        [Command("GetNote")]
        [Alias("Note Get", "Get Note")]
        [Summary("Show all notes in member's record of bad behaviour (RBB).")]
        public async Task GetNotes(User user)
        {
            if (!_service.IsUserModerator(Context.User.Id))
            {
                await SendUserNotEnoughRights();
                return;
            }

            IList<INote> notes = _service.GetNotes(user);

            if (notes == null || notes.Count == 0)
            {
                await ReplyAsync($"User has no notes in history.");
            }
            else
            {
                // ToDo: send embedded messages with all notes of users
            }
        }

        [Command("Ban")]
        [Summary("Ban member from discord server.")]
        public async Task BanMember(User user, [Remainder] string reason)
        {
            if (!_service.IsUserModerator(Context.User.Id))
            {
                await SendUserNotEnoughRights();
                return;
            }

            if (!await UserExistsAsync(user))
            {
                await SendUserNotValid();
                return;
            }

            await Context.Guild.AddBanAsync(user.Id, 0, reason);
        }

        [Command("Kick")]
        [Summary("Kick a member from the discord server.")]
        public async Task KickMember(User userToKick, [Remainder] string reason)
        {
            if (!_service.IsUserModerator(Context.User.Id))
            {
                await SendUserNotEnoughRights();
            }
            else if (!await UserExistsAsync(userToKick))
            {
                await SendUserNotValid();
            }
            else if()
            {
                var user =  as SocketGuildUser;

                await user.KickAsync(reason);
                await ReplyAsync("User's ass has successfully been kicked.");
            }
        }

        private async Task<bool> UserExistsAsync(User user)
        {
            if (!_service.IsUserModerator(Context.User.Id))
                await SendUserNotEnoughRights();

            return await Context.Guild.GetUserAsync(user.Id) != null;
        }

        private async Task SendUserNotEnoughRights()
        {
            await SendUserNotValid();
        }

        private async Task SendUserNotValid()
        {
            await ReplyAsync("User is not valid.");
        }
    }
}
