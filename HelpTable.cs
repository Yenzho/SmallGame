using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace Game
{
    public class HelpTable
    {
        public static void PrintHelpTable(GameOptions options)
        {
            var table = new ConsoleTable();
            table.AddColumn(new[] { "PC\\User" }.Concat(options.Options));

            foreach (var pcMove in options.Options)
            {
                var results = new List<string> { pcMove };
                foreach (var userMove in options.Options)
                {
                    int pcIndex = options.Options.IndexOf(pcMove);
                    int userIndex = options.Options.IndexOf(userMove);
                    int result = (userIndex - pcIndex + options.Options.Count / 2 + options.Options.Count) % options.Options.Count - options.Options.Count / 2;
                    string outcome = result == 0 ? "Draw" : (result > 0 ? "Win" : "Lose");
                    results.Add(outcome);
                }
                table.AddRow(results.ToArray());
            }

            table.Write();
        }
    }
}
