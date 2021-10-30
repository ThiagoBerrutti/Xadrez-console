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
                Console.Write(8-x + " ");
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
                        PrintPiece(table.GetPiece(x,y));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintPiece(Piece piece)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = (ConsoleColor)piece.Color; ;
            Console.Write(piece);
            Console.ForegroundColor = oldColor;
        }
    }
}
