using System;
using System.Collections.Generic;
using System.Text;
using TableNS;
using TableNS.Enums;
using Chess;
using Chess.Pieces;
using TableNS.Exceptions;

namespace Xadrez_console
{
    class Display
    {
        public static void PrintTable(Table table)
        {
            for (int y = 0; y < table.Lines; y++)
            {
                Console.Write(8 - y + " ");
                for (int x = 0; x < table.Columns; x++)
                {
                    Piece piece = table.GetPiece(x, y);
                    PrintPiece(piece);
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintPiece(Piece piece)
        {

            ConsoleColor oldColor = Console.ForegroundColor;
            if (piece == null)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (piece.Color == Color.Black)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                Console.Write(piece + " ");
            }
            Console.ForegroundColor = oldColor;
        }

        public static ChessPosition ReadChessPosition()
        {
            void ValidateLine(char c)
            {
                if ((c < 'a') || (c > 'h'))
                {
                    throw new TableException($"Invalid position name. '{c}' is not an accepted value.");
                }
            }

            void ValidateColumn(char c)
            {
                if ((c < '1') || (c > '8'))
                {
                    throw new TableException($"Invalid position name. '{c}' is not an accepted value.");
                }
            }

            string s = Console.ReadLine();
            s.Trim();

            if (s.Length != 2)
            {
                throw new TableException("Invalid position name.");
            }

            ValidateLine(s[0]);
            ValidateColumn(s[1]);

            char column = s[0];
            int line = int.Parse(s[1] + "");

            return new ChessPosition(column, line);
        }

        public static void PrintTable(Table table, bool[,] possibleMovements)
        {
            //bool[,] possibleMovements = king.PossibleMovements();

            for (int y = 0; y < table.Lines; y++)
            {
                Console.Write(8 - y + " ");
                for (int x = 0; x < table.Columns; x++)
                {
                    Piece piece = table.GetPiece(x, y);

                    if (possibleMovements[x, y])
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }

                    PrintPiece(piece);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintTurn(ChessMatch chessMatch)
        {
            Console.WriteLine($"Turn: {chessMatch.Turn}");
            Console.Write($"Now playing: ");
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = (ConsoleColor)chessMatch.ActualPlayer;
            Console.Write(chessMatch.ActualPlayer);
            Console.ForegroundColor = oldColor;
        }

        public static void PrintTableAndTurn(ChessMatch chessMatch)
        {
            PrintTable(chessMatch.Table);
            Console.WriteLine();
            PrintTurn(chessMatch);
        }

        public static void PrintTableAndTurn(ChessMatch chessMatch, bool[,] possibleMovements)
        {
            PrintTable(chessMatch.Table, possibleMovements);
            Console.WriteLine();
            PrintTurn(chessMatch);
        }

        //public void PrintCapturedPieces(List<Piece> list)
        //{
            
        //    for (int i=0; i< list.Count && list.Count>0; i++)
        //    {
        //        Type type = list[i].GetType();

        //        if (!total.Exists(t => t == type))
        //        {
        //             = list.FindAll(p => p.GetType() == type);
        //        }

                

        //        Console.WriteLine(list[i].GetType());
        //    }
                
        //            foreach (Piece p in list)
        //    {
        //        ConsoleColor oldColor = Console.ForegroundColor;
        //        Console.ForegroundColor = (ConsoleColor)p.Color;
        //        Console.WriteLine(p.GetType());
        //        Console.ForegroundColor = oldColor;
        //    }
        //}
    }
}
