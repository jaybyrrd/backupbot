using System.Threading.Tasks;
using BackupBot.Data.Entities;

namespace BackupBot.Data.Repositories
{
    public interface INoteRepository
    {
        Task AddNoteAsync(INote note);
    }
}