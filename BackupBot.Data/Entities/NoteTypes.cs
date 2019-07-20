namespace BackupBot.Data.Entities
{
    /// <summary>
    /// NoteTypes describe the severity of the note. When the user is issued a Last Warning,
    /// the next warning will automatically ban him. 
    /// </summary>
    public enum NoteTypes
    {
        Little, 
        Severe,
        LastWarning
    }
}
