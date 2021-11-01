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
                Rook newKing = new Rook(game.Table, Color.White);
                game.Table.InsertPiece(newKing, new Position(5, 3));

                //bool[,] possiblePositions = ((Rook)game.Table.GetPiece(originChessPosition)).PossibleMovements();
                while (!game.Finished)
                {
                    Position originPosition = new Position();
                    Position destinyPosition = new Position();
                    bool[,] possibleMovements = new bool[game.Table.Lines, game.Table.Columns];

                    Console.Clear();
                    Display.PrintTableAndTurn(game);
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
                    Display.PrintTableAndTurn(game, possibleMovements);
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
                        continue;
                    }

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
