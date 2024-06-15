using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Gui2;

namespace MinefieldGame
{
    public partial class Form1 : Form
    {
        private Player player;
        private Minefield minefield;
        private const int width = 11;
        private const int height = 10;
        private const int cellSize = 40;
        private PictureBox[,] cells;

        public Form1()
        {
            InitializeComponent();
            cells = new PictureBox[width, height];
            InitializeGame();
            player = new Player(5, 8);
            minefield = new Minefield(11, 10);
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        private void InitializeGame()
        {
            player = new Player(5, 8);
            minefield = new Minefield(width, height);
            InitializeGameField();
            UpdateGameField();
        }

        private void InitializeGameField()
        {
            panelGameField.Controls.Clear();
            panelGameField.Width = width * cellSize;
            panelGameField.Height = height * cellSize;
            cells = new PictureBox[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    PictureBox cell = new PictureBox();
                    cell.Width = cellSize;
                    cell.Height = cellSize;
                    cell.Location = new Point(x * cellSize, y * cellSize);
                    cell.BorderStyle = BorderStyle.FixedSingle;
                    cell.SizeMode = PictureBoxSizeMode.StretchImage;
                    panelGameField.Controls.Add(cell);
                    cells[x, y] = cell;
                }
            }
        }

        private void UpdateGameField()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if ((x == 0 || y == height - 1 || x == width - 1 || (y == 0 && x != 5)))
                    {
                        cells[x, y].Image = Image.FromFile("C:\\Users\\grigo\\source\\repos\\Gui2\\Gui2\\korobka.png");
                    }
                    else if (minefield.IsMine(x, y))
                    {
                        cells[x, y].Image = Image.FromFile("C:\\Users\\grigo\\source\\repos\\Gui2\\Gui2\\empty.png");
                    }
                    else if (player.CheckCollision(x, y))
                    {
                        int nearbyMines = minefield.CountNearbyMines(x, y);
                        cells[x, y].Image = CreateImageWithText(nearbyMines.ToString());
                    }
                    else if (player.Trail.Contains((x, y)))
                    {
                        cells[x, y].Image = Image.FromFile("C:\\Users\\grigo\\source\\repos\\Gui2\\Gui2\\sled.png");
                    }
                    else
                    {
                        cells[x, y].Image = Image.FromFile("C:\\Users\\grigo\\source\\repos\\Gui2\\Gui2\\empty.png");
                    }
                }
            }
        }

        private Image CreateImageWithText(string text)
        {
            Bitmap bitmap = new Bitmap(cellSize, cellSize);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                using (Font font = new Font("Arial", 16))
                {
                    g.DrawString(text, font, Brushes.Black, new PointF(10, 10));
                }
            }
            return bitmap;
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            bool moved = false;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (player.Y > 1 || player.X == 5)
                    {
                        player.Move(player.X, player.Y - 1);
                        moved = true;
                    }
                    break;
                case Keys.Down:
                    if (player.Y < height - 2)
                    {
                        player.Move(player.X, player.Y + 1);
                        moved = true;
                    }
                    break;
                case Keys.Left:
                    if (player.X > 1)
                    {
                        player.Move(player.X - 1, player.Y);
                        moved = true;
                    }
                    break;
                case Keys.Right:
                    if (player.X < width - 2)
                    {
                        player.Move(player.X + 1, player.Y);
                        moved = true;
                    }
                    break;
            }

            if (moved)
            {
                CheckGameState();
                UpdateGameField();
            }
        }

        private void CheckGameState()
        {
            if (minefield.IsMine(player.X, player.Y))
            {
                MessageBox.Show("Програш, ви наступили на міну! Успіху в наступний раз ;)");
                InitializeGame();
            }
            else if (player.X == 5 && player.Y == 0)
            {
                MessageBox.Show("Перемога!");
                InitializeGame();
            }
        }
    }
}