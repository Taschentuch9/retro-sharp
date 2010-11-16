using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Retro_Sharp
{
    class ObjectCollection
    {
        public static FieldObect StreetLeft = new FieldObect(true,false, false, -1,'=');
        public static FieldObect StreetRight = new FieldObect(true, false, false,-1, '=');
        public static FieldObect LifeLeft = new FieldObect(true, true, false, -1,'L');
        public static FieldObect LifeRight = new FieldObect(true, true, false, 1,'L');
        public static FieldObect Save = new FieldObect(true, false, false, 0,' ');
        public static FieldObect UnSafeLeft = new FieldObect(false, false, false, -1, ' ');
        public static FieldObect UnSafeRight = new FieldObect(false, false, false, 1, ' ');
        public static FieldObect Border = new FieldObect(true, false, false, 0, '-');
        public static FieldObect SlowLeft = new FieldObect(true, false, true, -1,'S');
        public static FieldObect SlowRight = new FieldObect(true, false, true, 0,'S');
        public static Timer Updater = new Timer();
        public static Timer SlowTimer = new Timer();
        public static FieldObect[,] Field = new FieldObect[80,26];
        public static PlayerStats Player = new PlayerStats();
    }
}
