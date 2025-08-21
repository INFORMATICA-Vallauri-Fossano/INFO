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
    public partial class Sondaggi : Form
    {
        public Sondaggi()
        {
            InitializeComponent();
        }
        List<Libro> libri = LibriController.Read();
        List<Prestito> prestiti= PrestitiController.Read();
        List<Lettore> lettori= LettoriController.Read();
        private void button1_Click(object sender, EventArgs e)
        {
            // Step 1: Count the number of times each book (by CodiceISBN) appears in prestiti
            var topBooks = prestiti
                .GroupBy(p => p.CodiceISBN)
                .Select(g => new
                {
                    CodiceISBN = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(x => x.Count)
                .Take(5)
                .ToList();

            // Step 2: Get the corresponding Libro objects and prepare chart data
            chart1.Series.Clear();
            var series = chart1.Series.Add("Most Read Books");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            foreach (var book in topBooks)
            {
                var libro = libri.FirstOrDefault(l => l.CodiceISBN == book.CodiceISBN);
                string titolo = libro != null ? libro.Titolo : "Unknown";
                series.Points.AddXY(titolo, book.Count);
            }

            chart1.ChartAreas[0].AxisX.Title = "Book Title";
            chart1.ChartAreas[0].AxisY.Title = "Times Read";
        }

        private void Sondaggi_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Step 1: Find all libri that do NOT have any prestiti associated (left join libri with prestiti, keep libri with no matches)
            var mailetti = libri
                .GroupJoin(
                    prestiti,
                    l => l.CodiceISBN,
                    p => p.CodiceISBN,
                    (l, ps) => new { Libro = l, Prestiti = ps }
                )
                .Where(x => !x.Prestiti.Any())
                .Select(x => x.Libro)
                .ToList();

            MessageBox.Show(string.Join("\n", mailetti.Select(l => l.ToString())));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var nonsonolettori = lettori.GroupJoin(
                prestiti.Where(p => p.DataFine >= DateTime.Parse("01/01/2025")),
                l => l.IdLettore,
                p => p.IdLettore,
                (l, ps) => new { Lettore = l, Prestiti = ps }
                )
                .Where(x => !x.Prestiti.Any())
                .Select(x => x.Lettore.IdLettore+" : "+x.Lettore.Cognome+" "+x.Lettore.Nome);
            MessageBox.Show(string.Join("\n", nonsonolettori));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataRow[] migliori = queryController.quattro().Select();
            MessageBox.Show(string.Join("\n", migliori.Select(m => $"{m["cognome"]} {m["nome"]} prestiti: {m["prestiti"]}")));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<Lettore> ritardatari = queryController.cinque();
            MessageBox.Show(string.Join("\n", ritardatari.Select(r => r.ToString())));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int media= queryController.sei();
            MessageBox.Show("In genere si restituisce un libro dopo " + media + " giorni di prestito");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataRow[] inprestito= queryController.sette().Select();
            MessageBox.Show(string.Join("\n", inprestito.Select(p => $"when: {p["datainizio"]} what: {p["titolo"]}")));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataRow[] prestitiMeseAnno = queryController.otto().Select();
            MessageBox.Show(string.Join("\n", prestitiMeseAnno.Select(p =>
                $"Anno:{p["Anno"]} | " +
                $"Gennaio:{p["Gennaio"]} " +
                $"Febbraio:{p["Febbraio"]} " +
                $"Marzo:{p["Marzo"]} " +
                $"Aprile:{p["Aprile"]} " +
                $"Maggio:{p["Maggio"]} " +
                $"Giugno:{p["Giugno"]} " +
                $"Luglio:{p["Luglio"]} " +
                $"Agosto:{p["Agosto"]} " +
                $"Settembre:{p["Settembre"]} " +
                $"Ottobre:{p["Ottobre"]} " +
                $"Novembre:{p["Novembre"]} " +
                $"Dicembre:{p["Dicembre"]} "+
                $"| Totale:{p["Totale"]}"
            )));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In questo periodo sono stati presi in prestito " + queryController.nove(dateTimePicker1.Value,dateTimePicker2.Value) + " libri.");
        }
    }
}
