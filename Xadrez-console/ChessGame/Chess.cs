using System;
using System.Collections.Generic;
using System.Text;
using TableNS;
using TableNS.Enums;
using ChessGame.Pieces;

namespace ChessGame
{
    class Chess
    {
        public Table Table { get; protected set; }

        public Chess()
        {
            Table = new Table(8, 8);
        }


        public void SetTablePieces()
        {
             void SetPlayerPieces(int initialLine, Color color)
            {
                Table.InsertPiece(new Rook(Table, color), new Position(initialLine, 0));
                Table.InsertPiece(new Knight(Table, color), new Position(initialLine, 1));
                Table.InsertPiece(new Bishop(Table, color), new Position(initialLine, 2));
                Table.InsertPiece(new King(Table, color), new Position(initialLine, 3));
                Table.InsertPiece(new Queen(Table, color), new Position(initialLine, 4));
                Table.InsertPiece(new Bishop(Table, color), new Position(initialLine, 5));
                Table.InsertPiece(new Knight(Table, color), new Position(initialLine, 6));
                Table.InsertPiece(new Rook(Table, color), new Position(initialLine, 7));
                for (int i = 0; i < 8; i++)
                {
                    if (initialLine == 0) { 
                        Table.InsertPiece(new Pawn(Table, color), new Position(1, i)); 
                    }
                    else if (initialLine == 7) {
                        Table.InsertPiece(new Pawn(Table, color), new Position(6, i)); 
                    }
                }
            }

            SetPlayerPieces(0, Color.Black);
            SetPlayerPieces(7, Color.White);
        }


    }
}
