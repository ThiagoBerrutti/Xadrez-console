using System;
using Xadrez_console.TableNS;

namespace Xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Table tab = new Table(8, 8);
            Display.PrintTable(tab);
        }
    }
}
