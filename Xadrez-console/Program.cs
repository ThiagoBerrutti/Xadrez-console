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


                game.UpdateCheckProperty();

                while (!game.GameFinished)
                {
                    try
                    {
                        originPosition = new Position();
                        destinyPosition = new Position();
                        bool[,] possibleMovements = new bool[game.Table.Lines, game.Table.Columns];

                        
                        //game.ExecutePlay(new Position(4, 7), new Position(2, 7));
                        //Console.Clear();
                        ////possibleMovements = game.Table.GetPiece(4, 7).PossibleMovements();
                        //Display.PrintGame(game, possibleMovements);
                        //Console.WriteLine("Castling white left");
                        ////Console.WriteLine($"{game.Table.GetPiece(2,7)}");
                        //Console.ReadKey();

                        //game.UndoPlay(new Position(4, 7), new Position(2, 7), null);
                        ////possibleMovements = game.Table.GetPiece(4, 7).PossibleMovements();
                        //Console.Clear();
                        //Display.PrintGame(game, possibleMovements);
                        //Console.WriteLine("Undo");
                        //Console.ReadKey();


                        //game.ExecutePlay(new Position(4, 0), new Position(6, 0));
                        ////possibleMovements = game.Table.GetPiece(4, 0).PossibleMovements();
                        //Console.Clear();
                        //Display.PrintGame(game, possibleMovements);
                        //Console.WriteLine("Castling black right");
                        //Console.ReadKey();

                        
                        //game.UndoPlay(new Position(4, 0), new Position(6, 0), null);
                        ////possibleMovements = game.Table.GetPiece(4, 0).PossibleMovements();
                        //Console.Clear();
                        //Display.PrintGame(game, possibleMovements);
                        //Console.WriteLine("Undo");
                        //Console.ReadKey();

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

                Console.Write("Game finished! ");
                Console.ForegroundColor = (ConsoleColor)game.ActualPlayer; 
                Console.Write($"{game.ActualPlayer} player won!");
            }
            catch (TableException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
