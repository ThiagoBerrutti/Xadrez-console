using System;
using TableNS;
using ChessGame.Pieces;
using TableNS.Enums;
using ChessGame;


namespace Xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {

            Chess Game = new Chess();
            Game.SetTablePieces();
            Display.PrintTable(Game.Table);
        }
    }
}
