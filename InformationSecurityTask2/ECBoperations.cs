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

        public static void ECBEncryptFromFile(string filePath, string key)
        {
            byte[] data = File.ReadAllBytes(filePath);
            byte[] encryptedData;
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key).ToArray();
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = aes.CreateEncryptor();
                encryptedData = encryptor.TransformFinalBlock(data, 0, data.Length);
            }
            string encryptedtext = Convert.ToBase64String(encryptedData);
            File.WriteAllText("EncryptedText.txt", encryptedtext);
            //   return encryptedData;
        }
        public static void ECBDecryptFromFile(string filePath, string key)
        {
            byte[] encryptedData = File.ReadAllBytes(filePath);
            byte[] decryptedData;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key).ToArray();
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform decryptor = aes.CreateDecryptor();
                decryptedData = decryptor.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
            }
          string decryptedtext =  Convert.ToBase64String(decryptedData);
            File.WriteAllText("DecryptedText.txt", decryptedtext);
            //   return decryptedData;
        }
        public static byte[] ECBEncryptFromInput(string plainText, string key)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedData;

            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.Key = Encoding.UTF8.GetBytes(key).ToArray();
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = aes.CreateEncryptor();
                encryptedData = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
            }
            string encryptedtext = Convert.ToBase64String(encryptedData);
            File.WriteAllText("EncryptedText.txt", encryptedtext);
            return encryptedData;
        }

        public static void ECBDecryptFromInput(byte[] encryptedBytes, string key)
        {
            byte[] decryptedData;
            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.Key = Encoding.UTF8.GetBytes(key).ToArray();
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform decryptor = aes.CreateDecryptor();
                byte[] plainBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                decryptedData = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
            }
            string decryptedtext = Convert.ToBase64String(decryptedData);
            File.WriteAllText("DecryptedText.txt", decryptedtext);
        }
    }
}
