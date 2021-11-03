using TableNS.Enums;
using System.Collections.Generic;

namespace TableNS
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovementsQuantity { get; protected set; }
        public Table Table { get; protected set; }

        public Piece()
        {
            MovementsQuantity = 0;
        }

        public Piece(Table table, Color color) : this()
        {
            Color = color;
            Table = table;
        }

        public void DecreaseMovementsQuantity()
        {
            if (this != null)
            {
                MovementsQuantity--;
            }
        }
        public void IncreaseMovementsQuantity()
        {
            if (this != null)
            {
                MovementsQuantity++;
            }
        }

        public bool IsPossibleMovement(Position pos)
        {
            return PossibleMovements()[pos.Line, pos.Column];
        }
        public bool HasPossibleMovements()
        {
            bool[,] possibleMovements = PossibleMovements();

            for (int x = 0; x < Table.Lines; x++)
            {
                for (int y = 0; y < Table.Columns; y++)
                {
                    if (possibleMovements[x, y]) return true;
                }
            }

            return false;
        }


        public List<Position> PossibleMovementsList()
        {
            List<Position> possibleMovementsList = new List<Position>();
            bool[,] possibleMovements = PossibleMovements();


            for (int y = 0; y < possibleMovements.GetLength(1); y++)
            {
                for (int x = 0; x < possibleMovements.GetLength(0); x++)
                {
                    if (possibleMovements[x, y])
                    {
                        possibleMovementsList.Add(new Position(x, y));
                    }
                }
            }
            return possibleMovementsList;
        }

        public abstract bool[,] PossibleMovements();

    }
}
