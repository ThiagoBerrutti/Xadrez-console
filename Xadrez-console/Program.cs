using System;
using TableNS;
using ChessGame.Pieces;
using TableNS.Enums;
using ChessGame;
using TableNS.Exceptions;


namespace Xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Table table = new Table(8, 8);

            void SetTablePieces()
            {
                void SetPlayerPieces(int initialLine, Color color)
                {
                    table.InsertPiece(new Rook(table, color), new Position(initialLine, 0));
                    table.InsertPiece(new Knight(table, color), new Position(initialLine, 1));
                    table.InsertPiece(new Bishop(table, color), new Position(initialLine, 2));
                    table.InsertPiece(new King(table, color), new Position(initialLine, 3));
                    table.InsertPiece(new Queen(table, color), new Position(initialLine, 4));
                    table.InsertPiece(new Bishop(table, color), new Position(initialLine, 5));
                    table.InsertPiece(new Knight(table, color), new Position(initialLine, 6));
                    table.InsertPiece(new Rook(table, color), new Position(initialLine, 7));
                    for (int i = 0; i < 8; i++)
                    {
                        if (initialLine == 0)
                        {
                            table.InsertPiece(new Pawn(table, color), new Position(1, i));
                        }
                        else if (initialLine == 7)
                        {
                            table.InsertPiece(new Pawn(table, color), new Position(6, i));
                        }
                    }
                }

                SetPlayerPieces(0, Color.Black);
                SetPlayerPieces(7, Color.White);
            }

            try
            {
                
                SetTablePieces();
                Display.PrintTable(table);
            }
            catch (TableException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
