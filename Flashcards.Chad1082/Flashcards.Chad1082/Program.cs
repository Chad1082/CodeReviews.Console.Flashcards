using Flashcards.Chad1082.Data;
using static System.Net.Mime.MediaTypeNames;

namespace Flashcards.Chad1082
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database.SetupDB();
            Menu mainMenu = new Menu();

            mainMenu.ShowMainMenu();
        }
    }
}