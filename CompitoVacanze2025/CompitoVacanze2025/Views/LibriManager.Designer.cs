namespace CompitoVacanze2025.Views
{
    partial class LibriManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ucLibro = new AnrangoRamosLibrary.UCLibro();
            this.SuspendLayout();
            // 
            // btnInserimento
            // 
            this.btnInserimento.Location = new System.Drawing.Point(12, 386);
            this.btnInserimento.Click += new System.EventHandler(this.btnInserimento_Click);
            // 
            // btnModifica
            // 
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
            // 
            // btnCancellazione
            // 
            this.btnCancellazione.Click += new System.EventHandler(this.btnCancellazione_Click);
            // 
            // ucLibro
            // 
            this.ucLibro.CasaEditrice = "";
            this.ucLibro.Collocazione = "";
            this.ucLibro.Copertina = "";
            this.ucLibro.DataPubblicazione = "10/08/2025 17:01:28";
            this.ucLibro.Disponibile = false;
            this.ucLibro.ISBN = "";
            this.ucLibro.Location = new System.Drawing.Point(12, 12);
            this.ucLibro.Name = "ucLibro";
            this.ucLibro.Pagine = "";
            this.ucLibro.Size = new System.Drawing.Size(254, 368);
            this.ucLibro.TabIndex = 4;
            this.ucLibro.Titolo = "";
            // 
            // LibriManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ucLibro);
            this.Name = "LibriManager";
            this.Text = "LibriManager";
            this.Controls.SetChildIndex(this.btnInserimento, 0);
            this.Controls.SetChildIndex(this.btnModifica, 0);
            this.Controls.SetChildIndex(this.btnCancellazione, 0);
            this.Controls.SetChildIndex(this.ucLibro, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private AnrangoRamosLibrary.UCLibro ucLibro;
    }
}