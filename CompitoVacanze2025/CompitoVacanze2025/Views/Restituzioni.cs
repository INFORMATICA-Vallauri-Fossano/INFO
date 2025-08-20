using CompitoVacanze2025.Controls;
using CompitoVacanze2025.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompitoVacanze2025.Views
{
    public partial class Restituzioni : Form
    {
        private int IdLettore { get; set; }
        public Restituzioni(int idLettore)
        {
            InitializeComponent();
            IdLettore = idLettore;
        }
        BindingList<KeyValuePair<int,string>> lettori = new BindingList<KeyValuePair<int, string>>();
        List<KeyValuePair<int, string>> lettoriWaiting = LettoriController.Read().ToDictionary(l=>l.IdLettore,l=>l.IdLettore+": "+l.Cognome+" "+l.Nome).ToList();
        public Restituzioni()
        {
            InitializeComponent();
        }

        private void cmbLettori_TextUpdate(object sender, EventArgs e)
        {
            string filter = cmbLettori.Text.ToLower();
            lettori.Clear();
            foreach (var letW in lettoriWaiting) if (letW.Value.ToLower().Contains(filter)) lettori.Add(letW);
            cmbLettori.Text = filter;
            cmbLettori.SelectionStart = filter.Length;
            cmbLettori.DroppedDown = true;
    }

        private void Restituzioni_Load(object sender, EventArgs e)
        {
            cmbLettori.DataSource = lettori;
            cmbLettori.DisplayMember = "Value";
            cmbLettori.ValueMember = "Key";

            cmbLettori_TextUpdate(null, null);
            if(IdLettore > 0)
            {
                cmbLettori.SelectedValue = IdLettore;
            }
            else
            {
                cmbLettori.SelectedIndex = -1;
            }
        }

        private void btnRestituisci_Click(object sender, EventArgs e)
        {

        }
    }
}
