using System;

namespace Lib
{
    public class ConsoleSimbolClass
    {
        char simb; //символ
        int x; //координата x
        int y; //координата y
        public char Simb { get { return simb; } }
        public int X { get => x; }
        public int Y { get => y; }
        public ConsoleSimbolClass(char ch, int x, int y)
        {
            if (x < 0 || y < 0)
                throw new ArgumentOutOfRangeException();
            this.x = x;
            this.y = y;
            simb = ch;
        }




    }
}

