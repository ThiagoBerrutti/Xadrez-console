using TableNS.Enums;

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

        public Piece( Table table, Color color) : this()
        {
            Color = color;
            Table = table;            
        }

        public void IncreaseMovementsQuantity() 
        {
            MovementsQuantity++;
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

        public bool CanMoveTo(Position pos)
        {
            return PossibleMovements()[pos.Line, pos.Column];
        }

        public abstract bool[,] PossibleMovements();

    }
}
