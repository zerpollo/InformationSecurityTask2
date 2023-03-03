using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class CFBoperations
{
    public static void CFBEncryptFromInput(string plainText, string key, byte[] iv)
    {
        byte[] ConvertedBytesFromText = Encoding.UTF8.GetBytes(plainText);
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
                ms.Write(iv, 0, iv.Length);
                cs.Write(ConvertedBytesFromText, 0, ConvertedBytesFromText.Length);
                cs.FlushFinalBlock();
                string encryptedtext = Convert.ToBase64String(ms.ToArray());
                File.WriteAllText("CFBEncryptedText.txt", encryptedtext);
            }
        }
    }

    public static void CFBDecryptFromInput(string EncryptedText, string key, TextBox OriginalTextTB, byte[] iv)
    {

        byte[] ConvertedBytes = Convert.FromBase64String(EncryptedText);
        Array.Copy(ConvertedBytes, iv, 16);

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
                cs.Write(ConvertedBytes, 16, ConvertedBytes.Length - 16);
                cs.FlushFinalBlock();
                string decryptedtext = Convert.ToBase64String(ms.ToArray());
                File.WriteAllText("CFBDecryptedText.txt", decryptedtext);
                OriginalTextTB.Text = Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }
    public static void CFBDecryptFromFile(string filePath, string key, TextBox OriginalTextTB, byte[] iv)
    {

        string EncryptedTextFromFile = File.ReadAllText(filePath);
        byte[] ConvertedBytes = Convert.FromBase64String(EncryptedTextFromFile);
        Array.Copy(ConvertedBytes, iv, 16);

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
                cs.Write(ConvertedBytes, 16, ConvertedBytes.Length - 16);
                cs.FlushFinalBlock();
                string decryptedtext = Convert.ToBase64String(ms.ToArray());
                File.WriteAllText("CFBDecryptedText.txt", decryptedtext);
                OriginalTextTB.Text = Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }

}
