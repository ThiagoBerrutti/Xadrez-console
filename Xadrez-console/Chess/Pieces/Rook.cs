using TableNS;
using TableNS.Enums;
using System;

namespace Chess.Pieces
{
    class Rook : Piece
    {
        public Rook(Table table, Color color) : base(table, color)
        {
        }

        public bool CanMove(Position pos)
        {
            if (!Table.ValidPosition(pos)) return false;
            //System.Console.WriteLine("Pos: "+ pos);
            Piece p = Table.GetPiece(pos);

            return (p == null || p.Color != Color);
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] possibleMovements = new bool[Table.Lines, Table.Columns];


            // esquerda
            Position pos = new Position()
            {
                Column = Position.Column
            };

            for (pos.Line = Position.Line - 1; pos.Line >= 0 && CanMove(pos); pos.Line--)
            {
                possibleMovements[pos.Line, pos.Column] = true;
                if (Table.GetPiece(pos) != null && Table.GetPiece(pos).Color != Color)
                {
                    break;
                }
            }


            // direita            
            for (pos.Line = Position.Line + 1; pos.Line < Table.Lines && CanMove(pos); pos.Line++)
            {
                possibleMovements[pos.Line, pos.Column] = true;
                if (Table.GetPiece(pos) != null && Table.GetPiece(pos).Color != Color)
                {
                    break;
                }
            }


            // cima          
            pos.Line = Position.Line;
            for (pos.Column = Position.Column - 1; pos.Column >= 0 && CanMove(pos); pos.Column--)
            {
                possibleMovements[pos.Line, pos.Column] = true;
                if (Table.GetPiece(pos) != null && Table.GetPiece(pos).Color != Color)
                {
                    break;
                }
            }


            // baixo            
            for (pos.Column = Position.Column + 1; pos.Column >= 0 && CanMove(pos); pos.Column++)
            {
                possibleMovements[pos.Line, pos.Column] = true;
                if (Table.GetPiece(pos) != null && Table.GetPiece(pos).Color != Color)
                {
                    break;
                }
            }


            return possibleMovements;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
