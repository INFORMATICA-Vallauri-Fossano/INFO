using CompitoVacanze2025.Models;
using CompitoVacanze2025.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnrangoRamosLibrary;

namespace CompitoVacanze2025.Views
{
    public partial class Prestiti : Form
    {
        private BindingList<KeyValuePair<int, string>> lettori=new BindingList<KeyValuePair<int, string>>();
        private List<KeyValuePair<int, string>> lettoriWaiting=new List<KeyValuePair<int, string>>();


        public Prestiti()
        {
            InitializeComponent();
        }
        private Lettore lettore
        {
            get
            {
                if (cmbLettori.SelectedValue == null) return null;
                return LettoriController.Read((int)cmbLettori.SelectedValue);
            }
        }
        private Libro libro { get; set; }
        private void Presta_Click(object sender, EventArgs e)
        {
            try
            {
                if (lettore == null) throw new Exception("Scegliere un lettore");
                if(libro==null) throw new Exception("Scegliere un libro");
                if (PrestitiController.Create(new Prestito(lettore.IdLettore, libro.CodiceISBN, DateTime.Now, null)))
                    MessageBox.Show("Prestito effettuato con successo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void lettori_TextUpdate(object sender, EventArgs e)
        {
            string filter = cmbLettori.Text.ToLower();
            lettori.Clear();
            foreach (var letW in lettoriWaiting) if (letW.Value.ToLower().Contains(filter)) lettori.Add(letW);
            cmbLettori.Text = filter;
            cmbLettori.SelectionStart = filter.Length;
            cmbLettori.DroppedDown = true;
        }
        List<Libro> libri = LibriController.Read();
        List<Autore> autori=AutoriController.Read();
        List<Genere> generi=GeneriController.Read();
        private void search()
        {

        }
        private void Prestiti_Load(object sender, EventArgs e)
        {
            lettoriWaiting = LettoriController.Read().ToDictionary(x => x.IdLettore, x => x.IdLettore + " : " + x.Cognome + " " + x.Nome).ToList();
            cmbLettori.DataSource = lettori;
            cmbLettori.ValueMember = "Key";
            cmbLettori.DisplayMember = "Value";

            cmbGeneri.DataSource = GeneriController.Read().ToDictionary(g=>g.IdGenere,g=>g.Genre).ToList();
            cmbGeneri.ValueMember = "Key";
            cmbGeneri.DisplayMember = "Value";

            cmbAutori.DataSource = AutoriController.Read().ToDictionary(a=>a.Id,a=>a.Nome+" "+a.Cognome).ToList();
            cmbAutori.ValueMember = "Key";
            cmbAutori.DisplayMember = "Value";

            lettori_TextUpdate(null,null);
            cmbLettori.DroppedDown=false;
        }

    }
}
