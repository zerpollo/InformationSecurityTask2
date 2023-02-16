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
            string filePath = "data.txt";

            byte[] encryptedData = ECBoperations.EncryptFromFile(filePath, key);
            File.WriteAllBytes("encryptedData.txt", encryptedData);

            byte[] decryptedData = ECBoperations.DecryptFromFile("encryptedData.txt", key);
            File.WriteAllBytes("decryptedData.txt", decryptedData);
        }
    }
}