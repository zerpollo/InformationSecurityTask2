using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace InformationSecurityTask2
{
    public class CBCoperations
    {
        public static byte[] CBCEncryptFromInput(string plainText, string key)
        {
            // Convert the plaintext and key to byte arrays
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText).ToArray();

            // Generate a random initialization vector
            byte[] iv = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(iv);
            }

            // Encrypt the plaintext using AES in CBC mode
            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.Key = Encoding.UTF8.GetBytes(key).ToArray();
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (var ms = new MemoryStream())
                using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    // Write the IV to the output stream
                    ms.Write(iv, 0, iv.Length);

                    // Write the encrypted plaintext to the output stream
                    cs.Write(plainBytes, 0, plainBytes.Length);
                    cs.FlushFinalBlock();
                    string decryptedtext = Convert.ToBase64String(ms.ToArray());
                    File.WriteAllText("CBCEncrypted.txt", decryptedtext);
                    return ms.ToArray();
                }
            }

        }
    }
}