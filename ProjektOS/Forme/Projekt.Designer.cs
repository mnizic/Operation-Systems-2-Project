
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
            this.simetricnoRadio = new System.Windows.Forms.RadioButton();
            this.asimetricnoRadio = new System.Windows.Forms.RadioButton();
            this.enkriptirajButton = new System.Windows.Forms.Button();
            this.dekriptirajButton = new System.Windows.Forms.Button();
            this.obicanTekstSadrzaj = new System.Windows.Forms.TextBox();
            this.sazetakTextBox = new System.Windows.Forms.TextBox();
            this.otvoriKriptiraniTekst = new System.Windows.Forms.Button();
            this.ocistiButton = new System.Windows.Forms.Button();
            this.digitalniPotpisTextBox = new System.Windows.Forms.TextBox();
            this.digitalniPotpisButton = new System.Windows.Forms.Button();
            this.provjeraButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.enkriptiraniSadrzaj = new System.Windows.Forms.TextBox();
            this.provjeraLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // stvoriNovuDatotekuButton
            // 
            this.stvoriNovuDatotekuButton.Location = new System.Drawing.Point(15, 32);
            this.stvoriNovuDatotekuButton.Name = "stvoriNovuDatotekuButton";
            this.stvoriNovuDatotekuButton.Size = new System.Drawing.Size(154, 36);
            this.stvoriNovuDatotekuButton.TabIndex = 0;
            this.stvoriNovuDatotekuButton.Text = "Stvori novu datoteku";
            this.stvoriNovuDatotekuButton.UseVisualStyleBackColor = true;
            this.stvoriNovuDatotekuButton.Click += new System.EventHandler(this.stvoriNovuDatotekuButton_Click);
            // 
            // otvoriDatotekuButton
            // 
            this.otvoriDatotekuButton.Location = new System.Drawing.Point(175, 32);
            this.otvoriDatotekuButton.Name = "otvoriDatotekuButton";
            this.otvoriDatotekuButton.Size = new System.Drawing.Size(154, 36);
            this.otvoriDatotekuButton.TabIndex = 1;
            this.otvoriDatotekuButton.Text = "Otvori datoteku";
            this.otvoriDatotekuButton.UseVisualStyleBackColor = true;
            this.otvoriDatotekuButton.Click += new System.EventHandler(this.otvoriDatotekuButton_Click);
            // 
            // simetricnoRadio
            // 
            this.simetricnoRadio.AutoSize = true;
            this.simetricnoRadio.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.simetricnoRadio.Checked = true;
            this.simetricnoRadio.Location = new System.Drawing.Point(383, 148);
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
            this.asimetricnoRadio.Location = new System.Drawing.Point(530, 148);
            this.asimetricnoRadio.Name = "asimetricnoRadio";
            this.asimetricnoRadio.Size = new System.Drawing.Size(102, 21);
            this.asimetricnoRadio.TabIndex = 4;
            this.asimetricnoRadio.Text = "Asimetrično";
            this.asimetricnoRadio.UseVisualStyleBackColor = true;
            // 
            // enkriptirajButton
            // 
            this.enkriptirajButton.Location = new System.Drawing.Point(442, 106);
            this.enkriptirajButton.Name = "enkriptirajButton";
            this.enkriptirajButton.Size = new System.Drawing.Size(130, 36);
            this.enkriptirajButton.TabIndex = 5;
            this.enkriptirajButton.Text = "Enkriptiraj";
            this.enkriptirajButton.UseVisualStyleBackColor = true;
            this.enkriptirajButton.Click += new System.EventHandler(this.enkriptirajButton_Click);
            // 
            // dekriptirajButton
            // 
            this.dekriptirajButton.Location = new System.Drawing.Point(442, 171);
            this.dekriptirajButton.Name = "dekriptirajButton";
            this.dekriptirajButton.Size = new System.Drawing.Size(130, 36);
            this.dekriptirajButton.TabIndex = 6;
            this.dekriptirajButton.Text = "Dekriptiraj";
            this.dekriptirajButton.UseVisualStyleBackColor = true;
            this.dekriptirajButton.Click += new System.EventHandler(this.dekriptirajButton_Click);
            // 
            // obicanTekstSadrzaj
            // 
            this.obicanTekstSadrzaj.Enabled = false;
            this.obicanTekstSadrzaj.Location = new System.Drawing.Point(12, 106);
            this.obicanTekstSadrzaj.Multiline = true;
            this.obicanTekstSadrzaj.Name = "obicanTekstSadrzaj";
            this.obicanTekstSadrzaj.Size = new System.Drawing.Size(365, 144);
            this.obicanTekstSadrzaj.TabIndex = 8;
            // 
            // sazetakTextBox
            // 
            this.sazetakTextBox.Enabled = false;
            this.sazetakTextBox.Location = new System.Drawing.Point(15, 291);
            this.sazetakTextBox.Multiline = true;
            this.sazetakTextBox.Name = "sazetakTextBox";
            this.sazetakTextBox.Size = new System.Drawing.Size(513, 32);
            this.sazetakTextBox.TabIndex = 9;
            // 
            // otvoriKriptiraniTekst
            // 
            this.otvoriKriptiraniTekst.Location = new System.Drawing.Point(640, 26);
            this.otvoriKriptiraniTekst.Name = "otvoriKriptiraniTekst";
            this.otvoriKriptiraniTekst.Size = new System.Drawing.Size(129, 48);
            this.otvoriKriptiraniTekst.TabIndex = 10;
            this.otvoriKriptiraniTekst.Text = "Otvori kriptiranu datoteku";
            this.otvoriKriptiraniTekst.UseVisualStyleBackColor = true;
            this.otvoriKriptiraniTekst.Click += new System.EventHandler(this.otvoriKriptiraniTekst_Click);
            // 
            // ocistiButton
            // 
            this.ocistiButton.Location = new System.Drawing.Point(442, 214);
            this.ocistiButton.Name = "ocistiButton";
            this.ocistiButton.Size = new System.Drawing.Size(130, 36);
            this.ocistiButton.TabIndex = 11;
            this.ocistiButton.Text = "Očisti sve";
            this.ocistiButton.UseVisualStyleBackColor = true;
            this.ocistiButton.Click += new System.EventHandler(this.ocistiButton_Click);
            // 
            // digitalniPotpisTextBox
            // 
            this.digitalniPotpisTextBox.Enabled = false;
            this.digitalniPotpisTextBox.Location = new System.Drawing.Point(15, 365);
            this.digitalniPotpisTextBox.Multiline = true;
            this.digitalniPotpisTextBox.Name = "digitalniPotpisTextBox";
            this.digitalniPotpisTextBox.Size = new System.Drawing.Size(754, 101);
            this.digitalniPotpisTextBox.TabIndex = 13;
            // 
            // digitalniPotpisButton
            // 
            this.digitalniPotpisButton.Location = new System.Drawing.Point(15, 472);
            this.digitalniPotpisButton.Name = "digitalniPotpisButton";
            this.digitalniPotpisButton.Size = new System.Drawing.Size(130, 36);
            this.digitalniPotpisButton.TabIndex = 14;
            this.digitalniPotpisButton.Text = "Digitalni potpis";
            this.digitalniPotpisButton.UseVisualStyleBackColor = true;
            this.digitalniPotpisButton.Click += new System.EventHandler(this.digitalniPotpisButton_Click);
            // 
            // provjeraButton
            // 
            this.provjeraButton.Location = new System.Drawing.Point(151, 472);
            this.provjeraButton.Name = "provjeraButton";
            this.provjeraButton.Size = new System.Drawing.Size(130, 36);
            this.provjeraButton.TabIndex = 15;
            this.provjeraButton.Text = "Provjera";
            this.provjeraButton.UseVisualStyleBackColor = true;
            this.provjeraButton.Click += new System.EventHandler(this.provjeraButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(635, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Enkriptirani tekst";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Običan tekst";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Sažetak običnog teksta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 345);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Digitalni potpis";
            // 
            // enkriptiraniSadrzaj
            // 
            this.enkriptiraniSadrzaj.Enabled = false;
            this.enkriptiraniSadrzaj.Location = new System.Drawing.Point(638, 106);
            this.enkriptiraniSadrzaj.Multiline = true;
            this.enkriptiraniSadrzaj.Name = "enkriptiraniSadrzaj";
            this.enkriptiraniSadrzaj.Size = new System.Drawing.Size(365, 217);
            this.enkriptiraniSadrzaj.TabIndex = 7;
            // 
            // provjeraLabel
            // 
            this.provjeraLabel.AutoSize = true;
            this.provjeraLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.provjeraLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.provjeraLabel.Location = new System.Drawing.Point(308, 472);
            this.provjeraLabel.Name = "provjeraLabel";
            this.provjeraLabel.Size = new System.Drawing.Size(353, 36);
            this.provjeraLabel.TabIndex = 21;
            this.provjeraLabel.Text = "Digitalni potpis je validan!";
            this.provjeraLabel.Visible = false;
            // 
            // Projekt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 535);
            this.Controls.Add(this.provjeraLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.provjeraButton);
            this.Controls.Add(this.digitalniPotpisButton);
            this.Controls.Add(this.digitalniPotpisTextBox);
            this.Controls.Add(this.ocistiButton);
            this.Controls.Add(this.otvoriKriptiraniTekst);
            this.Controls.Add(this.sazetakTextBox);
            this.Controls.Add(this.obicanTekstSadrzaj);
            this.Controls.Add(this.enkriptiraniSadrzaj);
            this.Controls.Add(this.dekriptirajButton);
            this.Controls.Add(this.enkriptirajButton);
            this.Controls.Add(this.asimetricnoRadio);
            this.Controls.Add(this.simetricnoRadio);
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
        private System.Windows.Forms.RadioButton simetricnoRadio;
        private System.Windows.Forms.RadioButton asimetricnoRadio;
        private System.Windows.Forms.Button enkriptirajButton;
        private System.Windows.Forms.Button dekriptirajButton;
        private System.Windows.Forms.TextBox obicanTekstSadrzaj;
        private System.Windows.Forms.TextBox sazetakTextBox;
        private System.Windows.Forms.Button otvoriKriptiraniTekst;
        private System.Windows.Forms.Button ocistiButton;
        private System.Windows.Forms.TextBox digitalniPotpisTextBox;
        private System.Windows.Forms.Button digitalniPotpisButton;
        private System.Windows.Forms.Button provjeraButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox enkriptiraniSadrzaj;
        private System.Windows.Forms.Label provjeraLabel;
    }
}

