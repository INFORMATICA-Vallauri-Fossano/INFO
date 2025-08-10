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
    public partial class LettoriManager : Master
    {

        public LettoriManager()
        {
            InitializeComponent();
            DGV.DataSource = LettoriController.Read();
            DGV.RowEnter+= fillFormLettore;
        }

        private void fillFormLettore(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var lettore = DGV.Rows[e.RowIndex].DataBoundItem as Lettore;
            if (lettore == null) return;
            Lettore = lettore;
        }

        private Lettore Lettore
        {
            get
            {
                try
                {
                    return new Lettore(
                  ucLettore.Id,
                  ucLettore.Nome,
                  ucLettore.Cognome,
                  ucLettore.Email,
                  ucLettore.Telefono
                  );
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Errore nella costruzione del lettore: " + ex.Message);
                }
                return null;
            }
            set
            {
                ucLettore.Id = value.IdLettore;
                ucLettore.Nome = value.Nome;
                ucLettore.Cognome = value.Cognome;
                ucLettore.Telefono = value.Telefono;
                ucLettore.Email = value.Email;
            }
        }
        private void btnInserimento_Click(object sender, EventArgs e)
        {
            if (Lettore == null)
                return; // Abort operation if Lettore construction failed

            if (LettoriController.Create(Lettore))
            {
                MessageBox.Show("Lettore inserito con successo!");
                DGV.DataSource = LettoriController.Read();
            }
            else
            {
                MessageBox.Show("Errore nell'inserimento del lettore.");
            }
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            if (Lettore == null)
                return; // Abort operation if Lettore construction failed

            if (LettoriController.Update(Lettore))
            {
                MessageBox.Show("Lettore modificato con successo!");
                DGV.DataSource = LettoriController.Read();
            }
            else
            {
                MessageBox.Show("Errore nella modifica del lettore.");
            }
        }

        private void btnCancellazione_Click(object sender, EventArgs e)
        {
            if (Lettore == null)
                return; // Abort operation if Lettore construction failed

            if(MessageBox.Show("Sei sicuro di voler cancellare il lettore selezionato?\n"+Lettore.ToString(), "Conferma Cancellazione", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            if (LettoriController.Delete(Lettore.IdLettore))
            {
                MessageBox.Show("Lettore cancellato con successo!");
                DGV.DataSource = LettoriController.Read();
            }
            else
            {
                MessageBox.Show("Errore nella cancellazione del lettore.");
            }
        }
    }
    }
