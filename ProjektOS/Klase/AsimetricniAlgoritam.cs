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
            byte[] dataToEncrypt = byteConverter.GetBytes(sadrzaj);

            byte[] encryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.FromXmlString(javniKljuc);
                encryptedData = rsa.Encrypt(dataToEncrypt, false);
            }

            return encryptedData;
        }

        public static string Dekriptiraj(string privatniKljuc, string sadrzaj)
        {
            try
            {
                byte[] dataToDecrypt = Convert.FromBase64String(sadrzaj);

                byte[] decryptedData;
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
                {
                    rsa.FromXmlString(privatniKljuc);
                    decryptedData = rsa.Decrypt(dataToDecrypt, false);
                }

                UnicodeEncoding byteConverter = new UnicodeEncoding();
                return byteConverter.GetString(decryptedData);
            } 
            catch
            {
                System.Windows.Forms.MessageBox.Show("Enkriptirani tekst se ne može dekriptirati označenim algoritmom.");
                return null;
            }
        }
    }
}
