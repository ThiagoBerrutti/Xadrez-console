using Xadrez_console.TableNS.Enums;

namespace Xadrez_console.TableNS
{
    class Piece
    {
        public Position Position { get; set; }
        public string Name { get; set; }
        public Color Color { get; protected set; }
        public int MoveQuantity { get; protected set; }
        public Table Table { get; protected set; }

        public Piece()
        {
            MoveQuantity = 0;
        }

        public Piece(Position position, string name, Color color, Table table) : this()
        {
            Position = position;
            Name = name;
            Color = color;
            Table = table;            
        }
    }
}
