using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace ProjektOS.Klase
{
    public class DigitalniPotpis
    {
        public static byte[] GenerirajPotpis(string sadrzaj)
        {
            string privatniKljucDatoteka = Directory.GetCurrentDirectory() + @"\privatni_kljuc.txt";
            byte[] potpisaniSazetak = null;

            if (File.Exists(privatniKljucDatoteka))
            {
                byte[] sazetak = IzracunSazetka.ComputeSha256Hash(sadrzaj);
                string privatniKljuc = File.ReadAllText(privatniKljucDatoteka);

                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
                {
                    try
                    {
                        rsa.FromXmlString(privatniKljuc);

                        RSAPKCS1SignatureFormatter rsaFormatter = new RSAPKCS1SignatureFormatter(rsa);
                        rsaFormatter.SetHashAlgorithm("SHA256");
                        potpisaniSazetak = rsaFormatter.CreateSignature(sazetak);
                    }
                    catch
                    {
                        System.Windows.Forms.MessageBox.Show("Privatni ključ neispravan!");
                        return null;
                    }
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Ne postoji datoteka privatni_kljuc.txt");
                return null;
            }
           
            return potpisaniSazetak;
        } 

        public static bool VerificirajPotpis()
        {
            bool potpisValidan = false;

            string javniKljuc, sazetak, digitalniPotpis;

            string javniKljucDatoteka = Directory.GetCurrentDirectory() + @"\javni_kljuc.txt";
            if (File.Exists(javniKljucDatoteka))
            {
                javniKljuc = File.ReadAllText(javniKljucDatoteka);
            } 
            else
            {
                return potpisValidan;
            }

            string sazetakDatoteka = Directory.GetCurrentDirectory() + @"\sazetak_poruke.txt";
            if (File.Exists(sazetakDatoteka))
            {
                sazetak = File.ReadAllText(sazetakDatoteka).Replace("\r\n", "");
            }
            else
            {
                return potpisValidan;
            }

            string digitalniPotpisDatoteka = Directory.GetCurrentDirectory() + @"\digitalni_potpis.txt";
            if (File.Exists(sazetakDatoteka))
            {
                digitalniPotpis = File.ReadAllText(digitalniPotpisDatoteka).Replace("\r\n", "");
            }
            else
            {
                return potpisValidan;
            }

            try
            {
                byte[] sazetakByte = Convert.FromBase64String(sazetak);
                byte[] digitalniPotpisByte = Convert.FromBase64String(digitalniPotpis);

                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
                {
                    rsa.FromXmlString(javniKljuc);

                    RSAPKCS1SignatureDeformatter rsaDeformatter = new RSAPKCS1SignatureDeformatter(rsa);
                    rsaDeformatter.SetHashAlgorithm("SHA256");
                    potpisValidan = rsaDeformatter.VerifySignature(sazetakByte, digitalniPotpisByte);
                }
                return potpisValidan;
            }
            catch
            {
                return potpisValidan;
            }
        }
    }
}