using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace list11
{
    class Program
    {
        static int[] dx = { 1, 2, 2, 1, -1, -2, -2, -1 };
        static int[] dy = { 2, 1, -1, -2, -2, -1, 1, 2 };

        static int sizeX, sizeY;

        static void start()
        {
            Console.Write("Set chessboard size X: ");
            sizeX = Convert.ToInt32(Console.ReadLine());

            Console.Write("Set chessboard size Y: ");
            sizeY = Convert.ToInt32(Console.ReadLine());

            int[,] chessboard = new int[sizeY, sizeX];

            fill(chessboard);

            Console.Write($"Set start X 0-{sizeX - 1}: ");
            int startX = Convert.ToInt32(Console.ReadLine());

            Console.Write($"Set start Y 0-{sizeY - 1}: ");
            int startY = Convert.ToInt32(Console.ReadLine());

            Console.Write($"Set end X 0-{sizeX - 1}: ");
            int koniecX = Convert.ToInt32(Console.ReadLine());

            Console.Write($"Set end Y 0-{sizeY - 1}: ");
            int koniecY = Convert.ToInt32(Console.ReadLine());

            chessboard[startY, startX] = 1;

            findSolution(chessboard, startX, startY, koniecX, koniecY);
        }

        static void fill(int[,] chessboard)
        {
            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    chessboard[i, j] = -1;
                }
            }
        }

        static bool algorithm(int x, int y, int nr, int[,] chessboard, int koniecX, int koniecY)
        {
            int x1 = -1, y1 = -1;

            if (chessboard[koniecY, koniecX] == sizeX * sizeY)
            {
                return true;
            }

            for (int k = 0; k < 8; k++)
            {
                x1 = x + dx[k];
                y1 = y + dy[k];

                if (x1 >= 0 && x1 < sizeX && y1 >= 0 && y1 < sizeY && chessboard[y1, x1] == -1)
                {
                    chessboard[y1, x1] = nr + 1;
                    if (algorithm(x1, y1, nr + 1, chessboard, koniecX, koniecY))
                    {
                        return true;
                    }
                    else
                    {
                        chessboard[y1, x1] = -1; //Backtracking
                    }
                }
            }

            return false;
        }

        static void findSolution(int[,] chessboard, int startX, int startY, int koniecX, int koniecY)
        {
            if (!algorithm(startX, startY, 1, chessboard, koniecX, koniecY))
            {
                Console.WriteLine("\nNo way!");
            }
            else
            {
                print(chessboard);
            }
        }
        static void print(int[,] chessboard)
        {
            Console.WriteLine("\n--------------------------\n");
            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {

                    Console.Write($"{chessboard[i, j],-5}");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("--------------------------");
        }

        static void Main(string[] args)
        {
            start();

            Console.WriteLine("\nPress any key to end the program.");
            Console.ReadKey();
        }
    }
}
