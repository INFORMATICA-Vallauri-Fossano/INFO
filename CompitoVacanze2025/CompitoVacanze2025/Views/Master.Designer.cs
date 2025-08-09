namespace CompitoVacanze2025.Views
{
    partial class Master
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
            this.btnInserimento = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnCancellazione = new System.Windows.Forms.Button();
            this.DGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInserimento
            // 
            this.btnInserimento.Location = new System.Drawing.Point(184, 357);
            this.btnInserimento.Name = "btnInserimento";
            this.btnInserimento.Size = new System.Drawing.Size(159, 23);
            this.btnInserimento.TabIndex = 0;
            this.btnInserimento.Text = "INSERIMENTO";
            this.btnInserimento.UseVisualStyleBackColor = true;
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(184, 386);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(159, 23);
            this.btnModifica.TabIndex = 1;
            this.btnModifica.Text = "MODIFICA";
            this.btnModifica.UseVisualStyleBackColor = true;
            // 
            // btnCancellazione
            // 
            this.btnCancellazione.Location = new System.Drawing.Point(184, 415);
            this.btnCancellazione.Name = "btnCancellazione";
            this.btnCancellazione.Size = new System.Drawing.Size(159, 23);
            this.btnCancellazione.TabIndex = 2;
            this.btnCancellazione.Text = "CANCELLAZIONE";
            this.btnCancellazione.UseVisualStyleBackColor = true;
            // 
            // DGV
            // 
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(349, 12);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(439, 426);
            this.DGV.TabIndex = 3;
            // 
            // Master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.btnCancellazione);
            this.Controls.Add(this.btnModifica);
            this.Controls.Add(this.btnInserimento);
            this.Name = "Master";
            this.Text = "Master";
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView DGV;
        public System.Windows.Forms.Button btnInserimento;
        public System.Windows.Forms.Button btnModifica;
        public System.Windows.Forms.Button btnCancellazione;
    }
}