using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace InformationSecurityTask2
{
    public class ECBoperations
    {
        public static void ECBEncryptFromInput(string plainText, string key)
        {
            byte[] ConvertedBytesFromText = Encoding.UTF8.GetBytes(plainText).ToArray();
            byte[] EncryptedBytes;

            using (Aes AES = Aes.Create())
            {
                AES.KeySize = 128;
                AES.Key = Encoding.UTF8.GetBytes(key).ToArray();
                AES.Mode = CipherMode.ECB;
                AES.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = AES.CreateEncryptor();
                EncryptedBytes = encryptor.TransformFinalBlock(ConvertedBytesFromText, 0, ConvertedBytesFromText.Length);
            }
            string encryptedtext = Convert.ToBase64String(EncryptedBytes);
            File.WriteAllText("ECBEncryptedText.txt", encryptedtext);
        }

        public static void ECBDecryptFromFile(string filePath, string key, TextBox OriginalTextTB)
        {
            string EncryptedTextFromFile = File.ReadAllText(filePath);
           byte[] ConvertedBytes = Convert.FromBase64String(EncryptedTextFromFile);
            byte[] DecryptedData;

            using (Aes AES = Aes.Create())
            {
                AES.KeySize = 128;
                AES.Key = Encoding.UTF8.GetBytes(key).ToArray();
                AES.Mode = CipherMode.ECB;
                AES.Padding = PaddingMode.PKCS7;

                ICryptoTransform decryptor = AES.CreateDecryptor();
                DecryptedData = decryptor.TransformFinalBlock(ConvertedBytes, 0, ConvertedBytes.Length);
            }
            string decryptedtext = Convert.ToBase64String(DecryptedData);
            File.WriteAllText("ECBDecryptedText.txt", decryptedtext);
            OriginalTextTB.Text = Encoding.UTF8.GetString(DecryptedData);
        }
        
        public static void ECBDecryptFromInput(string EncryptedText, string key, TextBox OriginalTextTB)
        {
            byte[] ConvertedBytes = Convert.FromBase64String(EncryptedText);
            byte[] DecryptedData;
            using (Aes AES = Aes.Create())
            {
                AES.KeySize = 128;
                AES.Key = Encoding.UTF8.GetBytes(key).ToArray();
                AES.Mode = CipherMode.ECB;
                AES.Padding = PaddingMode.PKCS7;

                ICryptoTransform decryptor = AES.CreateDecryptor();
                DecryptedData = decryptor.TransformFinalBlock(ConvertedBytes, 0, ConvertedBytes.Length);
                string decryptedtext = Convert.ToBase64String(DecryptedData);
                File.WriteAllText("ECBDecryptedText.txt", decryptedtext);
                OriginalTextTB.Text = Encoding.UTF8.GetString(DecryptedData);
            }
            
        }
    }
}
