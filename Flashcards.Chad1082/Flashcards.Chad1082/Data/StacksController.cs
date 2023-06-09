using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flashcards.Chad1082.Folders;

namespace Flashcards.Chad1082.Data
{
    internal class StacksController
    {
        internal static List<Stack> GetStacks()
        {
            List<Stack> stacks = new List<Stack>();

            string SQL = @"SELECT [Id],[Name] FROM [Flashcards].[dbo].[Stacks]";

            SqlConnection conn = new SqlConnection(Database.connString);
            SqlCommand cmd = new SqlCommand(SQL, conn);
            try
            {
                conn.Open();
                SqlDataReader sqlData = cmd.ExecuteReader();

                if (sqlData.HasRows)
                {
                    while (sqlData.Read())
                    {
                        stacks.Add(
                            new Stack()
                            {
                                Id = (int)sqlData.GetSqlInt32(0),
                                Name = sqlData.GetString(1)
                            });
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Read();
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return stacks;
        }
    }
}
