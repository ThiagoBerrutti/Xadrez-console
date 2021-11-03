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
        public bool GameFinished { get; set; }
        public bool Check { get; set; }


        public HashSet<Piece> Pieces { get; private set; }
        public HashSet<Piece> CapturedPieces { get; private set; }

        public ChessGame()
        {
            Table = new Table(8, 8);
            Turn = 1;
            ActualPlayer = Color.White;
            CapturedPieces = new HashSet<Piece>();
            Pieces = new HashSet<Piece>();
            Check = false;
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
            HashSet<Piece> onTable = new HashSet<Piece>();

            foreach (Piece p in Pieces)
            {
                onTable.Add(p);
            }
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
            Piece capturedPiece = Table.RemovePiece(destiny);

            if (piece != null)
            {
                piece.IncreaseMovementsQuantity();
                Table.InsertPiece(piece, destiny);
            }
           
            AddToCapturedPieces(capturedPiece);

            return capturedPiece;
        }

        public void ExecutePlay(Position origin, Position destiny)
        {
            Piece capturedPiece = Move(origin, destiny);
            ValidateMoveNotOnCheck(origin, destiny, capturedPiece);
            if (IsOnCheck(Opponent(ActualPlayer))){
            
                Check = true;
                                    
                if (IsOnCheckMate(Opponent(ActualPlayer)))
                {
                    
                    GameFinished = true;
                }
            }
            else
            {
                Check = false;
            }            

            Turn++;
            ChangeActualPlayer();
        }
        
        private void UndoPlay(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece piece = Table.GetPiece(destiny);            

            if (piece != null)
            {
                Move(destiny, origin);
                piece.DecreaseMovementsQuantity();

                if (capturedPiece != null)
                {
                    Table.InsertPiece(capturedPiece, destiny);
                    CapturedPieces.Remove(capturedPiece);
                }
            }
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

        public bool IsOnCheck(Color color)
        {
            HashSet<Piece> enemyPieces = GetPiecesOnTableByDifferentColor(color);
            
            foreach (Piece enemy in enemyPieces)
            {
                foreach (Position p in enemy.PossibleMovementsList())
                {
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
                    Piece capturedPiece = null;
                    try
                    {
                        capturedPiece = Move(piecePosition, possibleMovement);
                        ValidateMoveNotOnCheck(piecePosition, possibleMovement, capturedPiece);
                        
                        //if pass the validation, it isn't on check anymore

                        UndoPlay(piecePosition, possibleMovement, capturedPiece);
                        return false;
                    }
                    catch (CheckException)
                    {   
                    }                    
                }
            }
            return true;
        }

        public void UpdateCheckProperty()
        {
            Check = IsOnCheck(ActualPlayer);
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

            if (!originPiece.IsPossibleMovement(destiny))
            {
                throw new TableException("Cannot move to selected position.");
            }
        }
        private void ValidateMoveNotOnCheck(Position origin, Position destiny, Piece capturedPiece)
        {
            if (IsOnCheck(ActualPlayer))
            {
                UndoPlay(origin, destiny, capturedPiece);
                throw new CheckException("You can't end your turn at check!");
            }
        }
        private void AddToCapturedPieces(Piece capturedPiece)
        {
            if (capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }
        }
        public Color Opponent(Color actualPlayer)
        {
            if (actualPlayer == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }
    }
}
