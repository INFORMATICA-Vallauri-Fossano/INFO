namespace CompitoVacanze2025.Views
{
    partial class Restituzioni
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
            this.btnRestituisci = new System.Windows.Forms.Button();
            this.dgvLibriInPrestito = new System.Windows.Forms.DataGridView();
            this.cmbLettori = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibriInPrestito)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRestituisci
            // 
            this.btnRestituisci.Location = new System.Drawing.Point(358, 104);
            this.btnRestituisci.Margin = new System.Windows.Forms.Padding(2);
            this.btnRestituisci.Name = "btnRestituisci";
            this.btnRestituisci.Size = new System.Drawing.Size(116, 19);
            this.btnRestituisci.TabIndex = 12;
            this.btnRestituisci.Text = "PRENDI IN PRESTITO";
            this.btnRestituisci.UseVisualStyleBackColor = true;
            this.btnRestituisci.Click += new System.EventHandler(this.btnRestituisci_Click);
            // 
            // dgvLibriInPrestito
            // 
            this.dgvLibriInPrestito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLibriInPrestito.Location = new System.Drawing.Point(156, 127);
            this.dgvLibriInPrestito.Margin = new System.Windows.Forms.Padding(2);
            this.dgvLibriInPrestito.Name = "dgvLibriInPrestito";
            this.dgvLibriInPrestito.RowHeadersWidth = 51;
            this.dgvLibriInPrestito.Size = new System.Drawing.Size(317, 247);
            this.dgvLibriInPrestito.TabIndex = 11;
            // 
            // cmbLettori
            // 
            this.cmbLettori.FormattingEnabled = true;
            this.cmbLettori.Location = new System.Drawing.Point(156, 60);
            this.cmbLettori.Margin = new System.Windows.Forms.Padding(2);
            this.cmbLettori.Name = "cmbLettori";
            this.cmbLettori.Size = new System.Drawing.Size(318, 21);
            this.cmbLettori.TabIndex = 10;
            this.cmbLettori.TextUpdate += new System.EventHandler(this.cmbLettori_TextUpdate);
            // 
            // Restituzioni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 450);
            this.Controls.Add(this.btnRestituisci);
            this.Controls.Add(this.dgvLibriInPrestito);
            this.Controls.Add(this.cmbLettori);
            this.Name = "Restituzioni";
            this.Text = "Restituzioni";
            this.Load += new System.EventHandler(this.Restituzioni_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibriInPrestito)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRestituisci;
        private System.Windows.Forms.DataGridView dgvLibriInPrestito;
        public System.Windows.Forms.ComboBox cmbLettori;
    }
}