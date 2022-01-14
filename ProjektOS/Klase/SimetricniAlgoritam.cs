using System;
using System.IO;
using System.Security.Cryptography;

namespace ProjektOS.Klase
{
    public class SimetricniAlgoritam
    {
        public static byte[] Enkriptiraj(string sadrzaj, byte[] aesKljuc, byte[] aesIV)
        {
            byte[] enkriptiraniSadrzaj;

            using (Aes aes = Aes.Create())
            {
                aes.Key = aesKljuc;
                aes.IV = aesIV;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(sadrzaj);
                        }
                        enkriptiraniSadrzaj = msEncrypt.ToArray();
                    }
                }
            }

            return enkriptiraniSadrzaj;
        }

        public static string Dekriptiraj(byte[] enkriptiraniSadrzaj, byte[] aesKljuc, byte[] aesIV)
        {
            string sadrzaj = null;
            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = aesKljuc;
                    aes.IV = aesIV;

                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    using (MemoryStream msDecrypt = new MemoryStream(enkriptiraniSadrzaj))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                sadrzaj = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            } 
            catch
            {
                System.Windows.Forms.MessageBox.Show("Enkriptirani tekst se ne može dekriptirati označenim algoritmom.");
            }
                
            return sadrzaj;
        }
    }
}
