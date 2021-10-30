using ChessGame;
namespace TableNS
{
    class Position
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public Position()
        {
        }

        public Position(int line, int column)
        {
            Line = line;
            Column = column;
        }

        public Position(ChessPosition chessPosition)
        {
            Position position = chessPosition.ToPosition();
            Line = position.Line;
            Column = position.Column;
        }

        public ChessPosition ToChessPosition()
        {
            return new ChessPosition((char)(Line + 'a'), 8 - Column);
        }

        public override string ToString()
        {
            return $"{Line}, {Column}";
        }
    }
}
