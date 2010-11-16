using System;
using System.Collections.Generic;

namespace CSharp_Moving
{
    public class Menu
    {
        private ConsoleKeyInfo key;
        private int DeltaHeight = (Console.WindowHeight - 6) / 2;
        private int DeltaWidth = (Console.WindowWidth - 50) / 2;
        private int choose = 1;
        public Menu()
        {
        }
        public int Start()
        {
            choose = 1;
            while (true)
            {
                Console.Clear();
                empty(DeltaHeight);
                Console.WriteLine(Makestring(" C# Moving"));
                empty(1);
                Console.WriteLine(Makestring(((choose == 1) ? "o " : " ")) + "Neues Spiel");
                Console.WriteLine(Makestring(((choose == 2) ? "o " : " ")) + "Highscores");
                Console.WriteLine(Makestring(((choose == 3) ? "o " : " ")) + "Credits");
                Console.WriteLine(Makestring(((choose == 4) ? "o " : " ")) + "Beenden");
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    switch (choose)
                    {
                        case 1:
                            return 1;
                        case 2:
                            {
                                Console.Clear();
                                Console.WriteLine("Wird noch implementiert!");
                                Console.ReadKey();
                                break;
                            }
                        case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("Wird noch implementiert!");
                            Console.ReadKey();
                            break;
                        }
                        case 4:
                            Console.Clear();
                            Environment.Exit(0);
                            break;
                    }
                }
                else
                {
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        if (choose - 1 == 0) choose = 4; else choose--;
                    }
                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        if (choose + 1 == 5) choose = 1; else choose++;
                    }
                }
            }
        }
        private void empty(int l)
        {
            for (; l != 0; l--) Console.WriteLine();
            return;
        }
        private string Makestring(string output)
        {
            string end = "";
            for (int i = 0; i < DeltaWidth; i++)
            {
                end += " ";
            }
            return end + output;
        }
    }
}
