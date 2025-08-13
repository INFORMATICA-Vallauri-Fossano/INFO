namespace CompitoVacanze2025
{
    partial class MENU
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
            this.btnManagerLettori = new System.Windows.Forms.Button();
            this.btnManagerLibri = new System.Windows.Forms.Button();
            this.btnPrestiti = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManagerLettori
            // 
            this.btnManagerLettori.Location = new System.Drawing.Point(16, 15);
            this.btnManagerLettori.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnManagerLettori.Name = "btnManagerLettori";
            this.btnManagerLettori.Size = new System.Drawing.Size(268, 38);
            this.btnManagerLettori.TabIndex = 0;
            this.btnManagerLettori.Text = "LETTORI";
            this.btnManagerLettori.UseVisualStyleBackColor = true;
            this.btnManagerLettori.Click += new System.EventHandler(this.btnManagerLettori_Click);
            // 
            // btnManagerLibri
            // 
            this.btnManagerLibri.Location = new System.Drawing.Point(16, 60);
            this.btnManagerLibri.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnManagerLibri.Name = "btnManagerLibri";
            this.btnManagerLibri.Size = new System.Drawing.Size(268, 38);
            this.btnManagerLibri.TabIndex = 1;
            this.btnManagerLibri.Text = "LIBRI";
            this.btnManagerLibri.UseVisualStyleBackColor = true;
            this.btnManagerLibri.Click += new System.EventHandler(this.btnManagerLibri_Click);
            // 
            // btnPrestiti
            // 
            this.btnPrestiti.Location = new System.Drawing.Point(16, 106);
            this.btnPrestiti.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrestiti.Name = "btnPrestiti";
            this.btnPrestiti.Size = new System.Drawing.Size(268, 38);
            this.btnPrestiti.TabIndex = 2;
            this.btnPrestiti.Text = "PRESTITI";
            this.btnPrestiti.UseVisualStyleBackColor = true;
            this.btnPrestiti.Click += new System.EventHandler(this.btnPrestiti_Click);
            // 
            // MENU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnPrestiti);
            this.Controls.Add(this.btnManagerLibri);
            this.Controls.Add(this.btnManagerLettori);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MENU";
            this.Text = "MENU";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManagerLettori;
        private System.Windows.Forms.Button btnManagerLibri;
        private System.Windows.Forms.Button btnPrestiti;
    }
}

