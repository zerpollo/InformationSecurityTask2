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
        public static byte[] Encrypt(string filePath, byte[] key)
        {
            byte[] data = File.ReadAllBytes(filePath);
            byte[] encryptedData;

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = aes.CreateEncryptor();
                encryptedData = encryptor.TransformFinalBlock(data, 0, data.Length);
            }

            return encryptedData;
        }
        public static byte[] Decrypt(string filePath, byte[] key)
        {
            byte[] encryptedData = File.ReadAllBytes(filePath);
            byte[] decryptedData;

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform decryptor = aes.CreateDecryptor();
                decryptedData = decryptor.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
            }

            return decryptedData;
        }
    }
}
