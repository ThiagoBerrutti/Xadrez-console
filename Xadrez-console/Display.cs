using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_console.TableNS;

namespace Xadrez_console
{
    class Display
    {
        public static void PrintTable(Table table)
        {
            for (int y = 0; y < table.Columns; y++)
            {
                for (int x = 0; x < table.Lines; x++)
                {
                    if (table.GetPiece(x, y) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write($"{table.GetPiece(x, y)} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
