using ConsoleTools;
using Flashcards.Chad1082.Folders;

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
            string[] args = new string[] {""};

            manageStacksMenu = new ConsoleMenu(args, level: 1)
                .Add("View Stacks", () => ShowStacks())
                .Add("New Stack", () => CreateStack())
                .Add("Delete Stack", () => DeleteStack())
                .Add("Return to Main Menu", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Title = "Manage Stacks";
                });

            manageFlashcardsMenu = new ConsoleMenu(args, level: 1)
                .Add("Return to Main Menu", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Title = "Manage Fashcards";
                });

            studyMenu = new ConsoleMenu(args, level: 1)
                .Add("Return to Main Menu", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Title = "Study";
                });

            sessionsMenu = new ConsoleMenu(args, level: 1)
                .Add("Return to Main Menu", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Title = "Previous Study Sessions";
                });


            mainMenu = new ConsoleMenu(args, level: 0)
                .Add("Manage Card Stacks", manageStacksMenu.Show)
                .Add("Manage Flashcards", manageFlashcardsMenu.Show)
                .Add("Study", studyMenu.Show)
                .Add("View study sessions", sessionsMenu.Show)
                .Add("Exit", () => Environment.Exit(0))
                .Configure(config =>
                {
                    config.Title = "Flashcards study session!";
                });
        }
        internal void ShowMainMenu()
        {
           mainMenu.Show();
        }

        internal void ShowStacks()
        {   
            List<Stack> stacks;
            stacks = StacksController.GetStacks();
            TableVisualisationEngine.ShowStacksTable(stacks);
            Console.ReadLine();
        }

        internal void CreateStack()
        {
            Console.WriteLine("Create Stack");
            Console.ReadLine();
        }

        internal void DeleteStack()
        {
            Console.WriteLine("Delete Stack");
            Console.ReadLine();
        }



    }
}
