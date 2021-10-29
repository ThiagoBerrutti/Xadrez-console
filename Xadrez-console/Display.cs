using System;
using System.Collections.Generic;
using System.Text;
using TableNS;
using TableNS.Enums;

namespace Xadrez_console
{
    class Display
    {
        

        public static void PrintTable(Table table)
        {
            for (int x = 0; x < table.Lines; x++)
            {
                for (int y = 0; y < table.Columns; y++)
                {
                    Piece piece = table.GetPiece(x, y);
                    if (piece == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray; 
                        Console.Write("- ");
                    }
                    else
                    {   
                        Console.ForegroundColor = (ConsoleColor)piece.Color; ;
                        Console.Write($"{table.GetPiece(x, y)} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
