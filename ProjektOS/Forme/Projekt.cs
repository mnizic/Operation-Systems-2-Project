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

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader reader = new StreamReader(dialog.OpenFile()))
                    {
                        sadrzaj = reader.ReadToEnd();
                    }
                }
            }

            otvoriDatotekuSadrzaj.Text = sadrzaj;

            byte[] sazetakByte = IzracunSazetka.ComputeSha256Hash(sadrzaj);

            string sazetak = string.Concat(sazetakByte.Select(x => x.ToString("x2")));

            sazetakTextBox.Text = sazetak;
            string sazetakDatoteka = Directory.GetCurrentDirectory() + @"\sazetak_poruke.txt";


            if (File.Exists(sazetakDatoteka))
            {
                File.Delete(sazetakDatoteka);
            }

            using (StreamWriter sw = File.CreateText(sazetakDatoteka))
            {
                sw.WriteLine(sazetak);
            }
        }
        private void enkriptirajButton_Click(object sender, EventArgs e)
        {
            if (otvoriDatotekuSadrzaj.Text != "")
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

                    string tajniKljucDatoteka = Directory.GetCurrentDirectory() + @"\tajni_kljuc.txt";

                    if (File.Exists(tajniKljucDatoteka))
                    {
                        File.Delete(tajniKljucDatoteka);
                    }

                    using (StreamWriter sw = File.CreateText(tajniKljucDatoteka))
                    {
                        String kljuc = Convert.ToBase64String(aesKey);
                        sw.WriteLine(kljuc);
                    }

                    byte[] sadrzaj = SimetricniAlgoritam.Enkriptiraj(otvoriDatotekuSadrzaj.Text, aesKey, aesIV);
                    enkriptiraniSadrzaj.Text += Convert.ToBase64String(sadrzaj) + " " + Environment.NewLine;
                    enkriptiraniSadrzaj.Text += "Inicijalizacijski Vektor:";
                    enkriptiraniSadrzaj.Text += Convert.ToBase64String(aesIV);

                    string spremiEnkriptirano = enkriptiraniSadrzaj.Text.ToString();

                    string enkTekstDatoteka = Directory.GetCurrentDirectory() + @"\kriptirani_tekst.txt";

                    if (File.Exists(enkTekstDatoteka))
                    {
                        File.Delete(enkTekstDatoteka);
                    }

                    using (StreamWriter sw = File.CreateText(enkTekstDatoteka))
                    {
                        sw.WriteLine(spremiEnkriptirano);
                    }
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

                    byte[] sadrzaj = AsimetricniAlgoritam.Enkriptiraj(javniKljuc, otvoriDatotekuSadrzaj.Text);
                    enkriptiraniSadrzaj.Text = Convert.ToBase64String(sadrzaj);

                    string spremiEnkriptirano = enkriptiraniSadrzaj.Text.ToString();

                    string enkTekstDatoteka = Directory.GetCurrentDirectory() + @"\kriptirani_tekst.txt";

                    if (File.Exists(enkTekstDatoteka))
                    {
                        File.Delete(enkTekstDatoteka);
                    }

                    using (StreamWriter sw = File.CreateText(enkTekstDatoteka))
                    {
                        sw.WriteLine(spremiEnkriptirano);
                    }
                }
            }
            else
            {
                MessageBox.Show("Niste otvorili datoteku koju želite enkriptirati ili otvorena datoteka ima prazan sadržaj.");
            }

        }

        private void dekriptirajButton_Click(object sender, EventArgs e)
        {
            if (enkriptiraniSadrzaj.Text != "")
            {
                dekriptiraniSadrzaj.Clear();

                if (simetricnoRadio.Checked)
                {
                    string nazivDatoteke = Directory.GetCurrentDirectory() + @"\tajni_kljuc.txt";

                    if (!File.Exists(nazivDatoteke))
                    {
                        MessageBox.Show("Ne postoji datoteka tajni_kljuc.txt!");
                    }
                    else
                    {
                        try
                        {
                            int index = enkriptiraniSadrzaj.Text.IndexOf(":") + 1;
                            string stringAesIV = enkriptiraniSadrzaj.Text.Substring(index);
                            byte[] aesIV = Convert.FromBase64String(stringAesIV);

                            string stringAesKljuc = File.ReadAllText(nazivDatoteke);
                            byte[] aesKljuc = Convert.FromBase64String(stringAesKljuc);

                            string[] cijeliEnkriptiraniTekst = enkriptiraniSadrzaj.Text.Split(' ');
                            byte[] enkriptiraniTekst = Convert.FromBase64String(cijeliEnkriptiraniTekst[0]);

                            dekriptiraniSadrzaj.Text = SimetricniAlgoritam.Dekriptiraj(enkriptiraniTekst, aesKljuc, aesIV);
                        }
                        catch
                        {
                            MessageBox.Show("Navedeni enkriptirani sadržaj nemoguće je dekriptirati.");
                        }

                    }
                }
                else
                {
                    string fileName = Directory.GetCurrentDirectory() + @"\privatni_kljuc.txt";

                    if (!File.Exists(fileName))
                    {
                        MessageBox.Show("Ne postoji datoteka privatni_kljuc.txt!");
                    }
                    else
                    {
                        try
                        {
                            string privatniKljuc = File.ReadAllText(fileName);
                            string enkriptiraniTekst = enkriptiraniSadrzaj.Text;

                            dekriptiraniSadrzaj.Text = AsimetricniAlgoritam.Dekriptiraj(privatniKljuc, enkriptiraniTekst);
                        }
                        catch
                        {
                            MessageBox.Show("Navedeni enkriptirani sadržaj nemoguće je dekriptirati.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Enkriptirani sadržaj je prazan.");
            }
        }

        private void ocistiButton_Click(object sender, EventArgs e)
        {
            enkriptiraniSadrzaj.Text = "";
            dekriptiraniSadrzaj.Text = "";
        }

        private void otvoriKriptiraniTekst_Click(object sender, EventArgs e)
        {
            string sadrzaj = String.Empty;

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.RestoreDirectory = true;
                dialog.Filter = "Text files (*.txt)|*.txt";
                dialog.DefaultExt = "txt";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader reader = new StreamReader(dialog.OpenFile()))
                    {
                        sadrzaj = reader.ReadToEnd();
                    }
                }
            }

            enkriptiraniSadrzaj.Text = sadrzaj;
        }

        private void hashButton_Click(object sender, EventArgs e)
        {
            if (otvoriDatotekuSadrzaj.Text != "")
            {
                string sadrzaj = otvoriDatotekuSadrzaj.Text.ToString();

                byte[] sazetakByte = IzracunSazetka.ComputeSha256Hash(sadrzaj);

                string sazetak = string.Concat(sazetakByte.Select(x => x.ToString("x2")));

                sazetakTextBox.Text = sazetak;
                string sazetakDatoteka = Directory.GetCurrentDirectory() + @"\sazetak_poruke.txt";

                if (File.Exists(sazetakDatoteka))
                {
                    File.Delete(sazetakDatoteka);
                }

                using (StreamWriter sw = File.CreateText(sazetakDatoteka))
                {
                    sw.WriteLine(sazetak);
                }
            }
        }

        private void digitalniPotpisButton_Click(object sender, EventArgs e)
        {
            if (otvoriDatotekuSadrzaj.Text != "")
            {
                string sadrzaj = otvoriDatotekuSadrzaj.Text;
                byte[] digitalniPotpisByte = DigitalniPotpis.GenerirajPotpis(sadrzaj);

                string digitalniPotpis = Convert.ToBase64String(digitalniPotpisByte);
                digitalniPotpisTextBox.Text = digitalniPotpis;

                string digitalniPotpisDatoteka = Directory.GetCurrentDirectory() + @"\digitalni_potpis.txt";

                if (File.Exists(digitalniPotpisDatoteka))
                {
                    File.Delete(digitalniPotpisDatoteka);
                }

                using (StreamWriter sw = File.CreateText(digitalniPotpisDatoteka))
                {
                    sw.WriteLine(digitalniPotpis);
                }
            }
        }

        private void provjeraButton_Click(object sender, EventArgs e)
        {
            if (DigitalniPotpis.VerificirajPotpis(otvoriDatotekuSadrzaj.Text.ToString()))
            {
                MessageBox.Show("Potpis je validan!");
            }
            else
            {
                MessageBox.Show("Potpis nije validan!");
            }
        }
    }
}
