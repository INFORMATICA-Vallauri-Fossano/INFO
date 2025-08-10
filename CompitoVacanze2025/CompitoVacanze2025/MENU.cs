using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using CompitoVacanze2025.Views;

namespace CompitoVacanze2025
{
    public partial class MENU : Form
    {
        public MENU()
        {
            InitializeComponent();
        }

        private void btnManagerLettori_Click(object sender, EventArgs e)
        {
            LettoriManager lettoriManager = new LettoriManager();
            lettoriManager.ShowDialog();
        }

        private void btnManagerLibri_Click(object sender, EventArgs e)
        {
            LibriManager libriManager = new LibriManager();
            libriManager.ShowDialog();
        }
    }
}
