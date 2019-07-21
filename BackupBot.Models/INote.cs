using System;

namespace BackupBot.Models
{
    public interface INote
    {
        /// <summary>
        /// Discord ulong ID of the corresponding person
        /// </summary>
        ulong UserId { get; }

        /// <summary>
        /// Description of the note
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Discord ulong ID of the staffmember writing the note
        /// </summary>
        ulong CreatedBy { get; }

        /// <summary>
        /// Date that the note has been written
        /// </summary>
        DateTime Date { get; }

        /// <summary>
        /// Describes the type of the note 
        /// </summary>
        NoteTypes Type { get; }

    }
}