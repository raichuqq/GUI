using MinefieldGame;
using System;
using System.Windows.Forms;

namespace Gui2
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MenuForm()); // Запуск меню вместо формы игры
        }
    }
}
