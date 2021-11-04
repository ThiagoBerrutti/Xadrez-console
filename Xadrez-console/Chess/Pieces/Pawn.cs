using TableNS;
using TableNS.Enums;

namespace Chess.Pieces
{
    class Pawn : Piece
    {
        public int Direction { get; private set; }
        public ChessGame Game { get; private set; }

        public Pawn(Table table, Color color, ChessGame game) : base(table, color)
        {
            Direction = SetDirectionValue();
            Game = game;
        }


        private bool CanMove(Position pos)
        {
            if (!Table.IsPositionValid(pos)) return false;
            Piece p = Table.GetPiece(pos);

            return p == null || p.Color != Color;
        }

        public bool CanAttack(Position pos)
        {
            if (!Table.IsPositionValid(pos)) return false;
            Piece p = Table.GetPiece(pos);

            return p != null && p.Color != Color;
        }

        private int SetDirectionValue()
        {
            if (Color == Color.Black)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] possibleMovements = new bool[Table.Lines, Table.Columns];
            Position pos = new Position();

            pos.SetValues(Position.Line, Position.Column + Direction);
            if (CanMove(pos))
            {
                possibleMovements[pos.Line, pos.Column] = true;

                if (MovementsQuantity == 0) //1o movimento
                {
                    pos.SetValues(Position.Line, Position.Column + 2 * Direction);
                    if (CanMove(pos))
                    {
                        possibleMovements[pos.Line, pos.Column] = true;
                    }
                }
            }

            //inimigo a esquerda
            pos.SetValues(Position.Line - 1, Position.Column + Direction);
            if (CanAttack(pos))
            {
                possibleMovements[pos.Line, pos.Column] = true;
            }

            //inimigo a direita
            pos.SetValues(Position.Line + 1, Position.Column + Direction);
            if (CanAttack(pos))
            {
                possibleMovements[pos.Line, pos.Column] = true;
            }

            //en passant esquerda
            Piece enemy;
            pos.SetValues(Position.Line - 1, Position.Column);

            if (Table.IsPositionValid(pos))
            {
                enemy = Table.GetPiece(pos);

                if (CanAttack(pos) && enemy == Game.VulnerableEnPassant)
                {
                    possibleMovements[pos.Line, pos.Column + Direction] = true;
                }
            }

            //en passant direita
            pos.SetValues(Position.Line + 1, Position.Column);
            if (Table.IsPositionValid(pos))
            {
                enemy = Table.GetPiece(pos);

                if (CanAttack(pos) && enemy == Game.VulnerableEnPassant)
                {
                    possibleMovements[pos.Line, pos.Column + Direction] = true;
                }
            }

            return possibleMovements;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
