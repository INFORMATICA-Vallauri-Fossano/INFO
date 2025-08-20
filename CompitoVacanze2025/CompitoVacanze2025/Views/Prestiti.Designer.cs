namespace CompitoVacanze2025.Views
{
    partial class Prestiti
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
            this.cmbAutori = new System.Windows.Forms.ComboBox();
            this.btnPresta = new System.Windows.Forms.Button();
            this.cmbGeneri = new System.Windows.Forms.ComboBox();
            this.dgvLibriPrestabili = new System.Windows.Forms.DataGridView();
            this.cmbLettori = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibriPrestabili)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbAutori
            // 
            this.cmbAutori.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbAutori.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAutori.FormattingEnabled = true;
            this.cmbAutori.Location = new System.Drawing.Point(142, 48);
            this.cmbAutori.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAutori.Name = "cmbAutori";
            this.cmbAutori.Size = new System.Drawing.Size(154, 21);
            this.cmbAutori.TabIndex = 10;
            // 
            // btnPresta
            // 
            this.btnPresta.Location = new System.Drawing.Point(344, 70);
            this.btnPresta.Margin = new System.Windows.Forms.Padding(2);
            this.btnPresta.Name = "btnPresta";
            this.btnPresta.Size = new System.Drawing.Size(116, 19);
            this.btnPresta.TabIndex = 9;
            this.btnPresta.Text = "PRENDI IN PRESTITO";
            this.btnPresta.UseVisualStyleBackColor = true;
            this.btnPresta.Click += new System.EventHandler(this.Presta_Click);
            // 
            // cmbGeneri
            // 
            this.cmbGeneri.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGeneri.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGeneri.FormattingEnabled = true;
            this.cmbGeneri.Location = new System.Drawing.Point(308, 48);
            this.cmbGeneri.Margin = new System.Windows.Forms.Padding(2);
            this.cmbGeneri.Name = "cmbGeneri";
            this.cmbGeneri.Size = new System.Drawing.Size(152, 21);
            this.cmbGeneri.TabIndex = 8;
            // 
            // dgvLibriPrestabili
            // 
            this.dgvLibriPrestabili.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLibriPrestabili.Location = new System.Drawing.Point(142, 93);
            this.dgvLibriPrestabili.Margin = new System.Windows.Forms.Padding(2);
            this.dgvLibriPrestabili.Name = "dgvLibriPrestabili";
            this.dgvLibriPrestabili.RowHeadersWidth = 51;
            this.dgvLibriPrestabili.Size = new System.Drawing.Size(317, 247);
            this.dgvLibriPrestabili.TabIndex = 7;
            // 
            // cmbLettori
            // 
            this.cmbLettori.FormattingEnabled = true;
            this.cmbLettori.Location = new System.Drawing.Point(142, 26);
            this.cmbLettori.Margin = new System.Windows.Forms.Padding(2);
            this.cmbLettori.Name = "cmbLettori";
            this.cmbLettori.Size = new System.Drawing.Size(318, 21);
            this.cmbLettori.TabIndex = 6;
            this.cmbLettori.TextUpdate += new System.EventHandler(this.lettori_TextUpdate);
            this.cmbLettori.SelectedValueChanged += new System.EventHandler(this.cmbLettori_SelectedValueChanged);
            // 
            // Prestiti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.cmbAutori);
            this.Controls.Add(this.btnPresta);
            this.Controls.Add(this.cmbGeneri);
            this.Controls.Add(this.dgvLibriPrestabili);
            this.Controls.Add(this.cmbLettori);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Prestiti";
            this.Text = "Prestiti";
            this.Load += new System.EventHandler(this.Prestiti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibriPrestabili)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbAutori;
        private System.Windows.Forms.Button btnPresta;
        private System.Windows.Forms.ComboBox cmbGeneri;
        private System.Windows.Forms.DataGridView dgvLibriPrestabili;
        public System.Windows.Forms.ComboBox cmbLettori;
    }
}