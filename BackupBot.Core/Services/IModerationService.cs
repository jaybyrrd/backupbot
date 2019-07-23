using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackupBot.Models;

namespace BackupBot.Core.Services
{
    public interface IModerationService
    {
        /// <summary>
        /// Add a note to the user's history.
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        Task<bool> AddNoteAsync(INote note);

        /// <summary>
        /// Delete a note from the user's history.
        /// </summary>
        /// <param name="id">Note ID</param>
        /// <returns></returns>
        Task<bool> DeleteNoteAsync(int id);

        /// <summary>
        /// Get all notes of user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<IList<INote>> GetNotesAsync(User user);

        
    }
}
