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
        public static void CBCEncryptFromInput(string plainText, string key, byte[] iv)
        {
            byte[] ConvertedBytesFromText = Encoding.UTF8.GetBytes(plainText);

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(iv);
            }

            using (Aes AES = Aes.Create())
            {
                AES.KeySize = 128;
                AES.Key = Encoding.UTF8.GetBytes(key);
                AES.IV = iv;
                AES.Mode = CipherMode.CBC;
                AES.Padding = PaddingMode.PKCS7;

                using (var ms = new MemoryStream())
                using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    ms.Write(iv, 0, iv.Length);

                    cs.Write(ConvertedBytesFromText, 0, ConvertedBytesFromText.Length);
                    cs.FlushFinalBlock();
                    string encryptedtext = Convert.ToBase64String(ms.ToArray());
                    File.WriteAllText("CBCEncryptedText.txt", encryptedtext);
                }
            }
        }
        public static void CBCDecryptionfromInput(string encryptedText, string key, TextBox OriginalTextTB, byte[] iv)
        {
            byte[] ConvertedBytes = Convert.FromBase64String(encryptedText);
            Array.Copy(ConvertedBytes, iv, 16);

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
                    cs.Write(ConvertedBytes, 16, ConvertedBytes.Length - 16);
                    cs.FlushFinalBlock();

                    string decryptedtext = Convert.ToBase64String(ms.ToArray());
                    File.WriteAllText("CBCDecryptedText.txt", decryptedtext);
                    OriginalTextTB.Text = Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }
        public static void CBCDecryptionFromFile(string filePath, string key, TextBox OriginalTextTB, byte[] iv)
        {
            string EncryptedTextFromFile = File.ReadAllText(filePath);
            byte[] ConvertedBytes = Convert.FromBase64String(EncryptedTextFromFile);
            Array.Copy(ConvertedBytes, iv, 16);

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
                    cs.Write(ConvertedBytes, 16, ConvertedBytes.Length - 16);
                    cs.FlushFinalBlock();

                    string decryptedtext = Convert.ToBase64String(ms.ToArray());
                    File.WriteAllText("CBCDecryptedText.txt", decryptedtext);
                    OriginalTextTB.Text = Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }
    }
}

