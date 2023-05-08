using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Flashcards.Chad1082.Data
{
    static internal class Database
    {
        internal static readonly string connString = ConfigurationManager.AppSettings.Get("connString");
        internal static readonly string dbName = ConfigurationManager.AppSettings.Get("dbName");
        internal static readonly string[] files = {
                Path.Combine(AppContext.BaseDirectory, dbName + ".mdf"),
                Path.Combine(AppContext.BaseDirectory, dbName + ".ldf")
            };
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
            doesExist = File.Exists(files[0]);
            return doesExist;
        }

        private static void CreateDatabase()
        {
           string str = "CREATE DATABASE " + dbName + " ON PRIMARY " +
                 "(NAME = " + dbName + "_Data, " +
                 "FILENAME = '" + files[0] + "', " +
                 "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%)" +
                 "LOG ON (NAME = " + dbName + "_Log, " +
                 "FILENAME = '" + files[1] + "', " +
                 "SIZE = 1MB, " +
                 "MAXSIZE = 5MB, " +
                 "FILEGROWTH = 10%)";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(str, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Database Created Successfully!");
                CreateTables();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create database:");
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private static void CreateTables()
        {
            string sql = @"USE [" + dbName + @"]
                            
                            SET ANSI_NULLS ON
                            
                            SET QUOTED_IDENTIFIER ON
                            
                            CREATE TABLE [dbo].[Stacks](
	                            [Id] [int] IDENTITY(1,1) NOT NULL,
	                            [Name] [nvarchar](100) NOT NULL,
                             CONSTRAINT [PK_Stacks] PRIMARY KEY CLUSTERED 
                            (
	                            [Id] ASC
                            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
                            ) ON [PRIMARY]
                            
                            CREATE TABLE [dbo].[Flashcards](
	                            [Id] [int] IDENTITY(1,1) NOT NULL,
	                            [StackId] [int] NOT NULL,
	                            [Front] [nvarchar](500) NOT NULL,
	                            [Back] [nvarchar](500) NOT NULL
                            ) ON [PRIMARY]
                            
                            ALTER TABLE [dbo].[Flashcards]  WITH CHECK ADD  CONSTRAINT [FK_Flashcards_Stacks] FOREIGN KEY([StackId])
                            REFERENCES [dbo].[Stacks] ([Id])
                            ON DELETE CASCADE
                            
                            ALTER TABLE [dbo].[Flashcards] CHECK CONSTRAINT [FK_Flashcards_Stacks]";
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Tables Created Successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create tables:");
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }

}
