using ProjektOS.Klase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

        private void otvoriDatotekuButton_Click(object sender, EventArgs e)
        {
            string sadrzaj = String.Empty;

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.RestoreDirectory = true;
                dialog.Filter = "Text files (*.txt)|*.txt";
                dialog.DefaultExt = "txt";

                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader reader = new StreamReader(dialog.OpenFile()))
                    {
                        sadrzaj = reader.ReadToEnd();
                    }
                }
            }

            otvoriDatotekuSadrzaj.Text = sadrzaj;
        }

        private void enkriptirajButton_Click(object sender, EventArgs e)
        {
            if(otvoriDatotekuSadrzaj.Text != "")
            {
                enkriptiraniSadrzaj.Clear();

                if (simetricnoRadio.Checked)
                {
                    byte[] aesKey, aesIV;
                    using (Aes aes = Aes.Create())
                    {
                        aes.GenerateIV();
                        aes.GenerateKey();

                        aesIV = aes.IV;
                        aesKey = aes.Key;
                    }

                    string fileName = Directory.GetCurrentDirectory() + @"\tajni_kljuc.txt";

                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }

                    using (StreamWriter sw = File.CreateText(fileName))
                    {
                        String kljuc = Convert.ToBase64String(aesKey);
                        sw.WriteLine(kljuc);
                    }

                    byte[] sadrzaj = SimetricniAlgoritam.Enkriptiraj(otvoriDatotekuSadrzaj.Text, aesKey, aesIV);
                    enkriptiraniSadrzaj.Text += Convert.ToBase64String(sadrzaj);
                    enkriptiraniSadrzaj.Text += "\n\n Inicijalizacijski Vektor:";
                    enkriptiraniSadrzaj.Text += Convert.ToBase64String(aesIV);
                }
                else
                {
                    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

                    string javniKljuc = rsa.ToXmlString(false);
                    string javniKljucFile = Directory.GetCurrentDirectory() + @"\javni_kljuc.txt";

                    if (File.Exists(javniKljucFile))
                    {
                        File.Delete(javniKljucFile);
                    }

                    using (StreamWriter sw = File.CreateText(javniKljucFile))
                    {
                        sw.WriteLine(javniKljuc);
                    }

                    string privatniKljuc = rsa.ToXmlString(true);
                    string privatniKljucFile = Directory.GetCurrentDirectory() + @"\privatni_kljuc.txt";

                    if (File.Exists(privatniKljucFile))
                    {
                        File.Delete(privatniKljucFile);
                    }

                    using (StreamWriter sw = File.CreateText(privatniKljucFile))
                    {
                        sw.WriteLine(privatniKljuc);
                    }

                    byte[] sadrzaj = AsimetricniAlgoritam.EncryptText(javniKljuc, javniKljuc);
                    enkriptiraniSadrzaj.Text = Convert.ToBase64String(sadrzaj);
                }
            }
            
        }

        private void dekriptirajButton_Click(object sender, EventArgs e)
        {
            if(enkriptiraniSadrzaj.Text != "")
            {
                dekriptiraniSadrzaj.Clear();

                if (simetricnoRadio.Checked)
                {
                    string fileName = Directory.GetCurrentDirectory() + @"\tajni_kljuc.txt";

                    if (!File.Exists(fileName))
                    {
                        MessageBox.Show("Ne postoji datoteka tajni_kljuc.txt!");
                    }
                    else
                    {
                        int index = enkriptiraniSadrzaj.Text.IndexOf(":") + 1;
                        string stringAesIV = enkriptiraniSadrzaj.Text.Substring(index);
                        byte[] aesIV = Convert.FromBase64String(stringAesIV);

                        string stringAesKey = File.ReadAllText(fileName);
                        byte[] aesKey = Convert.FromBase64String(stringAesKey);

                        string[] cijeliEnkriptiraniTekst = enkriptiraniSadrzaj.Text.Split(' ');
                        byte[] enkriptiraniTekst = Convert.FromBase64String(cijeliEnkriptiraniTekst[0]);


                        dekriptiraniSadrzaj.Text = SimetricniAlgoritam.Dekriptiraj(enkriptiraniTekst, aesKey, aesIV);
                    }
                }
                else
                {

                }
            }
            
        }
    }
}
