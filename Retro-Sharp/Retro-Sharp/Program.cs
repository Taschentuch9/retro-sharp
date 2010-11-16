using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Retro_Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.MainMenu();
        }

        public static void L(int i)
        {
            for (; i >= 0; i--)
                Console.WriteLine();
        }
        public static void S(int i)
        {
            for (; i >= 0; i--)
                Console.Write(' ');
        }

        public static bool WantToExit()
        {

            int chose = 1;
            int MenuPoints = 2;
            Console.Clear();
            while (true)
            {
                Program.L(Console.WindowHeight / 2);
                Program.S(Console.WindowWidth / 2 + 1);
                Console.WriteLine(((chose == 1) ? "o " : "") + "Yes");
                Program.S(Console.WindowWidth / 2 + 1);
                Console.WriteLine(((chose == 2) ? "o " : "") + "No");
                ConsoleKeyInfo Key = Console.ReadKey();
                Console.Clear();
                switch (Key.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (chose == 1)
                            chose = MenuPoints;
                        else
                            chose--;
                        break;
                    case ConsoleKey.UpArrow:
                        chose = chose % MenuPoints + 1;
                        break;
                    case ConsoleKey.Escape:
                        return false;
                    case ConsoleKey.Enter:
                        return (chose == 1);
                }
            }

        }

        private static void MainMenu()
             {
                bool exit=false;
                int chose=1;
                const int MenuPoints=3;
                while(!exit)
                {
                    Console.Clear();
                    Program.L(Console.WindowHeight / 2 - 4);
                    Program.S(Console.WindowWidth / 2 - 4);
                    Console.WriteLine(((chose == 1) ? "o " : "") + "GameList");
                    Program.S(Console.WindowWidth / 2 - 4);
                    Console.WriteLine(((chose == 2) ? "o " : "") + "Highscores");
                    Program.S(Console.WindowWidth / 2 - 4);
                    Console.WriteLine(((chose == 3) ? "o " : "") + "Exit");
                    ConsoleKeyInfo KeyIn = Console.ReadKey();
                    switch (KeyIn.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if(chose==1)
                                chose=MenuPoints;
                            else
                                chose--;
                            break;
                        case ConsoleKey.DownArrow:
                            chose=chose%MenuPoints+1;
                            break;
                        case ConsoleKey.Escape:
                            if (Program.WantToExit())
                                Environment.Exit(0);
                            break;
                        case ConsoleKey.Enter:
                            switch (chose)
                            {
                                case 1:
                                    Program.GameList();
                                    break;
                                case 2:
                                    Program.Highscores();
                                    break;
                                case 3:
                                    Program.WantToExit();
                                    Environment.Exit(0);
                                    break;
                            }
                            break;
                    }
                }
        }
        private static void GameList()
        {
            Console.Clear();
            const int MenuPoints=2;
            int chose=1;
            while (true)
            {
                Console.Clear();
                Program.L(Console.WindowHeight / 2 - 4);
                Program.S(Console.WindowWidth / 2 - 4);
                Console.WriteLine(((chose == 1) ? "o " : "") + "Frogger#");
                Program.S(Console.WindowWidth / 2 - 4);
                Console.WriteLine(((chose == 2) ? "o " : "") + "Move#");
                ConsoleKeyInfo Key = Console.ReadKey();
                switch (Key.Key)
                {
                    case ConsoleKey.DownArrow:
                        chose = chose % MenuPoints + 1;
                        break;
                    case ConsoleKey.UpArrow:
                        if (chose == 1)
                            chose = MenuPoints;
                        else
                            chose--;
                        break;
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.Enter:
                        switch (chose)
                        {
                            case 1:
                                FroggerMain.Froggy();
                                break;
                            case 2:
                                break;
                        }
                        break;
                }
                
            }
        }   

        private static void Highscores()
        {
            ;
        }
    }
}
