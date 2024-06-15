using System;
using System.Collections.Generic;

namespace Gui2
{
    public class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public List<(int, int)> Trail { get; private set; }

        public Player(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            Trail = new List<(int, int)>();
            Trail.Add((X, Y));
        }

        public void Move(int newX, int newY)
        {
            X = newX;
            Y = newY;
            Trail.Add((X, Y));
        }

        public bool CheckCollision(int x, int y)
        {
            return X == x && Y == y;
        }
    }

    public class Minefield
    {
        private List<(int, int)> mines;
        private int width;
        private int height;

        public Minefield(int width, int height)
        {
            this.width = width;
            this.height = height;
            mines = new List<(int, int)>();
            GenerateRandomMines();
        }

        private void GenerateRandomMines()
        {
            Random random = new Random();
            int count = 0;
            while (count < 10)
            {
                int x = random.Next(1, width - 1);
                int y = random.Next(1, height - 1);
                if (!mines.Contains((x, y)) && !(x == 5 && y == 0))
                {
                    mines.Add((x, y));
                    count++;
                }
            }
        }

        public bool IsMine(int x, int y)
        {
            return mines.Contains((x, y));
        }

        public int CountNearbyMines(int x, int y)
        {
            int count = 0;
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (mines.Contains((i, j)))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
