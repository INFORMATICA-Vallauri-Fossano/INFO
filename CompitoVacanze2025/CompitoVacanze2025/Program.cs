using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using CompitoVacanze2025.Views;
namespace CompitoVacanze2025
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new Prestiti());

            }
            catch (Exception)
            {
                MessageBox.Show("An error occured, restarting the program");
                Application.Run(new Prestiti());
            }
        }
    }
}
