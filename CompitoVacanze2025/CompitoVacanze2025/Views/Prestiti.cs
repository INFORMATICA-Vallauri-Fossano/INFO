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
using System.Management.Instrumentation;

namespace CompitoVacanze2025.Views
{
    public partial class Prestiti : Form
    {
        private BindingList<KeyValuePair<int, string>> lettori=new BindingList<KeyValuePair<int, string>>();
        private List<KeyValuePair<int, string>> lettoriWaiting=new List<KeyValuePair<int, string>>();

        private string ISBN = "";
        private int IdLettore { get => (int)cmbLettori.SelectedValue; }
        private int IdGenere { get => (int)cmbGeneri.SelectedValue; }
        private int IdAutore { get=>(int)cmbAutori.SelectedValue;}
        private bool VuoleRestituire { get; set; } = false;

        private Prestito prestito = new Prestito(-1,-1,"0000000000000",DateTime.Now,null);
        //collections
        List<Autore> autori = AutoriController.Read();
        List<Scrivono> scritti = ScrivonoController.Read();
        List<Prestito> prestiti= PrestitiController.Read();
        List<Libro> libri= LibriController.Read();
        BindingList<row> libriFiltrati= new BindingList<row>();
        class row
        {
            public string PK{ get; set; }
            public string Titolo{get;set;}
            public string Autori{get;set;}
            public string Genere{get;set;}
            public string Lingua{get;set;}
            public string Collocazione{get;set;}
            public string Copertina { get; set;}
        }
        private void cmbLettori_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbLettori.SelectedValue != null)
            {
                try
                {
                    List<Prestito> prestitiLettore = prestiti.Where(p => p.IdLettore == IdLettore && p.DataFine == (DateTime?)null).ToList();
                    if (prestitiLettore.Count > 2)
                    {
                        if (MessageBox.Show("Hai già tre libri in prestito, vuoi andare a restituirne uno? ", "Conferma restituire", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                        {
                            Close();
                        }
                        libriFiltrati.Clear();
                        cmbLettori.SelectedIndex = -1;
                    }
                    else
                    {
                        prestito.IdLettore = IdLettore;
                        filtraLibri();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void filtraLibri()
        {
            IEnumerable<Libro> filteredGenere=libri;
            if (IdGenere != -1) filteredGenere = libri.Where(l => l._IdGenere == IdGenere);
            var filtered=filteredGenere.Where(l=>l.Disponibile==true).Select(l => new row
            {
                PK = l.CodiceISBN,
                Titolo = l.Titolo,
                Autori = string.Join(" - ", scritti.Where(s => s.CodiceISBN == l.CodiceISBN).Join(autori, s => s.IdAutore, a => a.Id, (s, a) => a.Cognome).ToList()),
                Genere = cmbGeneri.Text,
                Lingua = l.Lingua,
                Collocazione = l.Collocazione,
                Copertina = l.Copertina
            })
                .ToList();
            libriFiltrati.Clear();
            if (IdAutore != -1)
                foreach (var l in filtered)
                {
                    bool thereis = false;
                    string[] pronouns = cmbAutori.Text.Split(' ');
                    foreach (var pronoun in pronouns)
                        if (l.Autori.Contains(pronoun)) thereis = true;
                    if (thereis) libriFiltrati.Add(l);
                }
            else foreach (var l in filtered) libriFiltrati.Add(l);
        }

        public Prestiti()
        {
            InitializeComponent();
        }
        private void Presta_Click(object sender, EventArgs e)
        {
            try
            {
                if(prestito==null) throw new Exception("Scegliere un libro e un lettore ");
                if (MessageBox.Show("Vuoi davvero effettuare il prestito di: " + prestito.ToString(), "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (PrestitiController.Create(prestito))
                    {
                        MessageBox.Show("Prestito effettuato con successo");
                        prestiti = PrestitiController.Read();
                        libri = LibriController.Read();
                        libriFiltrati.Clear();
                        prestito = null;
                    }
                    else throw new Exception("Il prestito non è stato effettuato riprovare");
                }
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

        private void Prestiti_Load(object sender, EventArgs e)
        {
            lettoriWaiting = LettoriController.Read().ToDictionary(x => x.IdLettore, x => x.IdLettore + " : " + x.Cognome + " " + x.Nome).ToList();
            cmbLettori.DataSource = lettori;
            cmbLettori.ValueMember = "Key";
            cmbLettori.DisplayMember = "Value";

            cmbGeneri.DataSource = GeneriController.Read().ToDictionary(g => g.IdGenere, g => g.Genre).ToList()
                .Concat(new[]{new  KeyValuePair<int, string>(-1, "Tutti i generi")})
                .ToList();
            cmbGeneri.ValueMember = "Key";
            cmbGeneri.DisplayMember = "Value";
            cmbGeneri.SelectedValue = -1;

            cmbAutori.DataSource =
                AutoriController.Read()
                    .ToDictionary(a => a.Id, a => a.Nome + " " + a.Cognome)
                    .ToList()
                    .Concat(new[] { new KeyValuePair<int, string>(-1, "Tutti gli autori") })
                    .ToList();
            cmbAutori.ValueMember = "Key";
            cmbAutori.DisplayMember = "Value";
            cmbAutori.SelectedValue = -1;

            lettori_TextUpdate(null,null);
            cmbLettori.DroppedDown=false;

            dgvLibriPrestabili.DataSource = libriFiltrati;
            filtraLibri();
            //events
            cmbAutori.SelectedValueChanged += cmbAutori_SelectedValueChanged;
            cmbGeneri.SelectedValueChanged += cmbAutori_SelectedValueChanged;
        }

        private void cmbAutori_SelectedValueChanged(object sender, EventArgs e)
        {
         filtraLibri();
        }

        private void dgvLibriPrestabili_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.RowIndex!=-1&&e.RowIndex<dgvLibriPrestabili.Rows.Count-1)
                prestito.CodiceISBN = dgvLibriPrestabili.Rows[e.RowIndex].Cells["PK"].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Nessun libro nella tabella");
            }
        }

    }
}
