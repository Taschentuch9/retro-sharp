using System;

namespace CSharp_Moving
{
    class Display
    {
        Elements Elemente = new Elements();
        bool GameOver = false;
        public char Block = '|';
        char Player = '>';
        int Position=3;
        int speed = 200;
        int Anzahl = 0;
        int live = 3;
        char [,] Feld=newFeld();
        public static char[,] newFeld()
        {
            char[,] Feld=new char[8,40];
            for (int i = 0;i<8; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                   Feld[i, j] = ' ';
                }
                Feld[0, 5] = 'x';
            }
            return Feld;
        }
        public void Ausgabe()
        {
            char Bonus=Convert.ToChar(Elemente.Return());
            this.Anzahl++;
            if (Died() != true)
            {
                if (this.Anzahl % 3 == 0)
                {
                    this.Feld = GoOn(Feld);
                }
                else
                {
                    this.Feld = GoBlank(Feld);
                }
                Random rdm = new Random();
                int l = rdm.Next(1, 7);
                if (Bonus != ' ')
                {
                    Feld[l, 39] = Bonus;
                }
                if (this.Feld[Position, 0] == '|')
                {
                    live -= 1;
                }
                if (this.Feld[Position, 0] == '+')
                {
                    this.speed = Program.GetSpeed();
                    Program.Speed(this.speed-(this.speed/2));
                }
                if (this.Feld[Position, 0] == '-')
                {
                    this.speed = Program.GetSpeed();
                    Program.Speed(this.speed + (this.speed / 2));
                }
                if (this.Feld[Position, 0] == '#')
                {
                    live += 1;
                }
                if (live == 0)
                {
                    this.GameOver = true;
                }
                string Punkte = Convert.ToString(Program.Score());
                for (int i = 0; i < Punkte.Length; i++)
                {
                    this.Feld[0, i + 6] = Punkte[i];
                }
                Punkte = "Score:";
                for (int i = 0; i < Punkte.Length; i++)
                {
                    this.Feld[0, i] = Punkte[i];
                }
                string Leben = Convert.ToString(this.live);
                for (int i = 0; i < Leben.Length; i++)
                {
                    this.Feld[0, 39] = Leben[i];
                }
                Leben = "Lives:";
                for (int i = 0; i < Leben.Length; i++)
                {
                    this.Feld[0, i + 33] = Leben[i];
                }
                Pole(this.Position);
            }
            else
            {
                Console.Clear();
                int line = (Console.WindowHeight / 2) - 2;
                int blank = (Console.WindowWidth / 2) - 6;
                for (int m = 0; m < line; m++)
                {
                    Console.WriteLine();
                }
                for (int m = 0; m < blank; m++)
                {
                    Console.Write(" ");
                }
                Console.Write("GAME OVER\n\n");
                int score = Program.Score();
                for (int m = 0; m < blank; m++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("Score: " + score);
            }
        }
        public void Displ(char[,] Feld)
        {
            Console.WriteLine();
            string Ausgabe = "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    Ausgabe += Feld[i, j];
                }
                if (i != 7)
                    Ausgabe += "\n";
            }
            Console.Write(Ausgabe);
        }
        public void Pole(int Pos)
        {
            this.Feld[this.Position, 0] = ' ';
            this.Position = Pos;
            this.Feld[Pos, 0] = this.Player;
            Displ(this.Feld);
        }
        public char[,] GoOn(char[,] Feld)
        {
            Random rdm = new Random();
            char[,] NewFeld=new char[Feld.GetLength(0), Feld.GetLength(1)];
            for (int i = 0; i < 8; i++)
            {
                if (i != 0)
                {
                    for (int j = 1; j < 40; j++)
                    {
                        if (Feld[i, j] != this.Player)
                        {
                            NewFeld[i, j - 1] = Feld[i, j];
                        }
                        else
                        {
                            NewFeld[i, j] = Feld[i, j];
                        }
                    }
                    int R = rdm.Next(2, 5);
                    if (R == 2)
                    {
                        NewFeld[i, 39] = '|';
                    }
                    else
                    {
                        NewFeld[i, 39] = ' ';
                    }
                }
                else
                {
                    for (int j = 0; j < 40; j++)
                    {
                        NewFeld[i, j] = Feld[i, j];
                    }
                }
            }
            Feld=NewFeld;
            return Feld;
        }
        public char[,] GoBlank(char[,] Feld)
        {
            char[,] NewFeld = new char[Feld.GetLength(0), Feld.GetLength(1)];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 1; j < 40; j++)
                {
                    if (i != 0)
                    {
                        if (Feld[i, j] != this.Player)
                        {
                            NewFeld[i, j - 1] = Feld[i, j];
                        }
                        else
                        {
                            NewFeld[i, j] = Feld[i, j];
                        }
                    }
                    else
                    {
                        NewFeld[i, j] = Feld[i, j];
                    }
                }
                NewFeld[i, 39] = ' ';
            }
            Feld = NewFeld;
            return Feld;
        }
        public void gameend()
        {
            this.GameOver = false;
            this.live = 3;
        }
        public bool Died()
        {
            if (this.GameOver == true)
            {
                return true;
            }
            else
                return false;
        }
    }
}
