using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace InformationSecurityTask2
{
    public partial class Form1 : Form
    {
       private byte[] iv { get; set; }
        public static byte[] GenerateIV()
        {
            byte[] iv = RandomNumberGenerator.GetBytes(16);
            return iv;
        }
        public Form1()
        {
            InitializeComponent();
            iv = GenerateIV();
            label7.Text = Convert.ToBase64String(iv);
        }

        private void EncryptBtn_Click(object sender, EventArgs e)
        {
            //  byte[] key = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            //     string key = KeyTB.Text;
            //   string filePath = "data.txt";

            //   byte[] encryptedData = ECBoperations.ECBEncryptFromInput(PlainTextTB.Text, key);
            //   EncryptedTB.Text = File.ReadAllText("ECBEncryptedText.txt");
            //    ECBoperations.ECBDecryptFromInput(EncryptedTB.Text, key);
            //   DecryptedTB.Text = File.ReadAllText("ECBDecryptedText.txt");

            string key = KeyTB.Text;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    ECBoperations.ECBEncryptFromInput(PlainTextTB.Text, key);
                    EncryptedTB.Text = File.ReadAllText("ECBEncryptedText.txt");
                    break;
                case 1:
                    ECBoperations.ECBDecryptFromFile("ECBEncryptedText.txt", key, OriginalTextTB);
                    DecryptedTB.Text = File.ReadAllText("ECBDecryptedText.txt");
                    break; 
                case 2:
                    ECBoperations.ECBDecryptFromInput(EncryptedTB.Text, key, OriginalTextTB);
                    DecryptedTB.Text = File.ReadAllText("ECBDecryptedText.txt");
                    break;
                case 3:
                    CBCoperations.CBCEncryptFromInput(PlainTextTB.Text, key, iv);
                    EncryptedTB.Text = File.ReadAllText("CBCEncryptedText.txt");
                    break;
                    case 4:
                    CBCoperations.CBCDecryptionFromFile("CBCEncryptedText.txt", key, OriginalTextTB, iv);
                    DecryptedTB.Text = File.ReadAllText("CBCDecryptedText.txt");
                    break; 
                case 5:
                    CBCoperations.CBCDecryptionfromInput(EncryptedTB.Text, key, OriginalTextTB, iv);
                    DecryptedTB.Text = File.ReadAllText("CBCDecryptedText.txt");
                    break;
                    case 6:
                    CFBoperations.CFBEncryptFromInput(PlainTextTB.Text, key, iv);
                    EncryptedTB.Text = File.ReadAllText("CFBEncryptedText.txt");
                    break;
                    case 7:
                    CFBoperations.CFBDecryptFromInput(EncryptedTB.Text, key, OriginalTextTB, iv);
                    DecryptedTB.Text = File.ReadAllText("CFBDecryptedText.txt");
                    break; 
                case 8:
                    CFBoperations.CFBDecryptFromFile("CFBEncryptedText.txt", key, OriginalTextTB, iv);
                    DecryptedTB.Text = File.ReadAllText("CFBDecryptedText.txt");
                    break;
            }
        }
    }
}