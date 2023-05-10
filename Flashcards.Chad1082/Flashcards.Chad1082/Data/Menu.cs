using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Flashcards.Chad1082.Data
{
    internal class Menu
    {
        internal static ConsoleMenu mainMenu = new ConsoleMenu();
        internal static ConsoleMenu manageStacksMenu = new ConsoleMenu();
        internal static ConsoleMenu manageFlashcardsMenu = new ConsoleMenu();
        internal static ConsoleMenu studyMenu = new ConsoleMenu();
        internal static ConsoleMenu sessionsMenu = new ConsoleMenu();

        public Menu()
        {
            manageStacksMenu = new ConsoleMenu()
                .Add("View Stacks", () => Console.WriteLine("Option 1"))
                .Add("New Stack", () => Console.WriteLine("Option 2"))
                .Add("Delete Stack", () => Console.WriteLine("Option 3"))
                .Add("Return to Main Menu", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.Title = "Manage Stacks";
                    config.EnableBreadcrumb = true;
                    config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
                });

            manageFlashcardsMenu = new ConsoleMenu()
                .Add("Select Stack", () => Console.WriteLine("Option 1"))
                .Add("New Stack", () => Console.WriteLine("Option 2"))
                .Add("Delete Stack", () => Console.WriteLine("Option 3"))
                .Add("Return to Main Menu", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.Title = "Manage Fashcards";
                    config.EnableBreadcrumb = true;
                    config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
                });

            studyMenu = new ConsoleMenu()
                .Add("Select Stack", () => Console.WriteLine("Option 1"))
                .Add("New Stack", () => Console.WriteLine("Option 2"))
                .Add("Delete Stack", () => Console.WriteLine("Option 3"))
                .Add("Return to Main Menu", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.Title = "Study";
                    config.EnableBreadcrumb = true;
                    config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
                });

            sessionsMenu = new ConsoleMenu()
                .Add("Select Stack", () => Console.WriteLine("Option 1"))
                .Add("New Stack", () => Console.WriteLine("Option 2"))
                .Add("Delete Stack", () => Console.WriteLine("Option 3"))
                .Add("Return to Main Menu", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.Title = "Previous Study Sessions";
                    config.EnableBreadcrumb = true;
                    config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
                });


            mainMenu = new ConsoleMenu()
                .Add("Manage Card Stacks", manageStacksMenu.Show)
                .Add("Manage Flashcards", manageFlashcardsMenu.Show)
                .Add("Study", studyMenu.Show)
                .Add("View study sessions", sessionsMenu.Show)
                .Add("Exit", () => Environment.Exit(0))
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.Title = "Flashcards study session!";
                    config.EnableWriteTitle = true;
                    config.EnableBreadcrumb = true;
                    config.WriteHeaderAction = () => Console.WriteLine("Pick an option:");
                    config.WriteItemAction = item => Console.Write("[{0}] {1}", item.Index, item.Name);
                });
        }
        internal void ShowMainMenu()
        {
           mainMenu.Show();
        }
    }
}
