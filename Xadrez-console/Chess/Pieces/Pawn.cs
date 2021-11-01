using TableNS;
using TableNS.Enums;

namespace Chess.Pieces
{
    class Pawn : Piece
    {
        public Pawn(Table table, Color color) : base(table, color)
        {
        }

        //private bool CanPassant(Position pos)
        //{
        //    Piece piece = Table.GetPiece(pos);

        //    if (piece != null && piece. == Pawn && piece.MovementsQuantity == 1 )
        //}

        private bool CanMove(Position pos)
        {
            if (!Table.IsPositionValid(pos)) return false;
            Piece p = Table.GetPiece(pos);

            return p == null || p.Color != Color;
        }

        private bool CanAttack(Position pos)
        {
            if (!Table.IsPositionValid(pos)) return false;
            Piece p = Table.GetPiece(pos);

            return p != null && p.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
        //    bool[,] possibleMovements = new bool[Table.Lines, Table.Columns];
        //    Position pos = new Position();
        //    int direction;

        //    if (Color == Color.White)
        //    {
        //        direction = -1;
        //    }
        //    else direction = 1;

        //    pos.SetValues(Position.Line, Position.Column + 1 * direction);//casa a frente
        //    if (CanMove(pos))
        //    {
        //        possibleMovements[pos.Line, pos.Column] = true;
        //        if (MovementsQuantity == 0)
        //        {
        //            pos.SetValues(Position.Line, Position.Column + 2 * direction);//primeiro movimento
        //            if (CanMove(pos))
        //            {
        //                possibleMovements[pos.Line, pos.Column] = true;
        //            }
        //        }
        //    }

        //    pos.SetValues(Position.Line) 

        //    pos.SetValues(Position.Line - 1, Position.Column - 1); //7
        //    if (CanMove(pos))
        //    {
        //        possibleMovements[Position.Line - 1, Position.Column - 1] = true;
        //        Console.WriteLine("Possible position: " + pos.ToChessPosition() + ", " + pos);
        //    }

        //    pos.SetValues(Position.Line, Position.Column - 1); //8
        //    if (CanMove(pos))
        //    {
        //        possibleMovements[Position.Line, Position.Column - 1] = true;
        //        Console.WriteLine("Possible position: " + pos.ToChessPosition() + ", " + pos);
        //    }

        //    pos.SetValues(Position.Line + 1, Position.Column - 1); //9
        //    if (CanMove(pos))
        //    {
        //        possibleMovements[Position.Line + 1, Position.Column - 1] = true;
        //        Console.WriteLine("Possible position: " + pos.ToChessPosition() + ", " + pos);
        //    }

        //    pos.SetValues(Position.Line + 1, Position.Column); //6
        //    if (CanMove(pos))
        //    {
        //        possibleMovements[Position.Line + 1, Position.Column] = true;
        //        Console.WriteLine("Possible position: " + pos.ToChessPosition() + ", " + pos);
        //    }

        //    pos.SetValues(Position.Line + 1, Position.Column + 1); //3
        //    if (CanMove(pos))
        //    {
        //        possibleMovements[Position.Line + 1, Position.Column + 1] = true;
        //        Console.WriteLine("Possible position: " + pos.ToChessPosition() + ", " + pos);
        //    }

        //    pos.SetValues(Position.Line, Position.Column + 1); //2
        //    if (CanMove(pos))
        //    {
        //        possibleMovements[Position.Line, Position.Column + 1] = true;
        //        Console.WriteLine("Possible position: " + pos.ToChessPosition() + ", " + pos);
        //    }

        //    pos.SetValues(Position.Line - 1, Position.Column + 1); //1
        //    if (CanMove(pos))
        //    {
        //        possibleMovements[Position.Line - 1, Position.Column + 1] = true;
        //        Console.WriteLine("Possible position: " + pos.ToChessPosition() + ", " + pos);
        //    }

        //    if (MovementsQuantity = 0)

                return new bool[8, 8];
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
