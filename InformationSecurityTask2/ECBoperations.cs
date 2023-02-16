using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InformationSecurityTask2
{
    public class ECBoperations
    {

        public static byte[] ECBEncryptFromFile(string filePath, string key)
        {
            byte[] data = File.ReadAllBytes(filePath);
            byte[] encryptedData;
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key).Take(32).ToArray();
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = aes.CreateEncryptor();
                encryptedData = encryptor.TransformFinalBlock(data, 0, data.Length);
            }

            return encryptedData;
        }
        public static byte[] ECBDecryptFromFile(string filePath, string key)
        {
            byte[] encryptedData = File.ReadAllBytes(filePath);
            byte[] decryptedData;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key).Take(32).ToArray();
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform decryptor = aes.CreateDecryptor();
                decryptedData = decryptor.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
            }

            return decryptedData;
        }
        public static byte[] ECBEncryptFromInput(string plainText, string key)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedBytes;
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key).Take(32).ToArray();
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = aes.CreateEncryptor();
                encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
            }

            return encryptedBytes;
        }

        public static string ECBDecryptFromInput(byte[] encryptedBytes, string key)
        {
            string plainText;
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key).Take(32).ToArray();
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform decryptor = aes.CreateDecryptor();
                byte[] plainBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                plainText = Encoding.UTF8.GetString(plainBytes);
            }

            return plainText;
        }
    }
}
