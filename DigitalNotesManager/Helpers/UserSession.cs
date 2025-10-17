namespace DigitalNotesManager.Helpers
{
    public static class UserSession
    {
        public static int UserID { get; private set; }
        public static string Username { get; private set; } = string.Empty;

        public static void SetUser(int userId, string username)
        {
            UserID = userId;
            Username = username;
        }

        public static void Clear()
        {
            UserID = 0;
            Username = string.Empty;
        }
    }
}
