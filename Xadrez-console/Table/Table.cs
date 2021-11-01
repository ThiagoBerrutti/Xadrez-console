using TableNS.Exceptions;
using Chess;
using System;
namespace TableNS
{
    class Table
    {
        public int Lines { get; private set; } 
        public int Columns { get; private set; }
        private Piece[,] Pieces;

        public Table(int columns, int lines)
        {
            Lines = lines; 
            Columns = columns; 
            Pieces = new Piece[Lines, Columns]; 
        }

        public Piece GetPiece(int line, int column)
        {
            return Pieces[line, column];
        }
        public Piece GetPiece(Position pos)
        {
            return Pieces[pos.Line, pos.Column];
        }
        public Piece GetPiece(ChessPosition chessPos)
        {
            Position pos = chessPos.ToPosition();
            return Pieces[pos.Line, pos.Column];
        }

        public void InsertPiece(Piece piece, Position pos)
        {
            if (HasPiece(pos))
            {
                throw new TableException("This position already has a piece.");
            }
            Pieces[pos.Line, pos.Column] = piece;
            piece.Position = pos;
        }
        public void InsertPiece(Piece piece, ChessPosition pos)
        {
            InsertPiece(piece, pos.ToPosition());
        }

        public Piece RemovePiece(Position pos)
        {
            if (!HasPiece(pos))
            {
                return null;
            };

            Piece removedPiece = GetPiece(pos);
            removedPiece.Position = null;
            Pieces[pos.Line, pos.Column] = null;
            return removedPiece;
        }

        public bool HasPiece(Position pos)
        {
            ValidatePosition(pos);
            return GetPiece(pos) != null;
        }
        public bool IsPositionValid(Position pos)
        {
            return !(pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns);            
        }
        public void ValidatePosition(Position pos)
        {
            if (!IsPositionValid(pos))
            {
                throw new TableException("Error: invalid table position");
            }
        }

    }
}
