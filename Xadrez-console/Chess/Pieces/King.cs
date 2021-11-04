using TableNS;
using TableNS.Enums;
using System;
using System.Collections.Generic;

namespace Chess.Pieces
{
    class King : Piece
    {

        private ChessGame Game;

        public King(Table table, Color color, ChessGame game) : base(table, color)
        {
            Game = game;
        }

        private bool CanMove(Position pos)
        {
            if (!Table.IsPositionValid(pos)) return false;
            //System.Console.WriteLine("Pos: "+ pos);
            Piece p = Table.GetPiece(pos);

            return (p == null || p.Color != Color);
        }

        public bool CanRookCastling(Position pos)
        {
            if (!Game.Table.IsPositionValid(pos))
            {
                return false;
            }

            Piece p = Game.Table.GetPiece(pos);
            return p != null && p is Rook && p.MovementsQuantity == 0 && p.Color == Color;
        }

        public bool CanLongCastling()
        {
            Position posRookCastling = new Position(Position.Line - 1, Position.Column);
            Position posKingCastling = new Position(Position.Line - 2, Position.Column);
            Position posMustBeEmpty = new Position(Position.Line - 3, Position.Column);        
            
            return Table.GetPiece(posRookCastling) == null && Table.GetPiece(posKingCastling) == null && Table.GetPiece(posMustBeEmpty) == null;
        }

        public bool CanShortCastling()
        {
            Position posRookCastling = new Position(Position.Line + 1, Position.Column);
            Position posKingCastling = new Position(Position.Line + 2, Position.Column);

            return Table.GetPiece(posRookCastling) == null && Table.GetPiece(posKingCastling) == null;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] possibleMovements = new bool[Table.Lines, Table.Columns];
            Position pos = new Position();

            pos.SetValues(Position.Line - 1, Position.Column);//4
            if (CanMove(pos))
            {
                possibleMovements[Position.Line - 1, Position.Column] = true;
            }

            pos.SetValues(Position.Line - 1, Position.Column - 1); //7
            if (CanMove(pos))
            {
                possibleMovements[Position.Line - 1, Position.Column - 1] = true;
            }

            pos.SetValues(Position.Line, Position.Column - 1); //8
            if (CanMove(pos))
            {
                possibleMovements[Position.Line, Position.Column - 1] = true;
            }

            pos.SetValues(Position.Line + 1, Position.Column - 1); //9
            if (CanMove(pos))
            {
                possibleMovements[Position.Line + 1, Position.Column - 1] = true;
            }

            pos.SetValues(Position.Line + 1, Position.Column); //6
            if (CanMove(pos))
            {
                possibleMovements[Position.Line + 1, Position.Column] = true;
            }

            pos.SetValues(Position.Line + 1, Position.Column + 1); //3
            if (CanMove(pos))
            {
                possibleMovements[Position.Line + 1, Position.Column + 1] = true;
            }

            pos.SetValues(Position.Line, Position.Column + 1); //2
            if (CanMove(pos))
            {
                possibleMovements[Position.Line, Position.Column + 1] = true;
            }

            pos.SetValues(Position.Line - 1, Position.Column + 1); //1
            if (CanMove(pos))
            {
                possibleMovements[Position.Line - 1, Position.Column + 1] = true;
            }

            // #special movement

            if (MovementsQuantity == 0 && !Game.Check)
            {
                // short castling
                Position rightRookPos = new Position(Position.Line + 3, Position.Column);
                if (CanRookCastling(rightRookPos))
                {
                    if (CanShortCastling())
                    {
                        possibleMovements[Position.Line + 2, Position.Column] = true;
                    }
                }

                //long castling
                Position leftRookPos = new Position(Position.Line - 4, Position.Column);
                if (CanRookCastling(leftRookPos))
                {
                    if (CanLongCastling())
                    {
                        possibleMovements[Position.Line - 2, Position.Column] = true;
                    }
                }
            }



            //            if (MovementsQuantity == 0 && !Game.Check)
            //            {
            //                Position rookPos = new Position(Position.Line + 3, Position.Column);
            //                if (CanRookCastling(rookPos))
            //                {
            //                    Position pos1 = new Position(Position.Line + 1, Position.Column);
            //        Position pos2 = new Position(Position.Line + 2, Position.Column);

            //                    if (Table.GetPiece(pos1) == null && Table.GetPiece(pos2) == null)
            //                    {
            //                        possibleMovements[pos2.Line, pos2.Column] = true;
            //                    }
            //}
            //            }

            return possibleMovements;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
