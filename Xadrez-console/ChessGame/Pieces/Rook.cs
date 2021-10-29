using TableNS;
using TableNS.Enums;

namespace ChessGame.Pieces
{
   
        class Rook : Piece
        {
            public Rook(Table table, Color color) : base(table, color)
            {
            }

            public override string ToString()
            {
                return "T";
            }
        }
}
