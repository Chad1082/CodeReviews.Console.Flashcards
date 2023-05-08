using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Chad1082.Data
{
    internal class Menu
    {
        internal void ShowMainMenu()
        {
            Console.WriteLine("Flashcards study session!");
            do
            {
                MainMenu();
            } while (true);
        }

        private void MainMenu()
        {
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("Please select an option below:");
            Console.WriteLine("1 - Manage Card Stacks");
            Console.WriteLine("2 - Manage Flashcards");
            Console.WriteLine("3 - Study");
            Console.WriteLine("4 - View Study Sessions");
            Console.WriteLine("5 - Exit");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

            string menuOption = Console.ReadLine().Trim().ToUpper();
            switch (menuOption)
            {
                case "1":
                    Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    break;
                case "3":                    
                    Console.Clear();
                    break;
                case "4":                    
                    Console.Clear();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Option not recognised");
                    break;
            }
        }
    }
}
