namespace InformationSecurityTask2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PlainTextTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.KeyTB = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.EncryptBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.EncryptedTB = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.DecryptedTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.OriginalTextTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PlainTextTB
            // 
            this.PlainTextTB.Location = new System.Drawing.Point(98, 33);
            this.PlainTextTB.Name = "PlainTextTB";
            this.PlainTextTB.Size = new System.Drawing.Size(343, 23);
            this.PlainTextTB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Plain text:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Secret key:";
            // 
            // KeyTB
            // 
            this.KeyTB.Location = new System.Drawing.Point(98, 62);
            this.KeyTB.Name = "KeyTB";
            this.KeyTB.Size = new System.Drawing.Size(343, 23);
            this.KeyTB.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(258, 289);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 4;
            // 
            // EncryptBtn
            // 
            this.EncryptBtn.Location = new System.Drawing.Point(12, 281);
            this.EncryptBtn.Name = "EncryptBtn";
            this.EncryptBtn.Size = new System.Drawing.Size(117, 36);
            this.EncryptBtn.TabIndex = 5;
            this.EncryptBtn.Text = "Encrypt from txt";
            this.EncryptBtn.UseVisualStyleBackColor = true;
            this.EncryptBtn.Click += new System.EventHandler(this.EncryptBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(135, 281);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 36);
            this.button2.TabIndex = 6;
            this.button2.Text = "Decrypt from txt";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Encrypted text:";
            // 
            // EncryptedTB
            // 
            this.EncryptedTB.Location = new System.Drawing.Point(98, 91);
            this.EncryptedTB.Name = "EncryptedTB";
            this.EncryptedTB.Size = new System.Drawing.Size(343, 23);
            this.EncryptedTB.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 36);
            this.button1.TabIndex = 9;
            this.button1.Text = "Encrypt from input";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(135, 239);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 36);
            this.button3.TabIndex = 10;
            this.button3.Text = "Decrypt from input";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Decrypted text:";
            // 
            // DecryptedTB
            // 
            this.DecryptedTB.Location = new System.Drawing.Point(98, 120);
            this.DecryptedTB.Name = "DecryptedTB";
            this.DecryptedTB.Size = new System.Drawing.Size(343, 23);
            this.DecryptedTB.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Original text:";
            // 
            // OriginalTextTB
            // 
            this.OriginalTextTB.Location = new System.Drawing.Point(98, 149);
            this.OriginalTextTB.Name = "OriginalTextTB";
            this.OriginalTextTB.Size = new System.Drawing.Size(343, 23);
            this.OriginalTextTB.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 324);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.OriginalTextTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DecryptedTB);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EncryptedTB);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.EncryptBtn);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.KeyTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PlainTextTB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox PlainTextTB;
        private Label label1;
        private Label label2;
        private TextBox KeyTB;
        private ComboBox comboBox1;
        private Button EncryptBtn;
        private Button button2;
        private Label label3;
        private TextBox EncryptedTB;
        private Button button1;
        private Button button3;
        private Label label4;
        private TextBox DecryptedTB;
        private Label label5;
        private TextBox OriginalTextTB;
    }
}