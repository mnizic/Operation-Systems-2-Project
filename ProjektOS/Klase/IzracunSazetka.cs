using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjektOS.Klase
{
    public class IzracunSazetka
    {
        public static byte[] ComputeSha256Hash(string sadrzaj)
        {
            byte[] sazetak = null;

            using (SHA256 sha256 = SHA256.Create())
            {
                sazetak = sha256.ComputeHash(Encoding.UTF8.GetBytes(sadrzaj));
            }

            return sazetak;
        }
    }
}
