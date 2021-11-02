using System;
using TableNS;
using Chess.Pieces;
using TableNS.Enums;
using Chess;
using TableNS.Exceptions;
using System.Collections.Generic;
using Chess.Exceptions;



namespace Xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessGame game = new ChessGame();
                Position originPosition;
                Position destinyPosition;
                //game.SetPiece(new Rook(game.Table, Color.White), new Position(5, 3));
                //game.SetPiece(new Rook(game.Table, Color.White), new Position(4, 3));
                game.SetPiece(new Rook(game.Table, Color.Black), new Position(3, 3));
                
                //game.SetPiece(new Rook(game.Table, Color.White), new Position(5, 5));
                //game.SetPiece(new Rook(game.Table, Color.White), new Position(3, 5));
                game.SetPiece(new King(game.Table, Color.Black), new Position(4, 4));
                game.SetPiece(new King(game.Table, Color.White), new Position(0, 3));

                //game.CapturePiece(new Position(0, 0));
                //game.CapturePiece(new Position(1, 0));
                //game.CapturePiece(new Position(2, 0));
                //game.CapturePiece(new Position(3, 0));

                //game.CapturePiece(new Position(7, 7));
                //game.CapturePiece(new Position(6, 7));
                //game.CapturePiece(new Position(5, 6));
                //game.CapturePiece(new Position(4, 6));


                Position ReadOriginPosition(ChessGame chessGame)
                {
                    Position originPosition = new Position();

                    Console.Write("Origin position: ");
                    originPosition = Display.ReadChessPosition().ToPosition();
                    chessGame.ValidateOriginPosition(originPosition);

                    return originPosition;
                }

                Position ReadDestinyPosition(ChessGame chessGame, bool[,] possibleMovements)
                {
                    Position destinyPosition = new Position();

                    Console.Clear();
                    Display.PrintGame(chessGame, possibleMovements);
                    Console.WriteLine();
                    Console.WriteLine($"Origin position: {originPosition.ToChessPosition()}");
                    Console.Write("Destiny position: ");
                    destinyPosition = Display.ReadChessPosition().ToPosition();
                    chessGame.ValidateDestinyPosition(originPosition, destinyPosition);

                    return destinyPosition;
                }


                /////// START ///////


                while (!game.Finished)
                {
                    try
                    {
                        originPosition = new Position();
                        destinyPosition = new Position();
                        bool[,] possibleMovements = new bool[game.Table.Lines, game.Table.Columns];
                        game.UpdateCheckStatus();

                        Console.Clear();
                        Display.PrintGame(game);
                        Console.WriteLine();

                        originPosition = ReadOriginPosition(game);
                        possibleMovements = game.Table.GetPiece(originPosition).PossibleMovements();
                        destinyPosition = ReadDestinyPosition(game, possibleMovements);

                        try
                        {
                            game.ExecutePlay(originPosition, destinyPosition);
                        }
                        catch (CheckException e)
                        {
                            ConsoleColor oldColor = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(e.Message);
                            Console.ForegroundColor = oldColor;
                            Console.ReadKey();
                        }
                    }
                    catch (TableException e)
                    {
                        Console.WriteLine();
                        Console.WriteLine(e.Message);
                        Console.WriteLine("(Press any key to continue)");
                        Console.ReadKey();
                    }
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
