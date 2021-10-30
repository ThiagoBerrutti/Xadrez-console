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
                //ChessPosition chess = new ChessPosition('a', 1);
                //Position pos = new Position(7, 0);

                //Position chessToPosition = new Position(chess);
                //ChessPosition positionToChess = new ChessPosition(pos);

                ////Console.WriteLine(chess.ToPosition());
                ////Console.WriteLine(pos.ToChessPosition());
                //Console.WriteLine("----------  ");
                //Console.WriteLine("chessToPosition: "+chessToPosition);
                //Console.WriteLine("positionToChess: "+positionToChess);



                
                //table.InsertPiece(new Rook(table, color), new Position(initialLine, 0));
                
            }
            catch (TableException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
