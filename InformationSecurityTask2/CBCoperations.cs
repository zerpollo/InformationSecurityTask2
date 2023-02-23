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
        public static void CBCEncryptFromInput(string plainText, string key)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] iv = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(iv);
            }

            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 128;
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (var ms = new MemoryStream())
                using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    ms.Write(iv, 0, iv.Length);

                    cs.Write(plainBytes, 0, plainBytes.Length);
                    cs.FlushFinalBlock();
                    string encryptedtext = Convert.ToBase64String(ms.ToArray());
                    File.WriteAllText("CBCEncryptedText.txt", encryptedtext);
                }
            }
        }
        public static void CBCDecryptionfromInput(string encryptedText, string key, TextBox OriginalTextTB)
        {
            byte[] encryptedData = Convert.FromBase64String(encryptedText);
            byte[] iv = new byte[16];
            Array.Copy(encryptedData, iv, 16);

            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 128;
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (var ms = new MemoryStream())
                using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(encryptedData, 16, encryptedData.Length - 16);
                    cs.FlushFinalBlock();

                    string decryptedtext = Convert.ToBase64String(ms.ToArray());
                    File.WriteAllText("CBCDecryptedText.txt", decryptedtext);
                    OriginalTextTB.Text = Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }
        public static void CBCDecryptionFromFile(string filePath, string key, TextBox OriginalTextTB)
        {
            string encryptedData = File.ReadAllText(filePath);
            byte[] encryptedBytes = Convert.FromBase64String(encryptedData);
            byte[] iv = new byte[16];
            Array.Copy(encryptedBytes, iv, 16);

            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 128;
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (var ms = new MemoryStream())
                using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(encryptedBytes, 16, encryptedBytes.Length - 16);
                    cs.FlushFinalBlock();

                    string decryptedtext = Convert.ToBase64String(ms.ToArray());
                    File.WriteAllText("CBCDecryptedText.txt", decryptedtext);
                    OriginalTextTB.Text = Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }
    }
}

