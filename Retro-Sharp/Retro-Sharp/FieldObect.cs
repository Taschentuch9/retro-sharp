using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Retro_Sharp
{
    class FieldObect
    {
        public bool CanStand;
        public bool GivesLife;
        public bool GivesSlowmotion;
        public int Vector;
        public char Icon;

        public FieldObect(bool CanStand, bool GivesLife,bool GivesSlowmotion, int Vector,char Icon)
        {
            this.CanStand = CanStand;
            this.GivesLife = GivesLife;
            this.Vector = Vector;
            this.GivesSlowmotion = GivesSlowmotion;
            this.Icon = Icon;
        }


        public void UpdatePlayerProperties()
        {
            if(this.GivesLife)
                ObjectCollection.Player.Lifes++;
            if (this.GivesSlowmotion)
                ObjectCollection.Player.Slowmotions++;
            if (!this.CanStand)
            {
                ObjectCollection.Player.Lifes--;
                if (ObjectCollection.Player.Lifes == 0)
                {
                    ObjectCollection.Player.dead = true;
                }
            }
            ObjectCollection.Player.PositionX -= this.Vector;
        }

    }
}
