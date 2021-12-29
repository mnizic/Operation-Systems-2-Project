using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektOS
{
    public partial class Projekt : Form
    {
        public Projekt()
        {
            InitializeComponent();
        }

        private void stvoriNovuDatotekuButton_Click(object sender, EventArgs e)
        {
            NovaDatoteka form = new NovaDatoteka();
            form.ShowDialog();
        }
    }
}
