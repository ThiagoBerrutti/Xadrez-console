using System;
using TableNS;
using Chess.Pieces;
using TableNS.Enums;
using Chess;
using TableNS.Exceptions;
using System.Collections.Generic;



namespace Xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch game = new ChessMatch();
                
                game.Table.InsertPiece(new Rook(game.Table, Color.White), new Position(5, 3));
                //game.Table.InsertPiece(new Knight(game.Table, Color.White), new Position(5, 3));

                //bool[,] possiblePositions = ((Rook)game.Table.GetPiece(originChessPosition)).PossibleMovements();
                while (!game.Finished)
                {
                    Position originPosition = new Position();
                    Position destinyPosition = new Position();
                    bool[,] possibleMovements = new bool[game.Table.Lines, game.Table.Columns];

                    Console.Clear();
                    Display.PrintGame(game);
                    Console.WriteLine();
                                        
                    try
                    {
                        Console.Write("Enter the origin position: ");
                        originPosition = Display.ReadChessPosition().ToPosition();

                        game.ValidateOriginPosition(originPosition);
                    }
                    catch (TableException e)
                    {
                        Console.WriteLine();
                        Console.WriteLine(e.Message);
                        Console.WriteLine("(Press any key to continue)");
                        Console.ReadKey();
                        continue;
                    }

                    Console.Clear();
                    possibleMovements = game.Table.GetPiece(originPosition).PossibleMovements();
                    Display.PrintGame(game, possibleMovements);
                    Console.WriteLine();

                    Console.WriteLine("pass read");

                    try
                    {
                        Console.WriteLine($"Origin position: {originPosition.ToChessPosition()}");
                        Console.WriteLine();
                        Console.Write("Enter the destiny position: ");
                        destinyPosition = Display.ReadChessPosition().ToPosition();
                        game.ValidateDestinyPosition(originPosition, destinyPosition);
                    }
                    catch (TableException e)
                    {
                        Console.WriteLine();
                        Console.WriteLine(e.Message);
                        Console.WriteLine("(Press any key to continue)");
                        Console.ReadKey();
                        //continue;
                    }

                    Console.WriteLine("pass destiny");

                    game.ExecutePlay(originPosition, destinyPosition);
                }
            }
            catch (TableException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
