using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DotNetLab3._1
{
    public partial class Form1 : Form
    {
        private Form active;
        public Form1()
        {
            InitializeComponent();
            render_false();
        }

        private void open_Click(object sender, EventArgs e)
        {
            render_false();
            progressBar1.Value = 0;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog.Title = "Выберите файл";
            openFileDialog.InitialDirectory = "C:\\";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                string key = KeyInput.Text;
                try
                {
                    string content = File.ReadAllText(selectedFilePath);
                    string encryptedContent = Encrypt(content, key);
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        File.WriteAllText(filePath, encryptedContent);
                        progressBar1.Visible = true;
                        progressBar1.Value = 100;
                        from_info_label.Visible = true;
                        from_info_label.Text = selectedFilePath;
                        to_info_label.Visible = true;
                        to_info_label.Text = filePath;
                        from_label.Visible = true;
                        To_label.Visible = true;

                        FileInfo fileInfo = new FileInfo(filePath);
                        long fileSizeInBytes = fileInfo.Length;
                        size_label.Visible = true;
                        size_inf_label.Visible = true;
                        size_inf_label.Text = fileSizeInBytes.ToString() + " Bt";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                }



                static string Encrypt(string input, string key)
                {
                    using (Aes aesAlg = Aes.Create())
                    {
                        aesAlg.Key = Encoding.UTF8.GetBytes(key.PadRight(16, ' ')).Take(16).ToArray();
                        aesAlg.IV = new byte[16];
                        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                        using (MemoryStream msEncrypt = new MemoryStream())
                        {
                            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                            {
                                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                                {
                                    swEncrypt.Write(input);
                                }
                            }
                            return Convert.ToBase64String(msEncrypt.ToArray());
                        }
                    }
                }

            }
        }

        private void render_false()
        {
            size_inf_label.Visible = false;
            size_label.Visible = false;
            from_info_label.Visible = false;
            to_info_label.Visible = false;
            from_label.Visible = false;
            To_label.Visible = false;
            progressBar1.Visible = false;
            progressBar1.Value = 0;
        }

        private void descript_file_btn_Click(object sender, EventArgs e)
        {
            render_false();
            progressBar1.Value = 0;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog.Title = "Выберите файл для дешифрования";
            openFileDialog.InitialDirectory = "C:\\";

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;

                string key = KeyInput.Text;

                try
                {
                    string content = File.ReadAllText(selectedFilePath);

                    string decryptedContent = Decrypt(content, key);

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        File.WriteAllText(filePath, decryptedContent);
                        progressBar1.Value = 100;

                        FileInfo fileInfo = new FileInfo(filePath);
                        long fileSizeInBytes = fileInfo.Length;



                        from_info_label.Visible = true;
                        progressBar1.Visible = true;
                        from_info_label.Text = selectedFilePath;
                        to_info_label.Visible = true;
                        to_info_label.Text = filePath;
                        from_label.Visible = true;
                        To_label.Visible = true;
                        size_label.Visible = true;
                        size_inf_label.Visible = true;
                        size_inf_label.Text = fileSizeInBytes.ToString() + " Bt";
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                }
            }
        }

        static string Decrypt(string input, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key.PadRight(16, ' ')).Take(16).ToArray();
                aesAlg.IV = new byte[16];

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(input)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        private void type_key_label_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void KeyInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}