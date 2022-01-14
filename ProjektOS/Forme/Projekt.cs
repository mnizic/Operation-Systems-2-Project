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
            provjeraLabel.Visible = false;
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

            if(!String.IsNullOrEmpty(sadrzaj))
            {
                obicanTekstSadrzaj.Text = sadrzaj;

                byte[] sazetakByte = IzracunSazetka.ComputeSha256Hash(sadrzaj);
                string sazetak = Convert.ToBase64String(sazetakByte);

                sazetakTextBox.Text = sazetak;
                string sazetakDatoteka = Directory.GetCurrentDirectory() + @"\sazetak_poruke.txt";


                if (File.Exists(sazetakDatoteka))
                {
                    File.Delete(sazetakDatoteka);
                }

                File.WriteAllText(sazetakDatoteka, sazetak);
            } 
        }

        private void enkriptirajButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(obicanTekstSadrzaj.Text))
            {
                enkriptiraniSadrzaj.Clear();

                if (simetricnoRadio.Checked)
                {
                    byte[] aesTajniKljuc, aesIV;
                    using (Aes aes = Aes.Create())
                    {
                        aes.KeySize = 256;
                        aes.GenerateIV();
                        aes.GenerateKey();

                        aesIV = aes.IV;
                        aesTajniKljuc = aes.Key;
                    }

                    string tajniKljucDatoteka = Directory.GetCurrentDirectory() + @"\tajni_kljuc.txt";
                    if (File.Exists(tajniKljucDatoteka))
                    {
                        File.Delete(tajniKljucDatoteka);
                    }

                    String kljuc = Convert.ToBase64String(aesTajniKljuc);
                    File.WriteAllText(tajniKljucDatoteka, kljuc);

                    byte[] sadrzaj = SimetricniAlgoritam.Enkriptiraj(obicanTekstSadrzaj.Text, aesTajniKljuc, aesIV);
                    enkriptiraniSadrzaj.Text += Convert.ToBase64String(sadrzaj) + " " + Environment.NewLine;
                    enkriptiraniSadrzaj.Text += "Inicijalizacijski Vektor:";
                    enkriptiraniSadrzaj.Text += Convert.ToBase64String(aesIV);

                    string spremiEnkriptirano = enkriptiraniSadrzaj.Text.ToString();

                    string enkTekstDatoteka = Directory.GetCurrentDirectory() + @"\kriptirani_tekst.txt";
                    if (File.Exists(enkTekstDatoteka))
                    {
                        File.Delete(enkTekstDatoteka);
                    }

                    File.WriteAllText(enkTekstDatoteka, spremiEnkriptirano);
                }
                else
                {
                    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);

                    string javniKljucDatoteka = Directory.GetCurrentDirectory() + @"\javni_kljuc.txt";
                    if (File.Exists(javniKljucDatoteka))
                    {
                        File.Delete(javniKljucDatoteka);
                    }

                    string privatniKljucDatoteka = Directory.GetCurrentDirectory() + @"\privatni_kljuc.txt";
                    if (File.Exists(privatniKljucDatoteka))
                    {
                        File.Delete(privatniKljucDatoteka);
                    }

                    string enkTekstDatoteka = Directory.GetCurrentDirectory() + @"\kriptirani_tekst.txt";
                    if (File.Exists(enkTekstDatoteka))
                    {
                        File.Delete(enkTekstDatoteka);
                    }


                    string javniKljuc = rsa.ToXmlString(false);
                    File.WriteAllText(javniKljucDatoteka, javniKljuc);

                    string privatniKljuc = rsa.ToXmlString(true);
                    File.WriteAllText(privatniKljucDatoteka, privatniKljuc);

                    byte[] sadrzaj = AsimetricniAlgoritam.Enkriptiraj(javniKljuc, obicanTekstSadrzaj.Text);
                    if (sadrzaj != null)
                    {
                        enkriptiraniSadrzaj.Text = Convert.ToBase64String(sadrzaj);
                        string spremiEnkriptirano = enkriptiraniSadrzaj.Text.ToString();
                        File.WriteAllText(enkTekstDatoteka, spremiEnkriptirano);
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
            if (!String.IsNullOrEmpty(enkriptiraniSadrzaj.Text))
            {
                obicanTekstSadrzaj.Clear();

                if (simetricnoRadio.Checked)
                {
                    string tajniKljucDatoteka = Directory.GetCurrentDirectory() + @"\tajni_kljuc.txt";

                    if (!File.Exists(tajniKljucDatoteka))
                    {
                        MessageBox.Show("Ne postoji datoteka tajni_kljuc.txt!");
                    }
                    else
                    {
                        try
                        {
                            int indeks = enkriptiraniSadrzaj.Text.IndexOf(":") + 1;
                            string stringAesIV = enkriptiraniSadrzaj.Text.Substring(indeks);
                            byte[] aesIV = Convert.FromBase64String(stringAesIV);

                            string stringAesKljuc = File.ReadAllText(tajniKljucDatoteka);
                            byte[] aesKljuc = Convert.FromBase64String(stringAesKljuc);

                            string[] cijeliEnkriptiraniTekst = enkriptiraniSadrzaj.Text.Split(' ');
                            byte[] enkriptiraniTekst = Convert.FromBase64String(cijeliEnkriptiraniTekst[0]);

                            obicanTekstSadrzaj.Text = SimetricniAlgoritam.Dekriptiraj(enkriptiraniTekst, aesKljuc, aesIV);

                            if(!String.IsNullOrEmpty(obicanTekstSadrzaj.Text))
                            {
                                byte[] sazetakByte = IzracunSazetka.ComputeSha256Hash(obicanTekstSadrzaj.Text);
                                string sazetak = Convert.ToBase64String(sazetakByte);
                                sazetakTextBox.Text = sazetak;

                                string sazetakDatoteka = Directory.GetCurrentDirectory() + @"\sazetak_poruke.txt";
                                if (File.Exists(sazetakDatoteka))
                                {
                                    File.Delete(sazetakDatoteka);
                                }

                                File.WriteAllText(sazetakDatoteka, sazetak);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Navedeni enkriptirani sadržaj nemoguće je dekriptirati.");
                            sazetakTextBox.Clear();
                        }

                    }
                }
                else
                {
                    string privatniKljucDatoteka = Directory.GetCurrentDirectory() + @"\privatni_kljuc.txt";

                    if (!File.Exists(privatniKljucDatoteka))
                    {
                        MessageBox.Show("Ne postoji datoteka privatni_kljuc.txt!");
                    }
                    else
                    {
                        try
                        {
                            string privatniKljuc = File.ReadAllText(privatniKljucDatoteka);
                            string enkriptiraniTekst = enkriptiraniSadrzaj.Text;

                            obicanTekstSadrzaj.Text = AsimetricniAlgoritam.Dekriptiraj(privatniKljuc, enkriptiraniTekst);

                            if (!String.IsNullOrEmpty(obicanTekstSadrzaj.Text))
                            {
                                byte[] sazetakByte = IzracunSazetka.ComputeSha256Hash(obicanTekstSadrzaj.Text);

                                string sazetak = Convert.ToBase64String(sazetakByte);

                                sazetakTextBox.Text = sazetak;
                                string sazetakDatoteka = Directory.GetCurrentDirectory() + @"\sazetak_poruke.txt";

                                if (File.Exists(sazetakDatoteka))
                                {
                                    File.Delete(sazetakDatoteka);
                                }

                                File.WriteAllText(sazetakDatoteka, sazetak);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Navedeni enkriptirani sadržaj nemoguće je dekriptirati.");
                            sazetakTextBox.Clear();
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
            enkriptiraniSadrzaj.Clear();
            obicanTekstSadrzaj.Clear();
            sazetakTextBox.Clear();
            digitalniPotpisTextBox.Clear();
            provjeraLabel.Visible = false;
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

        private void digitalniPotpisButton_Click(object sender, EventArgs e)
        {
            string privatniKljucDatoteka = Directory.GetCurrentDirectory() + @"\privatni_kljuc.txt";

            if (!String.IsNullOrEmpty(obicanTekstSadrzaj.Text) && !String.IsNullOrEmpty(sazetakTextBox.Text) && File.Exists(privatniKljucDatoteka))
            {
                string sadrzaj = obicanTekstSadrzaj.Text;
                byte[] digitalniPotpisByte = DigitalniPotpis.GenerirajPotpis(sadrzaj);

                string digitalniPotpis = Convert.ToBase64String(digitalniPotpisByte);
                digitalniPotpisTextBox.Text = digitalniPotpis;

                string digitalniPotpisDatoteka = Directory.GetCurrentDirectory() + @"\digitalni_potpis.txt";

                if (File.Exists(digitalniPotpisDatoteka))
                {
                    File.Delete(digitalniPotpisDatoteka);
                }

                File.WriteAllText(digitalniPotpisDatoteka, digitalniPotpis);
            }
            else
            {
                MessageBox.Show("Običan tekst i sažetak su prazni ili privatni_kljuc.txt ne postoji.");
            }
        }

        private void provjeraButton_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(digitalniPotpisTextBox.Text))
            {
                if (DigitalniPotpis.VerificirajPotpis())
                {                    
                    provjeraLabel.Text = "Digitalni potpis je validan!";
                    provjeraLabel.Visible = true;
                    provjeraLabel.ForeColor = Color.ForestGreen;
                    MessageBox.Show("Digitalni potpis je validan!");
                }
                else
                {                 
                    provjeraLabel.Text = "Digitalni potpis nije validan!";
                    provjeraLabel.Visible = true;
                    provjeraLabel.ForeColor = Color.Red;
                    MessageBox.Show("Digitalni potpis nije validan!");
                }
            }
            else
            {
                MessageBox.Show("Digitalni potpis je prazan.");
            }
        }
    }
}