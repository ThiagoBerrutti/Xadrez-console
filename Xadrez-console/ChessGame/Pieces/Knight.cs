using TableNS;
using TableNS.Enums;

namespace ChessGame.Pieces
{
    class Knight : Piece
    {
        public Knight(Table table, Color color) : base(table, color)
        {
        }

        public override string ToString()
        {
            return "C";
        }
    }
}