using System;
using System.Windows.Forms;

//using System.Linq;
//using System.Threading.Tasks;
//using System.Collections.Generic;

namespace LexiCom
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LexiCom());
        }
    }
}
