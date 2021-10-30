using System;
using System.Collections.Generic;
using System.Text;
using TableNS;

namespace ChessGame
{
    class ChessPosition
    {
        public int Line { get; set; }
        public char Column { get; set; }

        public ChessPosition(char column, int line)
        {
            Column = column;
            Line = line;
        }

        public ChessPosition(Position pos)
        {
            Column = (char)(pos.Column + 'a');
            Line = 8 - pos.Line;
        }

        public Position ToPosition()
        {
            return new Position(8 - Line, Column - 'a');
        }


        public override string ToString()
        {
            return "" + Column + Line;
        }


    }
}
