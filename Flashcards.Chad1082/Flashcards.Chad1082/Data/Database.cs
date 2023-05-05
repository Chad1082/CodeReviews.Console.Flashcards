using System.Configuration;
using System.Data.SqlClient;

namespace Flashcards.Chad1082.Data
{
    static internal class Database
    {
        internal static readonly string connString = ConfigurationManager.AppSettings.Get("connString");
                public static void SetupDB()
        {
            if (!DatabaseExists())
            {
                Console.WriteLine("Database does not exist, creating...");
                CreateDatabase();
            }
        }
        private static bool DatabaseExists()
        {
            bool doesExist = false;

            
            return doesExist;
        }

        private static bool CreateDatabase()
        {
            //https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/create-sql-server-database-programmatically
            bool created = false;

            using (SqliteConnection conn = new SqliteConnection(connString))
            {
                conn.Open();

                var command = conn.CreateCommand();
                command.CommandText = @"CREATE TABLE ""CodingSessions"" (
	                                    ""ID""	INTEGER NOT NULL UNIQUE,
	                                    ""StartDateTime""	TEXT NOT NULL,
	                                    ""EndDateTime""	TEXT NOT NULL,
	                                    PRIMARY KEY(""ID"" AUTOINCREMENT)
                                    );";

                command.ExecuteNonQuery();
                conn.Close();
                created = true;

            }

            return created;
        }
    }

}
