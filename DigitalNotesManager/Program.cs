namespace DigitalNotesManager
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //using (var db = new DigitalNotesManager.Data.NotesDbContext())
            //{
            //    if (!db.Users.Any())
            //    {
            //        db.Users.Add(new DigitalNotesManager.Models.User { Username = "Admin", Password = "1234" });
            //        db.SaveChanges();
            //    }
            //}

            Application.Run(new LoginForm());
        }
    }
}