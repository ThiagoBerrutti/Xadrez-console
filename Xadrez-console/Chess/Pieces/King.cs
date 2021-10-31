using TableNS;
using TableNS.Enums;
using System;

namespace Chess.Pieces
{
    class King : Piece
    {
        public King(Table table, Color color) : base(table, color)
        {
        }

        private bool CanMove(Position pos)
        {
            if (!Table.ValidPosition(pos)) return false;
            //System.Console.WriteLine("Pos: "+ pos);
            Piece p = Table.GetPiece(pos);
            
            return (p == null || p.Color != Color  );
        }

        public bool[,] PossibleMovements()
        {
            bool[,] possibleMovements = new bool[Table.Lines, Table.Columns];
            Position pos = new Position();

            Console.WriteLine("Actual position: "+Position.ToChessPosition() + ", " + pos);

            pos.SetValues(Position.Line - 1, Position.Column);//4
            if (CanMove(pos)) {
                possibleMovements[Position.Line - 1, Position.Column] = true;
                Console.WriteLine("Possible position: "+pos.ToChessPosition() + ", " + pos);
            }

            pos.SetValues(Position.Line - 1, Position.Column - 1); //7
            if (CanMove(pos))
            {
                possibleMovements[Position.Line - 1, Position.Column - 1] = true;
                Console.WriteLine("Possible position: " + pos.ToChessPosition() + ", " + pos);
            }

            pos.SetValues(Position.Line, Position.Column - 1); //8
            if (CanMove(pos))
            {
                possibleMovements[Position.Line, Position.Column - 1] = true;
                Console.WriteLine("Possible position: " + pos.ToChessPosition() + ", " + pos);
            }
            
            pos.SetValues(Position.Line + 1, Position.Column - 1); //9
            if (CanMove(pos))
            {
                possibleMovements[Position.Line + 1, Position.Column - 1] = true;
                Console.WriteLine("Possible position: " + pos.ToChessPosition() + ", " + pos);
            }

            pos.SetValues(Position.Line + 1, Position.Column); //6
            if (CanMove(pos))
            {
                possibleMovements[Position.Line + 1, Position.Column] = true;
                Console.WriteLine("Possible position: " + pos.ToChessPosition() + ", " + pos);
            }

            pos.SetValues(Position.Line + 1, Position.Column + 1); //3
            if (CanMove(pos))
            {
                possibleMovements[Position.Line + 1, Position.Column + 1] = true;
                Console.WriteLine("Possible position: " + pos.ToChessPosition() + ", " + pos);
            }

            pos.SetValues(Position.Line, Position.Column + 1); //2
            if (CanMove(pos))
            {
                possibleMovements[Position.Line, Position.Column + 1] = true;
                Console.WriteLine("Possible position: " + pos.ToChessPosition() + ", " + pos);
            }

            pos.SetValues(Position.Line - 1, Position.Column + 1); //1
            if (CanMove(pos))
            {
                possibleMovements[Position.Line - 1, Position.Column + 1] = true;
                Console.WriteLine("Possible position: " + pos.ToChessPosition()+", "+pos);
            }

            return possibleMovements;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
