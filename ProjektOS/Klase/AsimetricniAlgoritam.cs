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
        public static byte[] EncryptText(string publicKey, string text)
        {
            // Convert the text to an array of bytes   
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = byteConverter.GetBytes(text);

            // Create a byte array to store the encrypted data in it   
            byte[] encryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Set the rsa pulic key   
                rsa.FromXmlString(publicKey);

                // Encrypt the data and store it in the encyptedData Array   
                encryptedData = rsa.Encrypt(dataToEncrypt, false);
            }

            // Save the encypted data array into a file   
            return encryptedData;
        }

        public static string DecryptData(string privateKey, string text)
        {
            try
            {
                // read the encrypted bytes from the file   
                byte[] dataToDecrypt = Convert.FromBase64String(text);

                // Create an array to store the decrypted data in it   
                byte[] decryptedData;
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    // Set the private key of the algorithm   
                    rsa.FromXmlString(privateKey);
                    decryptedData = rsa.Decrypt(dataToDecrypt, false);
                }

                // Get the string value from the decryptedData byte array   
                UnicodeEncoding byteConverter = new UnicodeEncoding();
                return byteConverter.GetString(decryptedData);
            } 
            catch
            {
                System.Windows.Forms.MessageBox.Show("Krivi algoritam.");
                return null;
            }
        }
    }
}
