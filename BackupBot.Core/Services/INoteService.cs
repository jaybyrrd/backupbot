using BackupBot.Models;
using System.Threading.Tasks;

namespace BackupBot.Services
{
    public interface INoteService
    {
        Task AddNoteAsync(Note note);
    }
}