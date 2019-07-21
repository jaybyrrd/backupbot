using System.Threading.Tasks;
using BackupBot.Data.Entities;
using BackupBot.Models;

namespace BackupBot.Data.Repositories
{
    public interface INoteRepository
    {
        Task AddNoteAsync(INote note);
    }
}