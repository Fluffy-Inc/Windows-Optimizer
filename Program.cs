using System;
using System.Windows.Forms;
using WindowsOptimizer.UI;

namespace WindowsOptimizer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
