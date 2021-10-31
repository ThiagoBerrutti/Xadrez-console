using System;
using TableNS;
using Chess.Pieces;
using TableNS.Enums;
using Chess;
using TableNS.Exceptions;



namespace Xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            

          
            try
            {
                ChessMatch game = new ChessMatch();
                Rook newKing = new Rook(game.table, Color.White);
                game.table.InsertPiece(newKing, new Position(5, 3));
                game.table.InsertPiece(new Rook(game.table, Color.White), new Position(0, 4));
                game.table.InsertPiece(new Rook(game.table, Color.White), new Position(4, 5));
                game.table.InsertPiece(new Rook(game.table, Color.Black), new ChessPosition('c', 4));              
                game.table.InsertPiece(new Rook(game.table, Color.Black), new Position(5, 4));                 
                game.table.InsertPiece(new Rook(game.table, Color.Black), new Position(5, 2));                 
                game.table.InsertPiece(new Rook(game.table, Color.Black), new Position(4, 3));                 
                game.table.InsertPiece(new Rook(game.table, Color.Black), new Position(6, 3));                 
                //game.table.InsertPiece(new Rook(game.table, Color.Black), new ChessPosition('h', 4));
                bool[,] possibleMovements = newKing.PossibleMovements();
                

                Console.Clear();
                Display.PrintMoveablePositions(newKing);

                //Console.WriteLine(newKing.PossibleMovements()[5,5]);
                Console.WriteLine(new Position(5,5).ToChessPosition());
                               
                Console.WriteLine("King's position: "+ newKing.Position);
                Console.WriteLine("King's position: "+ newKing.Position.ToChessPosition());
                Console.ReadLine();

                while (!game.Finished)
                {
                    Console.Clear();
                    Display.PrintTable(game.table);
                    Console.WriteLine("Enter the origin position:");
                    ChessPosition originPosition = Display.ReadChessPosition();
                    Console.WriteLine("Enter the destiny position:");
                    ChessPosition destinyPosition = Display.ReadChessPosition();
                    game.Move(originPosition, destinyPosition);
                }
                
                Display.PrintTable(game.table);
            }
            catch (TableException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
