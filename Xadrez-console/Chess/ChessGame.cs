using TableNS;
using TableNS.Enums;
using Chess.Pieces;
using System.Collections.Generic;
using TableNS.Exceptions;
using System;
using Xadrez_console;
using Chess.Exceptions;

namespace Chess
{
    class ChessGame
    {
        public Table Table { get; private set; }
        public int Turn { get; private set; }
        public Color ActualPlayer { get; private set; }
        public bool Finished { get; set; }
        public int Cont;

        public HashSet<Piece> Pieces { get; private set; }
        public HashSet<Piece> CapturedPieces { get; private set; }

        public ChessGame()
        {
            Table = new Table(8, 8);
            Turn = 1;
            
            ActualPlayer = Color.White;
            Cont = 0;
            CapturedPieces = new HashSet<Piece>();
            Pieces = new HashSet<Piece>();

            SetTablePieces();
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
        public HashSet<Piece> GetPiecesOnTableByDifferentColor(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            HashSet<Piece> onTable = GetPiecesOnTable();

            foreach (Piece p in onTable)
            {
                if (p.Color != color)
                {
                    aux.Add(p);
                }
            }

            return aux;
        }
        public HashSet<Piece> GetPiecesOnTableByColor(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            HashSet<Piece> onTable = GetPiecesOnTable();

            foreach (Piece p in onTable)
            {
                if (p.Color == color)
                {
                    aux.Add(p);
                }
            }

            return aux;
        }

        public Piece Move(Position origin, Position destiny)
        {
            Piece piece = Table.RemovePiece(origin);
            piece.IncreaseMovementsQuantity();
            Piece capturedPiece = CapturePiece(destiny);
            Table.InsertPiece(piece, destiny);

            return capturedPiece;
        }

        public void ExecutePlay(Position origin, Position destiny)
        {
            Piece capturedPiece = Move(origin, destiny);

            if (IsOnCheck(ActualPlayer,true))
            {
                UndoPlay(origin, destiny, capturedPiece);
                Console.WriteLine();
                throw new CheckException("You can't put yourself on check!"); 
            }
            else
            {
                Turn++;
                ChangeActualPlayer();
            }
        }

        private void UndoPlay(Position origin, Position destiny, Piece capturedPiece)
        {
            Move(destiny, origin);
            if (capturedPiece != null)
            {
                Table.InsertPiece(capturedPiece, destiny);
            }
        }

        public Piece CapturePiece(Position pos)
        {
            Piece capturedPiece = Table.RemovePiece(pos);
            if (capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }
            return capturedPiece;
        }
        public void SetPiece(Piece piece, Position pos)
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

        public bool IsOnCheck(Color color, bool cont)
        {
            HashSet<Piece> enemyPieces = GetPiecesOnTableByDifferentColor(color);
            
            foreach (Piece enemy in enemyPieces)
            {
                foreach (Position p in enemy.PossibleMovementsList())
                {
                    if (cont) Cont++;
                    if (Table.GetPiece(p) is King)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        
        public bool IsOnCheckMate(Color color)
        {
            HashSet<Piece> allyPieces = GetPiecesOnTableByColor(color);
            
            foreach (Piece piece in allyPieces)
            {
                foreach (Position possibleMovement in piece.PossibleMovementsList())
                {
                    Position piecePosition = piece.Position;
                    Piece capturedPiece = Move(piecePosition, possibleMovement);

                    if (!IsOnCheck(ActualPlayer,true))
                    {
                        UndoPlay(piecePosition, possibleMovement, capturedPiece);
                        return false;
                    }

                    UndoPlay(piecePosition, possibleMovement, capturedPiece);
                }
            }

            return false;
        }
    }
}
