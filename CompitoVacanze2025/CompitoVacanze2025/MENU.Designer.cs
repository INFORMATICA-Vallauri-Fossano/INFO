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
            this.SuspendLayout();
            // 
            // btnManagerLettori
            // 
            this.btnManagerLettori.Location = new System.Drawing.Point(12, 12);
            this.btnManagerLettori.Name = "btnManagerLettori";
            this.btnManagerLettori.Size = new System.Drawing.Size(201, 31);
            this.btnManagerLettori.TabIndex = 0;
            this.btnManagerLettori.Text = "LETTORI";
            this.btnManagerLettori.UseVisualStyleBackColor = true;
            this.btnManagerLettori.Click += new System.EventHandler(this.btnManagerLettori_Click);
            // 
            // btnManagerLibri
            // 
            this.btnManagerLibri.Location = new System.Drawing.Point(12, 49);
            this.btnManagerLibri.Name = "btnManagerLibri";
            this.btnManagerLibri.Size = new System.Drawing.Size(201, 31);
            this.btnManagerLibri.TabIndex = 1;
            this.btnManagerLibri.Text = "LIBRI";
            this.btnManagerLibri.UseVisualStyleBackColor = true;
            // 
            // MENU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnManagerLibri);
            this.Controls.Add(this.btnManagerLettori);
            this.Name = "MENU";
            this.Text = "MENU";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManagerLettori;
        private System.Windows.Forms.Button btnManagerLibri;
    }
}

