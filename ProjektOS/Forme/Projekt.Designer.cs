
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
            // Projekt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 450);
            this.Controls.Add(this.stvoriNovuDatotekuButton);
            this.Name = "Projekt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Projekt";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button stvoriNovuDatotekuButton;
    }
}

