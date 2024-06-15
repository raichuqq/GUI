using System;
using System.Drawing;
using System.Windows.Forms;

namespace MinefieldGame
{
    public partial class MenuForm : Form
    {
        private PictureBox? pictureBox; // Объявляем поля как nullable
        private Button? btnPlay;        // Объявляем поля как nullable
        private Button? btnExit;        // Объявляем поля как nullable

        public MenuForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.pictureBox = new PictureBox();
            this.btnPlay = new Button();
            this.btnExit = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Image = Image.FromFile("C:\\Users\\grigo\\source\\repos\\Gui2\\Gui2\\menu2.png");
            this.pictureBox.Location = new Point(20, -40);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new Size(450, 450);
            this.pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new Point(100, 320);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new Size(100, 50);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "Грати";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new EventHandler(this.BtnPlay_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new Point(260, 320);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(100, 50);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Вийти з гри";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.BtnExit_Click);
            // 
            // MenuForm
            // 
            this.ClientSize = new Size(484, 411);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.pictureBox);
            this.Name = "MenuForm";
            this.Text = "Minefield Game Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
        }

        private void BtnPlay_Click(object? sender, EventArgs e) 
        {
            Form1 gameForm = new Form1();
            gameForm.Show();
            this.Hide();
        }

        private void BtnExit_Click(object? sender, EventArgs e) 
        {
            Application.Exit();
        }
    }
}
