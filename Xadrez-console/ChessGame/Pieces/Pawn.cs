﻿using TableNS;
using TableNS.Enums;

namespace ChessGame.Pieces
{
    class Pawn : Piece
    {
        public Pawn(Table table, Color color) : base(table, color)
        {
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
