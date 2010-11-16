using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Retro_Sharp
{
    class PlayerStats
    {
        public bool dead;
        public int PositionX;
        public int PositionY;
        public int Lifes;
        public int Slowmotions;
        public char PlayerIcon = 'O';

        public PlayerStats()
        {
            this.PositionX = ObjectCollection.Field.GetLength(0) / 2 + 1;
            this.PositionY = ObjectCollection.Field.GetLength(1)-1;
            this.Lifes = 3;
            this.Slowmotions = 1;
            this.dead = false;
        }
    }
}
