using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjektOS.Klase
{
    public class AsimetricniAlgoritam
    {
        public static byte[] Enkriptiraj(string javniKljuc, string sadrzaj)
        {
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            byte[] sadrzajByte = byteConverter.GetBytes(sadrzaj);

            byte[] enkriptiraniSadrzaj;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.FromXmlString(javniKljuc);
                enkriptiraniSadrzaj = rsa.Encrypt(sadrzajByte, false);
            }

            return enkriptiraniSadrzaj;
        }

        public static string Dekriptiraj(string privatniKljuc, string sadrzaj)
        {
            try
            {
                byte[] sadrzajByte = Convert.FromBase64String(sadrzaj);

                byte[] dekriptiraniSadrzaj;
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
                {
                    rsa.FromXmlString(privatniKljuc);
                    dekriptiraniSadrzaj = rsa.Decrypt(sadrzajByte, false);
                }

                UnicodeEncoding byteConverter = new UnicodeEncoding();
                return byteConverter.GetString(dekriptiraniSadrzaj);
            } 
            catch
            {
                System.Windows.Forms.MessageBox.Show("Enkriptirani tekst se ne može dekriptirati označenim algoritmom.");
                return null;
            }
        }
    }
}
