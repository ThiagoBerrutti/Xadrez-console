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

        public HashSet<Piece> Pieces { get; private set; }
        public HashSet<Piece> CapturedPieces { get; private set; }

        public HashSet<Piece> BlackPieces { get; protected set; }
        public HashSet<Piece> WhitePieces { get; protected set; }

        public HashSet<Piece> CapturedBlackPieces { get; protected set; }
        public HashSet<Piece> CapturedWhitePieces { get; protected set; }

        public ChessMatch()
        {
            Table = new Table(8, 8);
            Turn = 1;
            ActualPlayer = Color.White;
            BlackPieces = new HashSet<Piece>();
            WhitePieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            Pieces = new HashSet<Piece>();
            CapturedBlackPieces = new HashSet<Piece>();
            CapturedWhitePieces = new HashSet<Piece>();
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

        public void ExecutePlay(ChessPosition origin, ChessPosition destiny)
        {
            Move(origin, destiny);
            Turn++;
            ChangeActualPlayer();
        }

        public void ExecutePlay(Position origin, Position destiny)
        {
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

        public HashSet<Piece> GetCapturedPiecesByColor(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();

            foreach (Piece p in CapturedPieces)
            {
                if (p.Color == color)
                {
                    aux.Add(p);
                }
            }

            return aux;
        }

        public HashSet<Piece> GetPiecesOnTable()
        {
            HashSet<Piece> onTable = Pieces;
            onTable.ExceptWith(CapturedPieces);

            return onTable;

        }

        public HashSet<Piece> GetPiecesOnTableByColor(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in aux)
            {
                if (p.Color == color)
                {
                    aux.Add(p);
                }
            }

            return aux;
        }

        public void CapturePiece(Position pos)
        {
            Piece capturedPiece = Table.RemovePiece(pos);
            if (capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }
        }

        private void SetPiece(Piece piece, Position pos)
        {
            Table.InsertPiece(piece, pos);
            Pieces.Add(piece);
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
