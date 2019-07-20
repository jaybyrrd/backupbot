using System;

namespace BackupBot.Data.Entities
{
    public class Note : INote 
    {

        public Note(ulong id, string description, ulong createdBy, DateTime date, NoteTypes type)
        {
            UserId = id;
            Description = description;
            CreatedBy = createdBy;
            Date = date;
            Type = type;
        }

        /// <summary>
        /// Discord ulong ID of the corresponding person
        /// </summary>
        public ulong UserId { get; }

        /// <summary>
        /// Description of the note
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Discord ulong ID of the staffmember writing the note
        /// </summary>
        public ulong CreatedBy { get; }
        
        /// <summary>
        /// Date that the note has been written
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// Describes the type of the note 
        /// </summary>
        public NoteTypes Type { get; set; }

    }
}
