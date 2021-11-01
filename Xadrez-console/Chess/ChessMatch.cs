using TableNS;
using TableNS.Enums;
using Chess.Pieces;
using System.Collections.Generic;
using TableNS.Exceptions;

namespace Chess
{
    class ChessMatch
    {
        public Table Table { get; private set; }
        public int Turn { get; private set; }
        public Color ActualPlayer { get; private set; }
        public bool Finished { get; set; }
        public List<Piece> BlackPieces { get; protected set; }
        public List<Piece> WhitePieces { get; protected set; }

        public List<Piece> CapturedBlackPieces { get; protected set; }
        public List<Piece> CapturedWhitePieces { get; protected set; }

        public ChessMatch()
        {
            Table = new Table(8, 8);
            Turn = 1;
            ActualPlayer = Color.White;
            BlackPieces = new List<Piece>();
            WhitePieces = new List<Piece>();
            CapturedBlackPieces = new List<Piece>();
            CapturedWhitePieces = new List<Piece>();
            SetTablePieces();
        }



        public void Move(ChessPosition origin, ChessPosition destiny)
        {
            Piece piece = Table.RemovePiece(origin.ToPosition());
            piece.IncreaseMovementsQuantity();
            Piece capturedPiece = Table.RemovePiece(origin.ToPosition());
            Table.InsertPiece(piece, destiny);
        }

        public void Move(Position origin, Position destiny)
        {
            Piece piece = Table.RemovePiece(origin);
            piece.IncreaseMovementsQuantity();
            CapturePiece(destiny);
            Table.InsertPiece(piece, destiny);
        }

        public void CapturePiece(Position pos)
        {
            Piece capturedPiece = Table.RemovePiece(pos);
            if (capturedPiece != null)
            {
                if (capturedPiece.Color == Color.White)
                {
                    CapturedWhitePieces.Add(capturedPiece);
                }
                else if (capturedPiece.Color == Color.Black)
                {
                    CapturedBlackPieces.Add(capturedPiece);
                }
            }
        }

        public void ExecutePlay(ChessPosition origin, ChessPosition destiny)
        {

            Move(origin, destiny);
            Turn++;
            ChangeActualPlayer();
        }

        public void ExecutePlay(Position origin, Position destiny)
        {
            if (Table.GetPiece(destiny) != null)
            {

            }
            Move(origin, destiny);
            Turn++;
            ChangeActualPlayer();
        }

        private void ChangeActualPlayer()
        {
            if (ActualPlayer == Color.White)
            {
                ActualPlayer = Color.Black;
            }
            else
            {
                ActualPlayer = Color.White;
            }
        }

        private void SetPiece(Piece piece, Position pos)
        {
            if (piece.Color == Color.Black)
            {
                BlackPieces.Add(piece);
            }
            else if (piece.Color == Color.White)
            {
                WhitePieces.Add(piece);
            }

            Table.InsertPiece(piece, pos);

        }

        public void SetTablePieces()
        {
            void SetPlayerPieces(int initialLine, Color color)
            {
                SetPiece(new Rook(Table, color), new Position(0, initialLine));
                SetPiece(new Knight(Table, color), new Position(1, initialLine));
                SetPiece(new Bishop(Table, color), new Position(2, initialLine));
                SetPiece(new King(Table, color), new Position(3, initialLine));
                SetPiece(new Queen(Table, color), new Position(4, initialLine));
                SetPiece(new Bishop(Table, color), new Position(5, initialLine));
                SetPiece(new Knight(Table, color), new Position(6, initialLine));
                SetPiece(new Rook(Table, color), new Position(7, initialLine));
                for (int i = 0; i < 8; i++)
                {
                    if (initialLine == 0)
                    {
                        SetPiece(new Pawn(Table, color), new Position(i, 1));
                    }
                    else if (initialLine == 7)
                    {
                        SetPiece(new Pawn(Table, color), new Position(i, 6));
                    }
                }

            }
            SetPlayerPieces(0, Color.Black);
            SetPlayerPieces(7, Color.White);
        }

        public void ValidateOriginPosition(Position pos)
        {
            Piece piece = Table.GetPiece(pos);
            if (piece == null)
            {
                throw new TableException("Selected position can not be empty.");
            }

            if (piece.Color != ActualPlayer)
            {
                throw new TableException($"Selected piece can not be moved. Please select a {ActualPlayer} piece.");
            }

            if (!piece.HasPossibleMovements())
            {
                throw new TableException("Selected piece has no possible movements.");
            }
        }

        public void ValidateDestinyPosition(Position origin, Position destiny)
        {
            Piece originPiece = Table.GetPiece(origin);

            if (!originPiece.CanMoveTo(destiny))
            {
                throw new TableException("Cannot move to selected position.");
            }
        }
    }
}
