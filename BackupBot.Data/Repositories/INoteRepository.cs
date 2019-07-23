using System.Collections.Generic;
using System.Threading.Tasks;
using BackupBot.Data.Entities;
using BackupBot.Models;

namespace BackupBot.Data.Repositories
{
    public interface INoteRepository
    {

        Task InsertNoteAsync(INote note);

        Task DeleteNoteAsync(int id);

        List<INote> SelectNotes(User user);

    }
}