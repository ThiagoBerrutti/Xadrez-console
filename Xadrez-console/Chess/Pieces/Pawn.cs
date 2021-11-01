using TableNS;
using TableNS.Enums;

namespace Chess.Pieces
{
    class Pawn : Piece
    {
        public Pawn(Table table, Color color) : base(table, color)
        {
        }

        public override bool[,] PossibleMovements()
        {
            return new bool[8, 8];
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
