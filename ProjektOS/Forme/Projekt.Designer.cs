
namespace ProjektOS
{
    partial class Projekt
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
            this.stvoriNovuDatotekuButton = new System.Windows.Forms.Button();
            this.otvoriDatotekuButton = new System.Windows.Forms.Button();
            this.otvoriDatotekuSadrzaj = new System.Windows.Forms.TextBox();
            this.simetricnoRadio = new System.Windows.Forms.RadioButton();
            this.asimetricnoRadio = new System.Windows.Forms.RadioButton();
            this.enkriptirajButton = new System.Windows.Forms.Button();
            this.dekriptirajButton = new System.Windows.Forms.Button();
            this.enkriptiraniSadrzaj = new System.Windows.Forms.TextBox();
            this.dekriptiraniSadrzaj = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // stvoriNovuDatotekuButton
            // 
            this.stvoriNovuDatotekuButton.Location = new System.Drawing.Point(12, 12);
            this.stvoriNovuDatotekuButton.Name = "stvoriNovuDatotekuButton";
            this.stvoriNovuDatotekuButton.Size = new System.Drawing.Size(130, 36);
            this.stvoriNovuDatotekuButton.TabIndex = 0;
            this.stvoriNovuDatotekuButton.Text = "Stvori datoteku";
            this.stvoriNovuDatotekuButton.UseVisualStyleBackColor = true;
            this.stvoriNovuDatotekuButton.Click += new System.EventHandler(this.stvoriNovuDatotekuButton_Click);
            // 
            // otvoriDatotekuButton
            // 
            this.otvoriDatotekuButton.Location = new System.Drawing.Point(12, 54);
            this.otvoriDatotekuButton.Name = "otvoriDatotekuButton";
            this.otvoriDatotekuButton.Size = new System.Drawing.Size(130, 36);
            this.otvoriDatotekuButton.TabIndex = 1;
            this.otvoriDatotekuButton.Text = "Otvori datoteku";
            this.otvoriDatotekuButton.UseVisualStyleBackColor = true;
            this.otvoriDatotekuButton.Click += new System.EventHandler(this.otvoriDatotekuButton_Click);
            // 
            // otvoriDatotekuSadrzaj
            // 
            this.otvoriDatotekuSadrzaj.Location = new System.Drawing.Point(161, 12);
            this.otvoriDatotekuSadrzaj.Multiline = true;
            this.otvoriDatotekuSadrzaj.Name = "otvoriDatotekuSadrzaj";
            this.otvoriDatotekuSadrzaj.Size = new System.Drawing.Size(216, 78);
            this.otvoriDatotekuSadrzaj.TabIndex = 2;
            // 
            // simetricnoRadio
            // 
            this.simetricnoRadio.AutoSize = true;
            this.simetricnoRadio.Checked = true;
            this.simetricnoRadio.Location = new System.Drawing.Point(47, 213);
            this.simetricnoRadio.Name = "simetricnoRadio";
            this.simetricnoRadio.Size = new System.Drawing.Size(95, 21);
            this.simetricnoRadio.TabIndex = 3;
            this.simetricnoRadio.TabStop = true;
            this.simetricnoRadio.Text = "Simetrično";
            this.simetricnoRadio.UseVisualStyleBackColor = true;
            // 
            // asimetricnoRadio
            // 
            this.asimetricnoRadio.AutoSize = true;
            this.asimetricnoRadio.Location = new System.Drawing.Point(148, 213);
            this.asimetricnoRadio.Name = "asimetricnoRadio";
            this.asimetricnoRadio.Size = new System.Drawing.Size(102, 21);
            this.asimetricnoRadio.TabIndex = 4;
            this.asimetricnoRadio.Text = "Asimetrično";
            this.asimetricnoRadio.UseVisualStyleBackColor = true;
            // 
            // enkriptirajButton
            // 
            this.enkriptirajButton.Location = new System.Drawing.Point(12, 240);
            this.enkriptirajButton.Name = "enkriptirajButton";
            this.enkriptirajButton.Size = new System.Drawing.Size(130, 36);
            this.enkriptirajButton.TabIndex = 5;
            this.enkriptirajButton.Text = "Enkriptiraj";
            this.enkriptirajButton.UseVisualStyleBackColor = true;
            this.enkriptirajButton.Click += new System.EventHandler(this.enkriptirajButton_Click);
            // 
            // dekriptirajButton
            // 
            this.dekriptirajButton.Location = new System.Drawing.Point(148, 240);
            this.dekriptirajButton.Name = "dekriptirajButton";
            this.dekriptirajButton.Size = new System.Drawing.Size(130, 36);
            this.dekriptirajButton.TabIndex = 6;
            this.dekriptirajButton.Text = "Dekriptiraj";
            this.dekriptirajButton.UseVisualStyleBackColor = true;
            this.dekriptirajButton.Click += new System.EventHandler(this.dekriptirajButton_Click);
            // 
            // enkriptiraniSadrzaj
            // 
            this.enkriptiraniSadrzaj.Enabled = false;
            this.enkriptiraniSadrzaj.Location = new System.Drawing.Point(12, 106);
            this.enkriptiraniSadrzaj.Multiline = true;
            this.enkriptiraniSadrzaj.Name = "enkriptiraniSadrzaj";
            this.enkriptiraniSadrzaj.Size = new System.Drawing.Size(266, 101);
            this.enkriptiraniSadrzaj.TabIndex = 7;
            // 
            // dekriptiraniSadrzaj
            // 
            this.dekriptiraniSadrzaj.Enabled = false;
            this.dekriptiraniSadrzaj.Location = new System.Drawing.Point(12, 292);
            this.dekriptiraniSadrzaj.Multiline = true;
            this.dekriptiraniSadrzaj.Name = "dekriptiraniSadrzaj";
            this.dekriptiraniSadrzaj.Size = new System.Drawing.Size(266, 101);
            this.dekriptiraniSadrzaj.TabIndex = 8;
            // 
            // Projekt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 450);
            this.Controls.Add(this.dekriptiraniSadrzaj);
            this.Controls.Add(this.enkriptiraniSadrzaj);
            this.Controls.Add(this.dekriptirajButton);
            this.Controls.Add(this.enkriptirajButton);
            this.Controls.Add(this.asimetricnoRadio);
            this.Controls.Add(this.simetricnoRadio);
            this.Controls.Add(this.otvoriDatotekuSadrzaj);
            this.Controls.Add(this.otvoriDatotekuButton);
            this.Controls.Add(this.stvoriNovuDatotekuButton);
            this.Name = "Projekt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Projekt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button stvoriNovuDatotekuButton;
        private System.Windows.Forms.Button otvoriDatotekuButton;
        private System.Windows.Forms.TextBox otvoriDatotekuSadrzaj;
        private System.Windows.Forms.RadioButton simetricnoRadio;
        private System.Windows.Forms.RadioButton asimetricnoRadio;
        private System.Windows.Forms.Button enkriptirajButton;
        private System.Windows.Forms.Button dekriptirajButton;
        private System.Windows.Forms.TextBox enkriptiraniSadrzaj;
        private System.Windows.Forms.TextBox dekriptiraniSadrzaj;
    }
}

