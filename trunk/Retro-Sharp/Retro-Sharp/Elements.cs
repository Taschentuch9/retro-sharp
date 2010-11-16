using System;

namespace CSharp_Moving
{
    class Elements
    {
        public char Live = '+';
        Random r = new Random();
        public Elements()
        {
        }
        public object Return()
        {
            int Rdm=r.Next(1, 100);
            if (Rdm == 20)
                return '+';
            if (Rdm == 40)
                return '-';
            if (Rdm == 60)
                return '#';
            return ' ';
        }
    }
}
