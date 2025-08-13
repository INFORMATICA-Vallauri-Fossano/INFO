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
            this.autori = new System.Windows.Forms.ComboBox();
            this.Presta = new System.Windows.Forms.Button();
            this.generi = new System.Windows.Forms.ComboBox();
            this.libriPrestabili = new System.Windows.Forms.DataGridView();
            this.lettori = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.libriPrestabili)).BeginInit();
            this.SuspendLayout();
            // 
            // autori
            // 
            this.autori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.autori.FormattingEnabled = true;
            this.autori.Location = new System.Drawing.Point(189, 59);
            this.autori.Name = "autori";
            this.autori.Size = new System.Drawing.Size(204, 24);
            this.autori.TabIndex = 10;
            // 
            // Presta
            // 
            this.Presta.Location = new System.Drawing.Point(458, 86);
            this.Presta.Name = "Presta";
            this.Presta.Size = new System.Drawing.Size(154, 23);
            this.Presta.TabIndex = 9;
            this.Presta.Text = "PRENDI IN PRESTITO";
            this.Presta.UseVisualStyleBackColor = true;
            this.Presta.Click += new System.EventHandler(this.Presta_Click);
            // 
            // generi
            // 
            this.generi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.generi.FormattingEnabled = true;
            this.generi.Location = new System.Drawing.Point(411, 59);
            this.generi.Name = "generi";
            this.generi.Size = new System.Drawing.Size(201, 24);
            this.generi.TabIndex = 8;
            // 
            // libriPrestabili
            // 
            this.libriPrestabili.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.libriPrestabili.Location = new System.Drawing.Point(189, 115);
            this.libriPrestabili.Name = "libriPrestabili";
            this.libriPrestabili.Size = new System.Drawing.Size(423, 304);
            this.libriPrestabili.TabIndex = 7;
            // 
            // lettori
            // 
            this.lettori.FormattingEnabled = true;
            this.lettori.Location = new System.Drawing.Point(189, 32);
            this.lettori.Name = "lettori";
            this.lettori.Size = new System.Drawing.Size(423, 24);
            this.lettori.TabIndex = 6;
            // 
            // Prestiti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.autori);
            this.Controls.Add(this.Presta);
            this.Controls.Add(this.generi);
            this.Controls.Add(this.libriPrestabili);
            this.Controls.Add(this.lettori);
            this.Name = "Prestiti";
            this.Text = "Prestiti";
            ((System.ComponentModel.ISupportInitialize)(this.libriPrestabili)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox autori;
        private System.Windows.Forms.Button Presta;
        private System.Windows.Forms.ComboBox generi;
        private System.Windows.Forms.DataGridView libriPrestabili;
        private System.Windows.Forms.ComboBox lettori;
    }
}