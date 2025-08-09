namespace CompitoVacanze2025.Views
{
    partial class LettoriManager
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
            this.ucLettore = new AnrangoRamosLibrary.UCLettore();
            this.SuspendLayout();
            // 
            // btnInserimento
            // 
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
            // ucLettore
            // 
            this.ucLettore.Cognome = "";
            this.ucLettore.Email = "";
            this.ucLettore.Id = 0;
            this.ucLettore.Location = new System.Drawing.Point(12, 12);
            this.ucLettore.Name = "ucLettore";
            this.ucLettore.Nome = "";
            this.ucLettore.Size = new System.Drawing.Size(237, 173);
            this.ucLettore.TabIndex = 4;
            this.ucLettore.Telefono = "";
            // 
            // LettoriManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ucLettore);
            this.Name = "LettoriManager";
            this.Text = "LettoriManager";
            this.Controls.SetChildIndex(this.btnInserimento, 0);
            this.Controls.SetChildIndex(this.btnModifica, 0);
            this.Controls.SetChildIndex(this.btnCancellazione, 0);
            this.Controls.SetChildIndex(this.ucLettore, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private AnrangoRamosLibrary.UCLettore ucLettore;
    }
}