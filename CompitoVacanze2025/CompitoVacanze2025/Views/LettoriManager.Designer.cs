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
            this.ucLettore1 = new AnrangoRamosLibrary.UCLettore();
            this.SuspendLayout();
            // 
            // ucLettore1
            // 
            this.ucLettore1.Location = new System.Drawing.Point(12, 12);
            this.ucLettore1.Name = "ucLettore1";
            this.ucLettore1.Size = new System.Drawing.Size(237, 173);
            this.ucLettore1.TabIndex = 4;
            // 
            // LettoriManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ucLettore1);
            this.Name = "LettoriManager";
            this.Text = "LettoriManager";
            this.Controls.SetChildIndex(this.ucLettore1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private AnrangoRamosLibrary.UCLettore ucLettore1;
    }
}