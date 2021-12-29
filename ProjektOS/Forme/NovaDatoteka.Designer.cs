
namespace ProjektOS
{
    partial class NovaDatoteka
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
            this.label2 = new System.Windows.Forms.Label();
            this.sadrzajTextBox = new System.Windows.Forms.TextBox();
            this.stvoriButton = new System.Windows.Forms.Button();
            this.ponistiButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sadržaj datoteke:";
            // 
            // sadrzajTextBox
            // 
            this.sadrzajTextBox.Location = new System.Drawing.Point(15, 29);
            this.sadrzajTextBox.Multiline = true;
            this.sadrzajTextBox.Name = "sadrzajTextBox";
            this.sadrzajTextBox.Size = new System.Drawing.Size(209, 125);
            this.sadrzajTextBox.TabIndex = 3;
            // 
            // stvoriButton
            // 
            this.stvoriButton.Location = new System.Drawing.Point(127, 160);
            this.stvoriButton.Name = "stvoriButton";
            this.stvoriButton.Size = new System.Drawing.Size(97, 36);
            this.stvoriButton.TabIndex = 4;
            this.stvoriButton.Text = "Stvori";
            this.stvoriButton.UseVisualStyleBackColor = true;
            this.stvoriButton.Click += new System.EventHandler(this.stvoriButton_Click);
            // 
            // ponistiButton
            // 
            this.ponistiButton.Location = new System.Drawing.Point(15, 160);
            this.ponistiButton.Name = "ponistiButton";
            this.ponistiButton.Size = new System.Drawing.Size(97, 36);
            this.ponistiButton.TabIndex = 5;
            this.ponistiButton.Text = "Poništi";
            this.ponistiButton.UseVisualStyleBackColor = true;
            this.ponistiButton.Click += new System.EventHandler(this.ponistiButton_Click);
            // 
            // NovaDatoteka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 217);
            this.Controls.Add(this.ponistiButton);
            this.Controls.Add(this.stvoriButton);
            this.Controls.Add(this.sadrzajTextBox);
            this.Controls.Add(this.label2);
            this.Name = "NovaDatoteka";
            this.Text = "Stvori datoteku";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sadrzajTextBox;
        private System.Windows.Forms.Button stvoriButton;
        private System.Windows.Forms.Button ponistiButton;
    }
}