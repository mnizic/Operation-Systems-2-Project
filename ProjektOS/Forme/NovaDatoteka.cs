using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektOS
{
    public partial class NovaDatoteka : Form
    {
        public NovaDatoteka()
        {
            InitializeComponent();
        }

        private void stvoriButton_Click(object sender, EventArgs e)
        {
            string sadrzaj = sadrzajTextBox.Text.ToString();

            using(SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.RestoreDirectory = true;
                dialog.Filter = "Text files (*.txt)|*.txt";
                dialog.DefaultExt = "txt";
                
                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(dialog.FileName, sadrzaj);
                }
            }

            Close();
        }

        private void ponistiButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
