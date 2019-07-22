using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using BackupBot.Core.Services;
using BackupBot.Models;
using Discord;
using Discord.Commands;

namespace BackupBot.Core.Modules
{

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
            const int REQUIRED_ARGUMENT_COUNT = 3;
            string[] arguments = description.Split(SPACE);

            if (arguments.Length != REQUIRED_ARGUMENT_COUNT)
            {
                await ReplyAsync("Command is not valid. Syntax: Note [user] [type] [description].");
            }

            int userId;
            Enums.NoteTypes type;

            try
            {
                userId = int.Parse(arguments[0]);
                type = (Enums.NoteTypes) Enum.Parse(typeof(Enums.NoteTypes), arguments[1], true);
            }
            catch
            {
                await ReplyAsync("UserId or NoteType is invalid. Or both.");
                return;
            }

            INote note = new Note(user.Id, arguments[2], Context.User.Id, DateTime.Now , type);
            await _service.AddNoteAsync(note);

            await ReplyAsync("Note has been successfully added to user's history.");
        }

        [Command("RemoveNote")]
        [Alias("Note Remove", "Remove Note")]
        [Summary(("Remove a note from member's record of bad behaviour (RBB)."))]
        public async Task RemoveNote([Remainder] int id)
        {
            bool isNoteDeleted = await _service.DeleteNoteAsync(id);

            if (isNoteDeleted)
            {
                await ReplyAsync($"Note {id} has been removed from user's history.");
            }
            else
            {
                await ReplyAsync($"Note {id} could not be removed from user's history. ");
            }
        }

        [Command("GetNote")]
        [Alias("Note Get", "Get Note")]
        [Summary("Show all notes in member's record of bad behaviour (RBB).")]
        public async Task GetNotes(User user)
        {
            IList<INote> notes = await _service.GetNotesAsync(user);

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
            if (await Context.Guild.GetUserAsync(user.Id) == null)
            {
                await ReplyAsync("User not valid.");
            }

            await Context.Guild.AddBanAsync(user.Id, 0, reason);
        }

        private async Task SendParsingErrorMessageAsync()
        {
            await ReplyAsync("Command is invalid: parsing has failed.");
        }
    }
}
