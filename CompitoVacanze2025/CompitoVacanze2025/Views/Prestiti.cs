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

namespace CompitoVacanze2025.Views
{
    public partial class Prestiti : Form
    {
        public Prestiti()
        {
            InitializeComponent();
            lettori.DataSource = LettoriController.Read().ToDictionary(x => x.IdLettore, x => x.IdLettore+" "+x.Nome + " " + x.Cognome).ToList();
            lettori.ValueMember = "Key";
            lettori.DisplayMember = "Value";

            generi.DataSource = GeneriController.Read().ToList();
            generi.ValueMember = "Key";
            generi.DisplayMember = "Value";

            autori.DataSource = AutoriController.Read().ToList();
            autori.ValueMember= "Key";
            autori.DisplayMember = "Value";

            //generi.Items.Insert(0, new KeyValuePair<int, string>(-1, "Tutti i generi"));
            //autori.Items.Insert(0, new KeyValuePair<int, string>(-1, "Tutti gli autori"));
        }
        private Lettore lettore
        {
            get
            {
                if (lettori.SelectedValue == null) return null;
                return LettoriController.Read((int)lettori.SelectedValue);
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

        private void search()
        {
            var libri = LibriController.Read();
            try
            {
                if(libri.Count == 0) throw new Exception("Nessun libro presente nel database");
                if(generi.SelectedValue!=null) libri.Select(x => x._IdGenere == (int)generi.SelectedValue);
                if (autori.SelectedValue != null) ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
