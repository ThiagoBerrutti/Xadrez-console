﻿using TableNS.Enums;

namespace TableNS
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MoveQuantity { get; protected set; }
        public Table Table { get; protected set; }

        public Piece()
        {
            MoveQuantity = 0;
        }

        public Piece( Table table, Color color) : this()
        {
            Color = color;
            Table = table;            
        }
    }
}
