using TableNS;
using TableNS.Enums;

namespace Chess.Pieces
{
    class Knight : Piece
    {
        public Knight(Table table, Color color) : base(table, color)
        {
        }

        private bool CanMove(Position pos)
        {
            if (!Table.IsPositionValid(pos)) return false;
            Piece p = Table.GetPiece(pos);

            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] possibleMovements = new bool[Table.Lines, Table.Columns];


            Position pos = new Position(Position.Line + 2, Position.Column + 1);
            if (CanMove(pos))
            {
                possibleMovements[pos.Line, pos.Column] = true;
            }

            pos.SetValues(Position.Line + 2, Position.Column - 1);
            if (CanMove(pos))
            {
                possibleMovements[pos.Line, pos.Column] = true;
            }

            pos.SetValues(Position.Line - 2, Position.Column + 1);
            if (CanMove(pos))
            {
                possibleMovements[pos.Line, pos.Column] = true;
            }

            pos.SetValues(Position.Line - 2, Position.Column + 1);
            if (CanMove(pos))
            {
                possibleMovements[pos.Line, pos.Column] = true;
            }

            pos.SetValues(Position.Line + 1, Position.Column + 2);
            if (CanMove(pos))
            {
                possibleMovements[pos.Line, pos.Column] = true;
            }

            pos.SetValues(Position.Line + 1, Position.Column - 2);
            if (CanMove(pos))
            {
                possibleMovements[pos.Line, pos.Column] = true;
            }

            pos.SetValues(Position.Line - 1, Position.Column + 2);
            if (CanMove(pos))
            {
                possibleMovements[pos.Line, pos.Column] = true;
            }

            pos.SetValues(Position.Line - 1, Position.Column - 2);
            if (CanMove(pos))
            {
                possibleMovements[pos.Line, pos.Column] = true;
            }

            return possibleMovements;
        }

        public override string ToString()
        {
            return "C";
        }
    }
}