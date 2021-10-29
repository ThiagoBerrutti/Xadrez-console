using TableNS.Exceptions;
namespace TableNS
{
    class Table
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public Table(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, columns];
        }

        public Piece GetPiece(int line, int column)
        {
            return Pieces[line, column];
        }

        public Piece GetPiece(Position pos)
        {
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

        public bool HasPiece(Position pos)
        {
            ValidatePosition(pos);
            return GetPiece(pos) != null;
        }

        public bool ValidPosition(Position pos)
        {
            return !(pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns);            
        }

        public void ValidatePosition(Position pos)
        {
            if (!ValidPosition(pos))
            {
                throw new TableException("Error: invalid table position");
            }
        }

    }
}
