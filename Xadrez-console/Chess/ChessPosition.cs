using System;
using System.Collections.Generic;
using System.Text;
using TableNS;

namespace Chess
{
    class ChessPosition
    {
        public char Line { get; set; }
        public int Column { get; set; }

        public ChessPosition(char line, int column)
        {
            Column = column;
            Line = line;
        }

        public ChessPosition(Position pos)
        {
            Line = (char)(pos.Column + 'a');
            Column = 8 - pos.Line;
        }

        public Position ToPosition()
        {
            return new Position(Line - 'a', 8 - Column);
        }




        public override string ToString()
        {
            return "" + Line + Column;
        }


    }
}
