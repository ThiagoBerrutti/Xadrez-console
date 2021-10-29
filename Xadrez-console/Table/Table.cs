﻿namespace TableNS
{
    class Table
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public Table(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, columns];
        }

        public Piece GetPiece(int line, int column)
        {
            return Pieces[line, column];
        }

        public void InsertPiece(Piece piece, Position pos)
        {
            Pieces[pos.Line, pos.Column] = piece;
            piece.Position = pos;
        }

    }
}
