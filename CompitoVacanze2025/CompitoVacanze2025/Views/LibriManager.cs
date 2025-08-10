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
using CompitoVacanze2025.Controls;

namespace CompitoVacanze2025.Views
{
    public partial class LibriManager : Master
    {
        public LibriManager()
        {
            InitializeComponent();

            var generiList = GeneriController.Read().ToList();
            ucLibro.cmbGenere.DataSource = generiList;
            ucLibro.cmbGenere.ValueMember = "Key";
            ucLibro.cmbGenere.DisplayMember = "Value";

            DGV.DataSource = LibriController.Read();
            
            DGV.RowEnter += FillFormLibro;
        }

        private void FillFormLibro(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            Models.Libro libro = DGV.Rows[e.RowIndex].DataBoundItem as Models.Libro;
            if (libro == null) return;
            Libro = libro;
        }
        private Models.Libro Libro
        {
            get
            {
                try
                {
                    return new Models.Libro(
                        ucLibro.ISBN,
                        ucLibro.Titolo,
                        ucLibro.Pagine,
                        ucLibro.DataPubblicazione,
                        ucLibro.Collocazione,
                        ucLibro.Copertina,
                        ucLibro.CasaEditrice,
                        ucLibro.Disponibile,
                        ucLibro.Genere
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errore nella costruzione del libro: " + ex.Message);
                }
                return null;
            }
            set
            {
              ucLibro.ISBN = value.CodiceISBN;
                ucLibro.Titolo = value.Titolo;
                ucLibro.Pagine = value.NumeroPagine;
                ucLibro.DataPubblicazione = value.DataPubblicazione;
                ucLibro.Collocazione = value.Collocazione;
                ucLibro.Copertina = value.Copertina;
                ucLibro.CasaEditrice= value.CasaEditrice;
                ucLibro.Disponibile = value.Disponibile;
                ucLibro.Genere = value._IdGenere;
            }
        }

        private void btnInserimento_Click(object sender, EventArgs e)
        {
            if (Libro == null) return;
            if (LibriController.Create(Libro))
            {
                MessageBox.Show("Libro inserito con successo!");
                DGV.DataSource = LibriController.Read();
            }
            else
            {
                MessageBox.Show("Errore nell'inserimento del libro.");
            }
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            if(Libro == null) return;
            if (LibriController.Update(Libro))
            {
                MessageBox.Show("Libro modificato con successo!");
                DGV.DataSource = LibriController.Read();
            }
            else
            {
                MessageBox.Show("Errore nella modifica del libro.");
            }
        }

        private void btnCancellazione_Click(object sender, EventArgs e)
        {
            if (Libro == null) return;

            if(MessageBox.Show("Sei sicuro di voler cancellare il libro? \n" + Libro.ToString(), "Conferma Cancellazione", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            if (LibriController.Delete(Libro.CodiceISBN))
            {
                MessageBox.Show("Libro cancellato con successo!");
                DGV.DataSource = LibriController.Read();
            }
            else
            {
                MessageBox.Show("Errore nella cancellazione del libro.");
            }
        }
    }
}
