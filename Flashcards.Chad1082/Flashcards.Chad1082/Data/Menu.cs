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
            Console.WriteLine("C - Manage Card Stacks");
            Console.WriteLine("F - Manage Flashcards");
            Console.WriteLine("M - Study");
            Console.WriteLine("S - View Study Sessions");
            Console.WriteLine("E - Exit");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

            string menuOption = Console.ReadLine().Trim().ToUpper();
            switch (menuOption)
            {
                case "C":
                    Console.Clear();
                    break;
                case "F":
                    Console.Clear();
                    break;
                case "M":                    
                    Console.Clear();
                    break;
                case "S":                    
                    Console.Clear();
                    break;
                case "E":
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
