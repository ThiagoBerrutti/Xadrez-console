﻿using TableNS;
using TableNS.Enums;

namespace Chess.Pieces
{
    class Queen : Piece
    {
        public Queen(Table table, Color color) : base(table, color)
        {
        }

        public bool CanMove(Position pos)
        {
            if (!Table.IsPositionValid(pos)) return false;
            //System.Console.WriteLine("Pos: "+ pos);
            Piece p = Table.GetPiece(pos);

            return (p == null || p.Color != Color);
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] possibleMovements = new bool[Table.Lines, Table.Columns];

            // Horizontal

            // 4
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


            // 6            
            for (pos.Line = Position.Line + 1; pos.Line < Table.Lines && CanMove(pos); pos.Line++)
            {
                possibleMovements[pos.Line, pos.Column] = true;
                if (Table.GetPiece(pos) != null && Table.GetPiece(pos).Color != Color)
                {
                    break;
                }
            }


            // 8          
            pos.Line = Position.Line;
            for (pos.Column = Position.Column - 1; pos.Column >= 0 && CanMove(pos); pos.Column--)
            {
                possibleMovements[pos.Line, pos.Column] = true;
                if (Table.GetPiece(pos) != null && Table.GetPiece(pos).Color != Color)
                {
                    break;
                }
            }


            // 2            
            for (pos.Column = Position.Column + 1; pos.Column >= 0 && CanMove(pos); pos.Column++)
            {
                possibleMovements[pos.Line, pos.Column] = true;
                if (Table.GetPiece(pos) != null && Table.GetPiece(pos).Color != Color)
                {
                    break;
                }
            }

            // Diagonal

            // 7
            pos.SetValues(Position.Line - 1, Position.Column - 1);
            for (pos.Line = Position.Line - 1; /*pos.Line >= 0 && pos.Column>= 0 && */CanMove(pos); pos.Line--)
            {
                possibleMovements[pos.Line, pos.Column] = true;
                if (Table.GetPiece(pos) != null && Table.GetPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Column--;
            }


            // 9
            pos.SetValues(Position.Line + 1, Position.Column - 1);
            for (pos.Line = Position.Line + 1; /*pos.Line < Table.Lines && pos.Column >= 0 && */CanMove(pos); pos.Line++)
            {
                possibleMovements[pos.Line, pos.Column] = true;
                if (Table.GetPiece(pos) != null && Table.GetPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Column--;
            }


            // 3         
            pos.SetValues(Position.Line + 1, Position.Column + 1);
            for (pos.Column = Position.Column + 1; /*pos.Column >= 0 && pos.Line < Table.Lines && */CanMove(pos); pos.Column--)
            {
                possibleMovements[pos.Line, pos.Column] = true;
                if (Table.GetPiece(pos) != null && Table.GetPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Line++;
            }


            // 1
            pos.SetValues(Position.Line - 1, Position.Column + 1);
            for (pos.Column = Position.Column + 1; /*pos.Column >= 0 && pos.Line>0 && */CanMove(pos); pos.Column++)
            {
                possibleMovements[pos.Line, pos.Column] = true;
                if (Table.GetPiece(pos) != null && Table.GetPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Line--;

            }


            return possibleMovements;
        }

        public override string ToString()
        {
            return "Q";
        }
    }
}