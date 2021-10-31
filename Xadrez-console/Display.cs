using System;
using System.Collections.Generic;
using System.Text;
using TableNS;
using TableNS.Enums;
using Chess;
using Chess.Pieces;

namespace Xadrez_console
{
    class Display
    {
        public static void PrintTable(Table table)
        {
            for (int y = 0; y < table.Lines; y++)
            {
                Console.Write(8-y + " ");
                for (int x = 0; x < table.Columns; x++)
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

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            Console.WriteLine(column);
            int line = int.Parse(s[1]+"");
            Console.WriteLine(line);
            return new ChessPosition(column, line);
        }

        public static void PrintMoveablePositions(Rook king)
        {
            bool[,] possibleMovements = king.PossibleMovements();

            for (int y = 0; y < king.Table.Lines; y++)
            {
                Console.Write(8 - y + " ");
                for (int x = 0; x < king.Table.Columns; x++)
                {
                    Piece piece = king.Table.GetPiece(x, y);
                    
                    if (possibleMovements[x, y])
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    if (piece == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(king.Table.GetPiece(x, y));
                        Console.Write(" ");
                    }
                    
                    

                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");

        }
    }
}
