using TableNS;
using TableNS.Enums;

namespace ChessGame.Pieces
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
