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

        public static void PrintGame(ChessGame chessGame)
        {
            PrintTable(chessGame.Table);
            Console.WriteLine();
            Console.WriteLine("==============================");
            Console.WriteLine();
            PrintCapturedPieces(chessGame);
            Console.WriteLine();
            PrintTurn(chessGame);
            Console.WriteLine($"Vulnerable en passant: {chessGame.VulnerableEnPassant}");

        }

        public static void PrintGame(ChessGame chessGame, bool[,] possibleMovements)
        {
            PrintTable(chessGame.Table, possibleMovements);
            Console.WriteLine();
            Console.WriteLine("==============================");
            Console.WriteLine();
            PrintCapturedPieces(chessGame);
            Console.WriteLine();
            PrintTurn(chessGame);
            Console.WriteLine($"Vulnerable en passant: {chessGame.VulnerableEnPassant}");
        }

        //public static void PrintAllPossibleMovements(ChessGame game, Color color)
        //{
        //    bool[,] AllPossibleMovements = new bool[8, 8];

        //    foreach (Piece p in game.GetPiecesOnTableByDifferentColor(color))
        //    {
        //        foreach (Position pos in p.PossibleMovementsList())
        //        {
        //            AllPossibleMovements[pos.Line, pos.Column] = true;
        //        }
        //    }

        //    PrintGame(game, AllPossibleMovements);
        //}

        public static void PrintCapturedPieces(ChessGame chessGame)
        {
            HashSet<Piece> capturedBlack = chessGame.GetCapturedPiecesByColor(Color.Black);
            HashSet<Piece> capturedWhite = chessGame.GetCapturedPiecesByColor(Color.White);

            Console.WriteLine("Captured pieces:");

            ConsoleColor oldColor = Console.ForegroundColor;

            Console.WriteLine();
            Console.Write($"Black pieces captured: ");
            PrintPieceCollection(capturedBlack, (ConsoleColor)Color.Black);

            Console.WriteLine();
            Console.Write($"White pieces captured: ");
            PrintPieceCollection(capturedWhite, (ConsoleColor)Color.White);
            Console.WriteLine();
        }

        public static void PrintPieceCollection(HashSet<Piece> collection, ConsoleColor color)
        {
            Console.Write("[ ");
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;

            foreach (Piece p in collection)
            {
                Console.Write(p + " ");
            }

            Console.ForegroundColor = oldColor;
            Console.Write("]");
        }

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
        public static void PrintTurn(ChessGame chessGame)
        {
            Console.WriteLine($"Turn: {chessGame.Turn}");
            Console.Write($"Now playing: ");
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = (ConsoleColor)chessGame.ActualPlayer;
            Console.WriteLine(chessGame.ActualPlayer);
            Console.ForegroundColor = oldColor;

            PrintCheck(chessGame);
        }
        public static void PrintCheck(ChessGame chessGame)
        {
            if (chessGame.Check)
            {
                ConsoleColor oldColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CHECK!");
                Console.ForegroundColor = oldColor;
            }
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
            s = s.Trim();

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

        public static char ReadPromotion()
        {
            Console.WriteLine($"Promotion!");
            Console.Write("Want to turn into Bishop, Knight, Rook or Queen (B/C/T/Q)? ");
            char promote = Console.ReadLine().ToLower()[0];

            return promote;
        }
    }
}
