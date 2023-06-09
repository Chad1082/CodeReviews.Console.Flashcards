using ConsoleTableExt;
using Flashcards.Chad1082.Folders;

namespace Flashcards.Chad1082.Data
{
    internal class TableVisualisationEngine
    {
        internal static void ShowStacksTable(List<Stack> stacks)
        {
            ConsoleTableBuilder
                .From(stacks)
                .WithFormat(ConsoleTableBuilderFormat.Alternative)
                .WithTitle("Stacks ", ConsoleColor.White, ConsoleColor.DarkGray)
                .ExportAndWriteLine();
        }
    }
}
