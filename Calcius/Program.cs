using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calcius
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            CosturaUtility.Initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());


        }

        
            
        
    }
}
