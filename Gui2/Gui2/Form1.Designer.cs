namespace MinefieldGame
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelGameField;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelGameField = new Panel();
            SuspendLayout();
            // 
            // panelGameField
            // 
            panelGameField.Location = new Point(12, 12);
            panelGameField.Name = "panelGameField";
            panelGameField.Size = new Size(430, 400);
            panelGameField.TabIndex = 0;
            // 
            // Form1
            // 
            ClientSize = new Size(484, 461);
            Controls.Add(panelGameField);
            Name = "Form1";
            Text = "Minefield Game";
            ResumeLayout(false);
        }
    }
}
