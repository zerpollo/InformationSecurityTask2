using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class CFBoperations
{
    public static void CFBEncryptFromInput(string plainText, string key)
    {
        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
        byte[] encryptedData;
        byte[] iv = new byte[16];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(iv);
        }

        using (var aes = Aes.Create())
        {
            aes.KeySize = 128;
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;
            aes.Mode = CipherMode.CFB;
            aes.Padding = PaddingMode.PKCS7;

            using (var ms = new MemoryStream())
            using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                // Write the IV to the output stream
                ms.Write(iv, 0, iv.Length);

                // Write the encrypted plaintext to the output stream
                
                cs.Write(plainBytes, 0, plainBytes.Length);
                cs.FlushFinalBlock();
                encryptedData = ms.ToArray();
                string encryptedtext = Convert.ToBase64String(ms.ToArray());
                File.WriteAllText("CFBEncryptedText.txt", encryptedtext);
            }
        }
    }

    public static void CFBDecryptFromInput(string encryptedText, string key, TextBox OriginalTextTB)
    {

        byte[] encryptedData = Convert.FromBase64String(encryptedText);
        byte[] iv = new byte[16];
        Array.Copy(encryptedData, iv, 16);

        using (var aes = Aes.Create())
        {
            aes.KeySize = 128;
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;
            aes.Mode = CipherMode.CFB;
            aes.Padding = PaddingMode.PKCS7;

            using (var ms = new MemoryStream())
            using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
            {
                // Write the padded data to the output stream (excluding the IV)
                cs.Write(encryptedData, 16, encryptedData.Length - 16);
                cs.FlushFinalBlock();

                // Convert the decrypted data to a string
                string decryptedtext = Convert.ToBase64String(ms.ToArray());
                File.WriteAllText("CFBDecryptedText.txt", decryptedtext);
                OriginalTextTB.Text = Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }
}
