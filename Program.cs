namespace DemExTest
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

            string connStr = "server=localhost;user=root;database=masterpol;password=";
            var db = new DatabaseService(connStr);

            bool dbOk = SafeExecutor.TryExecute(() =>
            {
                db.ExecuteQuery("SELECT 1", r => 1);
                return true;
            },
            ex => MessageBox.Show("Не удалось подключиться к бд",
                                  "Критическая ошибка",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error)
            );

            if (!dbOk)
            {
                return;
            }

            Application.Run(new MainForm(db));
        }
    }
}