﻿using TableNS;
using TableNS.Enums;

namespace ChessGame.Pieces
{
    class King : Piece
    {
        public King(Table table, Color color) : base(table, color)
        {
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
