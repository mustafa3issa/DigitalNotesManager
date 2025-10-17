namespace DigitalNotesManager.Models
{
    public class User
    {
        public int UserID { get; set; }           // Primary Key
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        // Navigation Property
        public ICollection<Note>? Notes { get; set; }
    }
}
