using TableNS.Exceptions;
using Chess;
using System;
namespace TableNS
{
    class Table
    {
        public int Lines { get; private set; } 
        public int Columns { get; private set; }
        private Piece[,] Pieces;

        public Table(int columns, int lines)
        {
            Lines = lines; // pensando --> Lines é o total de linhas (ou seja, quantos indices por coluna)
            Columns = columns; //Columns é o total de colunas (ou seja, quantos indices por linha)
            Pieces = new Piece[Lines, Columns]; //uma matriz 3x4 (x=3,y=4) tem 3 indices no x, e 4 indices no y.
                                                //Considerando a sintaxe Table.Pieces[nro. de indices X, nro de indices Y], 
                                                //pra construir a matriz, o nro de indices no eixo X é igual ao numero de colunas...
                                                //e o numero de indices no eixo Y é igual ao numero de linhas existentes
                                                // --> na verdade, é Lines = TAMANHO DA LINHA e Columns = TAMANHO DA COLUNA.
        }

        public Piece GetPiece(int line, int column)
        {
            return Pieces[line, column];
        }

        public Piece GetPiece(Position pos)
        {
            return Pieces[pos.Line, pos.Column];
        }

        public void InsertPiece(Piece piece, Position pos)
        {
            if (HasPiece(pos))
            {
                throw new TableException("This position already has a piece.");
            }
            Pieces[pos.Line, pos.Column] = piece;
            piece.Position = pos;
        }

        public void InsertPiece(Piece piece, ChessPosition pos)
        {
            InsertPiece(piece, pos.ToPosition());
        }

        public Piece RemovePiece(Position pos)
        {
            if (!HasPiece(pos))
            {
                return null;
            };

            Piece removedPiece = GetPiece(pos);
            removedPiece.Position = null;
            Pieces[pos.Line, pos.Column] = null;
            return removedPiece;
        }

        public bool HasPiece(Position pos)
        {
            ValidatePosition(pos);
            return GetPiece(pos) != null;
        }

        public bool ValidPosition(Position pos)
        {
            return !(pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns);            
        }

        public void ValidatePosition(Position pos)
        {
            if (!ValidPosition(pos))
            {
                throw new TableException("Error: invalid table position");
            }
        }

    }
}
