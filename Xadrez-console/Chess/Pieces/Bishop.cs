using TableNS;
using TableNS.Enums;

namespace Chess.Pieces
{
    class Bishop : Piece
    {
        public Bishop(Table table, Color color) : base(table, color)
        {
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
