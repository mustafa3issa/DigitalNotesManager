using System;

namespace DigitalNotesManager.Models
{
    public class Note
    {
        public int NoteID { get; set; }           // Primary Key
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ReminderDate { get; set; }

        // Foreign Key
        public int UserID { get; set; }

        // Navigation Property
        public User? User { get; set; }
    }
}
