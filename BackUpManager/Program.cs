using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackUpManager
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 
        
        /*
         * Программа должна:
         *  - включаться при запуске системы и висеть в трее
         *  - иметь список папок, которые необходимо резервно копировать
         *  - иметь интерфейс для управления копированием (при включении, по периоду, принудительно)
         *  - иметь интерфейс управления версиями копирования и восстановления файлов согласно выбранной версии
         * 
         */
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //TODO Возможно не будет иметь смысла присвоение переменной
            MainForm mainForm = new MainForm();
            Application.Run(mainForm);

        }

    }
}
