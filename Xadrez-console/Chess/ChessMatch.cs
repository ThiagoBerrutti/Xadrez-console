using TableNS;
using TableNS.Enums;
using Chess.Pieces;
using System;

namespace Chess
{
    class ChessMatch
    {
        public Table table { get; private set; }
        private int turn;
        private Color actualPlayer;
        public bool Finished { get; set; }

        public ChessMatch()
        {
            table = new Table(8, 8);
            turn = 1;
            actualPlayer = Color.White;
            SetTablePieces();
        }

        public void Move(ChessPosition origin, ChessPosition destiny)
        {

            Piece piece = table.RemovePiece(origin.ToPosition());
            piece.IncreaseMovementsQuantity();
            Piece capturedPiece = table.RemovePiece(origin.ToPosition());
            table.InsertPiece(piece, destiny);
            
        }

        public void SetTablePieces()
        {
            void SetPlayerPieces(int initialLine, Color color)
            {
                table.InsertPiece(new Rook(table, color), new ChessPosition('a', initialLine));
                table.InsertPiece(new Knight(table, color), new ChessPosition('b',initialLine));
                table.InsertPiece(new Bishop(table, color), new ChessPosition('c',initialLine));
                table.InsertPiece(new King(table, color), new ChessPosition('d',initialLine));
                table.InsertPiece(new Queen(table, color), new ChessPosition('e',initialLine));
                table.InsertPiece(new Bishop(table, color), new ChessPosition('f',initialLine));
                table.InsertPiece(new Knight(table, color), new ChessPosition('g',initialLine));
                table.InsertPiece(new Rook(table, color), new ChessPosition('h',initialLine));
                for (char i = 'a'; i <= 'h'; i++)
                {
                    if (initialLine == 8)
                    {
                        table.InsertPiece(new Pawn(table, color), new ChessPosition(i, 7));
                    }
                    else if (initialLine == 1)
                    {
                        table.InsertPiece(new Pawn(table, color), new ChessPosition(i, 2));
                    }
                }

            }
                SetPlayerPieces(8, Color.Black);
                SetPlayerPieces(1, Color.White);


        }
    }
}
