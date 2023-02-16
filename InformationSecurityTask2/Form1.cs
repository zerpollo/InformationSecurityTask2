namespace InformationSecurityTask2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void EncryptBtn_Click(object sender, EventArgs e)
        {
          //  byte[] key = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
          string key = KeyTB.Text;
         //   string filePath = "data.txt";

            byte[] encryptedData = ECBoperations.ECBEncryptFromInput(PlainTextTB.Text, key);
             ECBoperations.ECBDecryptFromInput(encryptedData, key);
            EncryptedTB.Text = File.ReadAllText("EncryptedText.txt");
            DecryptedTB.Text = File.ReadAllText("DecryptedText.txt");
            
         //   File.WriteAllBytes("decryptedData.txt", decryptedData);
        }
    }
}