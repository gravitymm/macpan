using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace macpan
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] mapp = { {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                             {'#', '*', '*', '*', '*', '*', '*', '*', '*', '#', '*', '*', '*', '*', '*', '*', '*', '*', '#'},
                             {'#', '*', '#', '#', '*', '#', '#', '#', '*', '#', '*', '#', '#', '#', '*', '#', '#', '*', '#'},
                             {'#', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '#'},
                             {'#', '*', '#', '#', '*', '#', '*', '#', '#', '#', '#', '#', '*', '#', '*', '#', '#', '*', '#'},
                             {'#', '*', '*', '*', '*', '#', '*', '*', '*', '#', '*', '*', '*', '#', '*', '*', '*', '*', '#'},
                             {'#', '#', '#', '#', '*', '#', '#', '#', ' ', '#', ' ', '#', '#', '#', '*', '#', '#', '#', '#'},
                             {'#', '#', '#', '#', '*', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', '*', '#', '#', '#', '#'},
                             {'#', '#', '#', '#', '*', '#', ' ', '#', '#', '-', '#', '#', ' ', '#', '*', '#', '#', '#', '#'},
                             {' ', ' ', ' ', ' ', '*', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', '*', ' ', ' ', ' ', ' '},
                             {'#', '#', '#', '#', '*', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', '*', '#', '#', '#', '#'},
                             {'#', '#', '#', '#', '*', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', '*', '#', '#', '#', '#'},
                             {'#', '#', '#', '#', '*', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', '*', '#', '#', '#', '#'},
                             {'#', '*', '*', '*', '*', '*', '*', '*', '*', '#', '*', '*', '*', '*', '*', '*', '*', '*', '#'},
                             {'#', '*', '#', '#', '*', '#', '#', '#', '*', '#', '*', '#', '#', '#', '*', '#', '#', '*', '#'},
                             {'#', '*', '*', '#', '*', '*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*', '*', '#', '*', '*', '#'},
                             {'#', '#', '*', '#', '*', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', '*', '#', '*', '#', '#'},
                             {'#', '*', '*', '*', '*', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#', '*', '*', '*', '*', '#'},
                             {'#', '*', '#', '#', '#', '#', '#', '#', ' ', '#', ' ', '#', '#', '#', '#', '#', '#', '*', '#'},
                             {'#', '*', '*', '*', '*', '*', '*', '*', ' ', ' ', ' ', '*', '*', '*', '*', '*', '*', '*', '#'},
                             {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'} };
            ConsoleKeyInfo key;
            char[,] map = new char[21, 19];
            int score;
            pacman macpan = new pacman();
            while (true)
            {
                int rows1 = mapp.GetUpperBound(0) + 1;
                int columns1 = mapp.Length / rows1;

                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < rows1; i++)
                {
                    for (int j = 0; j < columns1; j++)
                    {
                        map[i, j] = mapp[i, j];
                    }
                }
                score = 0;
                macpan.start();
                while (true)
                {
                    int rows = map.GetUpperBound(0) + 1;
                    int columns = map.Length / rows;

                    Console.SetCursorPosition(0, 0);
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            if (macpan.Get_x() == j & macpan.Get_y() == i)
                            {
                                macpan.Print_pacman();
                            }
                            else
                            {
                                Console.Write(map[i, j]);
                            }
                        }
                        Console.WriteLine();
                    }
                    if (map[macpan.Get_y(), macpan.Get_x()] == '*')
                    {
                        score++;
                        map[macpan.Get_y(), macpan.Get_x()] = ' ';
                    }
                    Console.WriteLine("Score: " + score);
                    if (score == 131)
                    {
                        break;
                    }
                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.W)
                    {
                        if (map[macpan.Get_y() - 1, macpan.Get_x()] != '#')
                        {
                            macpan.Change_y(-1);
                        }
                    }
                    else if (key.Key == ConsoleKey.S)
                    {
                        if (map[macpan.Get_y() + 1, macpan.Get_x()] != '#')
                        {
                            macpan.Change_y(1);
                        }
                    }
                    else if (key.Key == ConsoleKey.A)
                    {
                        if (map[macpan.Get_y(), macpan.Get_x() - 1] != '#')
                        {
                            if (macpan.Get_x() - 1 != 0)
                            {
                                macpan.Change_x(-1);
                            }
                            else
                            {
                                macpan.Change_x(16);
                            }
                        }
                    }
                    else if (key.Key == ConsoleKey.D)
                    {
                        if (map[macpan.Get_y(), macpan.Get_x() + 1] != '#')
                        {
                            if (macpan.Get_x() + 1 != 18)
                            {
                                macpan.Change_x(1);
                            }
                            else
                            {
                                macpan.Change_x(-16);
                            }
                        }
                    }
                }
                Console.Clear();
                Console.WriteLine("you победил но БАН");
                Console.ReadLine();
            }
        }
    }

    class pacman
    {
        private int x = 0;
        private int y = 0;
        private char p = '@';

        public void start()
        {
            x = 9;
            y = 11;
        }
        public int Get_x()
        {
            return x;
        }

        public int Get_y()
        {
            return y;
        }

        public void Print_pacman()
        {
            Console.Write(p);
        }

        public void Change_x(int c)
        {
            x += c;
        }

        public void Change_y(int c)
        {
            y += c;
        }
    }
}
