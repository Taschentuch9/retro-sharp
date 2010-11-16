using System;
using System.Threading;
using System.Timers;

namespace CSharp_Moving
{
    class Program
    {
        static Menu men = new Menu();
        private static System.Timers.Timer aTimer;
        static Display Jetzt = new Display();
        static int score = 0;
        static int speed = 200;
        static bool aendern = false;
        static bool started = false;
        static bool exit = false;
        static void Main()
        {
            while (exit == false)
            {
                Console.Title = "C#-Moving";
                Console.SetWindowSize(40, 8);
                switch (men.Start())
                {
                    case 1:
                        Console.Clear();
                        started = true;
                        break;
                }
                if (started == true)
                {
                    int PlayerPostion = 4;
                    Jetzt.Pole(PlayerPostion);
                    aTimer = new System.Timers.Timer(200);
                    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                    aTimer.Interval = speed;
                    aTimer.Enabled = true;
                    while (Jetzt.Died() == false)
                    {
                        ConsoleKey input = Console.ReadKey(true).Key;
                        switch (input)
                        {
                            case ConsoleKey.UpArrow:
                                if (PlayerPostion != 1)
                                {
                                    PlayerPostion -= 1;
                                }
                                Jetzt.Pole(PlayerPostion);
                                break;
                            case ConsoleKey.DownArrow:
                                if (PlayerPostion != 7)
                                {
                                    PlayerPostion += 1;
                                }
                                Jetzt.Pole(PlayerPostion);
                                break;
                        }
                    }
                }
            }
        }
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Jetzt.Ausgabe();
            if (aendern == true)
            {
                aTimer.Interval = speed;
                aendern = false;
            }
            score += 10;
            if (Jetzt.Died() == true)
            {
                Jetzt.Ausgabe();
                Console.ReadKey();
                started = false;
                speed = 200;
                score = 0;
                aTimer.Stop();
                Jetzt.gameend();
            }
        }
        public static int Score()
        {
            return score;
        }
        public static void Speed(int geschw)
        {
            speed = geschw;
            aendern = true;
        }
        public static int GetSpeed()
        {
            return speed;
        }
    }
}

