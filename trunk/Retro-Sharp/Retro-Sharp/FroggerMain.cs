using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Retro_Sharp
{
    class FroggerMain
    {
        static int UpdaterInterval = 1000;
        public static void Froggy()
        {
            Console.SetWindowSize(80,28);
            FroggerMain.FieldGenerator();
            Console.SetWindowSize(80, 26);
            ObjectCollection.Updater.Enabled = true;
            ObjectCollection.Updater.Interval = FroggerMain.UpdaterInterval;
            ObjectCollection.Updater.Elapsed += new ElapsedEventHandler(Update);
            int PrePosition=ObjectCollection.Player.PositionY;
            bool whichPosition = false;           //false= Y, true=X
            while (true)
            {
                Console.Clear();
                if (ObjectCollection.Player.dead)
                    FroggerMain.GameOver();
                ObjectCollection.Field[ObjectCollection.Player.PositionX, ObjectCollection.Player.PositionY].UpdatePlayerProperties();
                FroggerMain.Write();
                ConsoleKeyInfo input = Console.ReadKey();
                try
                {
                    switch (input.Key)
                    {
                        case ConsoleKey.DownArrow:
                            PrePosition = ObjectCollection.Player.PositionY;
                            whichPosition = false;
                            ObjectCollection.Player.PositionY++;
                            break;
                        case ConsoleKey.UpArrow:
                            PrePosition = ObjectCollection.Player.PositionY;
                            whichPosition = false;
                            ObjectCollection.Player.PositionY--;
                            break;
                        case ConsoleKey.RightArrow:
                            PrePosition = ObjectCollection.Player.PositionX;
                            whichPosition = true;
                            ObjectCollection.Player.PositionX++;
                            break;
                        case ConsoleKey.LeftArrow:
                            PrePosition = ObjectCollection.Player.PositionX;
                            whichPosition = true;
                            ObjectCollection.Player.PositionX--;
                            break;
                        case ConsoleKey.Escape:
                            FroggerMain.Break();
                            break;
                        case ConsoleKey.S:
                            if (ObjectCollection.Player.Slowmotions > 0)
                            {
                                ObjectCollection.Player.Slowmotions--;
                                ObjectCollection.SlowTimer.Enabled = true;
                                ObjectCollection.Updater.Interval *= 2;
                                ObjectCollection.SlowTimer.Interval = 15000;
                                ObjectCollection.SlowTimer.Elapsed += new ElapsedEventHandler(SlowTimer_Elapsed);
                            }
                            break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    if (whichPosition)
                        ObjectCollection.Player.PositionX = PrePosition;
                    else
                        ObjectCollection.Player.PositionY = PrePosition;
                }
            }
        }

        public static void Update(object sender, ElapsedEventArgs e)
        {
            FroggerMain.FieldUpdater();
            ObjectCollection.Field[ObjectCollection.Player.PositionX, ObjectCollection.Player.PositionY].UpdatePlayerProperties();
            Console.Clear();
            FroggerMain.Write();
        }

        public static void SlowTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
           ObjectCollection.SlowTimer.Close();
           FroggerMain.UpdaterInterval/=2;
        }

        public static void GameOver()
        {
            ObjectCollection.Updater.Enabled = false;
            Console.Clear();
            Program.L(Console.WindowHeight/2);
            Program.S((Console.WindowWidth-5)/2);
            Console.WriteLine("Game Over");
            Console.Read();
            Environment.Exit(0);
        }

        public static void Break()
        {
            Console.Clear();
            Program.L(Console.WindowHeight/2);
            Program.S((Console.WindowWidth-5)/2);
            ObjectCollection.Updater.Enabled = false;
            Console.WriteLine("PAUSE");
            Console.Read();
            ObjectCollection.Updater.Enabled = true;
        }

        public static void FieldUpdater()
        {
            FieldObect[,] New1 = new FieldObect[80,26];
            Random r = new Random();
            int exceptions = 0;
            int whichnew;
            for (int i = 0; i < New1.GetLength(0); i++)
            {
                for (int j = 0; j < New1.GetLength(1); j++)
                {
                    New1[i, j] = null;
                }
            }
                for (int i = 0; i < New1.GetLength(0); i++)
                {
                    for (int j = 0; j < New1.GetLength(1); j++)
                    {
                        try
                        {
                            //Console.WriteLine("" + i + "," + j + "");
                            New1[i, j] = ObjectCollection.Field[i + ObjectCollection.Field[i, j].Vector, j];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            exceptions++;
                        }
                    }
                }
            New1.GetLength(0);
            New1.GetLength(1);
            for (int i = 0; i < New1.GetLength(0); i++)
            {
                for (int j = 0; j < New1.GetLength(1); j++)
                {
                    if (New1[i, j] == null)
                    {
                        whichnew = r.Next(1, 4);
                        if (whichnew == 2 && i % 2 == 0)
                            New1[i, j] = ObjectCollection.StreetLeft;
                        else if (whichnew == 2 && i % 2 == 1)
                            New1[i, j] = ObjectCollection.StreetRight;
                        else
                        {
                            if (i % 2 == 0)
                                New1[i, j] = ObjectCollection.UnSafeLeft;
                            else
                                New1[i, j] = ObjectCollection.UnSafeRight;
                        }
                    }

                }
            }

            for (int i = 0; i < New1.GetLength(0); i++)
            {
                for (int j = 0; j < New1.GetLength(1); j++)
                {
                    ObjectCollection.Field[i, j] = New1[i, j];
                }
            }
        }

        public static void Write()
        {
            for (int i = 0; i < ObjectCollection.Field.GetLength(1); i++)
			{
                for (int j = 0; j < ObjectCollection.Field.GetLength(0); j++)
                {
                    if(j==ObjectCollection.Player.PositionX&&i==ObjectCollection.Player.PositionY)
                    {
                        Console.Write(ObjectCollection.Player.PlayerIcon);
                    }
                    else
                    Console.Write(ObjectCollection.Field[j, i].Icon);
                }
            }
        }
        public static void FieldGenerator()
        {
            for (int i = 0; i < ObjectCollection.Field.GetLength(1); i++)
            {
                for (int j = 0; j < ObjectCollection.Field.GetLength(0); j++)
                {
                    if (i == 0 || i == 1 || i == ObjectCollection.Field.GetLength(1) - 1 || i == ObjectCollection.Field.GetLength(1) - 2)
                        ObjectCollection.Field[j, i] = ObjectCollection.Save;
                    else if (i == 2 || i == ObjectCollection.Field.GetLength(1) - 3)
                        ObjectCollection.Field[j, i] = ObjectCollection.Border;
                    else if (i > 2 && i < ObjectCollection.Field.GetLength(1) - 3 && i % 2 == 0)
                        ObjectCollection.Field[j, i] = ObjectCollection.UnSafeLeft;
                    else if (i > 2 && i < ObjectCollection.Field.GetLength(1) - 3 && i % 2 == 1)
                        ObjectCollection.Field[j, i] = ObjectCollection.UnSafeRight;
                    else
                        ObjectCollection.Field[j,i]= new FieldObect(false, false, false, 0, '?');
                }
                //ObjectCollection.Field[ObjectCollection.Field.GetLength(0)/2,ObjectCollection.Field.GetLength(1)/2] = new FieldObect(true, true, true, 0, '#');
            }
        }
    }
}

