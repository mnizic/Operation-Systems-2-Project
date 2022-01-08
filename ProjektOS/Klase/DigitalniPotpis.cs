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
            byte[] signedHashValue = null;

            if (File.Exists(privatniKljucDatoteka))
            {
                byte[] sazetak = IzracunSazetka.ComputeSha256Hash(sadrzaj);
                string privatniKljuc = File.ReadAllText(privatniKljucDatoteka);

                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(privatniKljuc);

                    RSAPKCS1SignatureFormatter rsaFormatter = new RSAPKCS1SignatureFormatter(rsa);
                    rsaFormatter.SetHashAlgorithm("SHA256");
                    signedHashValue = rsaFormatter.CreateSignature(sazetak);
                }
            }
            

            return signedHashValue;
        } 

        public static bool VerificirajPotpis(string sadrzaj)
        {
            bool potpisValidan = false;

            string javniKljuc, sazetak, digitalniPotpis;

            string javniKljucDatoteka = Directory.GetCurrentDirectory() + @"\javni_kljuc.txt";
            if (File.Exists(javniKljucDatoteka))
            {
                javniKljuc = File.ReadAllText(javniKljucDatoteka);
            } else
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
            
            byte[] sazetakByte = IzracunSazetka.ComputeSha256Hash(sadrzaj);
            string sazetakProvjera = string.Concat(sazetakByte.Select(x => x.ToString("x2")));

            if(sazetakProvjera != sazetak)
            {
                return potpisValidan;
            }

            try
            {
                byte[] digitalniPotpisByte = Convert.FromBase64String(digitalniPotpis);
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
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
