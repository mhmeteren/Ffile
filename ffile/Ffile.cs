using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace ffile
{
    public partial class Ffile : Form
    {
        public Ffile()
        {
            InitializeComponent();
        }

        TimeSpan TRANSACTION_START_TIME;
        TimeSpan TRANSACTION_END_TIME;
        string TRANSACTION_STATUS = "Failed";
        int CURRENT_ROUND;



        private void Ffile_Load(object sender, EventArgs e)
        {
            ToolTip formToolTip = new ToolTip()
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500,
                ShowAlways = true
            };

            formToolTip.SetToolTip(FileList, "Processed file list.");
            formToolTip.SetToolTip(EncryptRounds, $"Count of encryption. Min: {EncryptRounds.Minimum}, Max: {EncryptRounds.Maximum}, Default: {EncryptRounds.Value}");
            formToolTip.SetToolTip(TransactionStatusLabel, "Transaction status.");
            formToolTip.SetToolTip(FilePanel, "Upload Panel. Click me or Drag and Drop Files.");
            formToolTip.SetToolTip(ControlModeCheckBox, "Permission required for every action when Control mode is active.");
        }


        #region File Upload Events
        private void FilePanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }


        private void FilePanel_DragDrop(object sender, DragEventArgs e)
        {
            StartDestroyProcedures((string[])e.Data.GetData(DataFormats.FileDrop));
        }


        private void FilePanel_Click(object sender, EventArgs e)
        {
            if (HomePageFileDialog.ShowDialog() == DialogResult.OK)
            {
                StartDestroyProcedures(HomePageFileDialog.FileNames);
            }
        }
        #endregion



        #region File Destroy Functions
        public void StartDestroyProcedures(string[] files)
        {
            if (ControlModeCheckBox.Checked)
            {
                var answer = MessageBox.Show("Are you serious? well", ">_", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (answer == DialogResult.No)
                {
                    return;
                }
            }

            ClearForm();
        
            TRANSACTION_START_TIME = DateTime.Now.TimeOfDay;
            TransactionStatusLabel.Text = "here we go ...";


            try
            {
                int rounds = (int)EncryptRounds.Value;
                for (CURRENT_ROUND = 1; CURRENT_ROUND <= rounds; CURRENT_ROUND++)
                {
                    StartSubDestroyProcedure(files);
                }

                TransactionStatusLabel.Text = "Deleting ..";
                DeleteFiles(files);

                TRANSACTION_END_TIME = DateTime.Now.TimeOfDay;
                TransactionStatusLabel.ForeColor = Color.Green;
                TRANSACTION_STATUS = "Succeeded";

            }
            catch (UnauthorizedAccessException ex)
            {
                ShowErrorMessage($"Issue: Access Denied\n{ex.Message}");
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Oops, something went wrong :(\n{ex.Message}");
            }
            finally
            {
                TransactionStatusLabel.Text = $"{TRANSACTION_STATUS} - Total {(TRANSACTION_END_TIME - TRANSACTION_START_TIME).TotalSeconds:0.000} Seconds";
            }
        }

        public void StartSubDestroyProcedure(string[] paths)
        {
            foreach (string path in paths)
            {
                if (File.Exists(path))
                {
                    EncryptFile(path);
                }
                else
                {
                    DestroyDirectory(path);
                }
                FileOrDirectoryAddFileListWithCustomFormat(path);
            }
        }

        public void DestroyDirectory(string directoryPath)
        {

            string[] files = Directory.GetFiles(directoryPath);
            string[] childDirectories = Directory.GetDirectories(directoryPath);

            for (int i = 0; i < files.Length; i++)
            {
                EncryptFile(files[i]);
            }

            for (int i = 0; i < childDirectories.Length; i++)
            {
                DestroyDirectory(childDirectories[i]);
            }
        }

        public void EncryptFile(string filePath)
        {
            byte[] bytesToBeEncrypted = File.ReadAllBytes(filePath);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(CreatePassword(25));
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            File.WriteAllBytes(filePath, bytesEncrypted);
        }

        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890*!=?&/";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        public static void DeleteFiles(string[] filePaths)
        {
            foreach (var path in filePaths)
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                else
                {
                    Directory.Delete(path, true);
                }
            }
        }
        #endregion




        #region Other Functions
        public void ShowErrorMessage(string message)
        {
            TRANSACTION_END_TIME = DateTime.Now.TimeOfDay;
            MessageBox.Show(message, ">_", MessageBoxButtons.OK, MessageBoxIcon.Error);
            TransactionStatusLabel.ForeColor = Color.Red;
        }

        public void FileOrDirectoryAddFileListWithCustomFormat(string file)
        {
            string fileOrDirectoryName = PathParser(file);
            FileList.Items.Add($"| {DateTime.Now:HH:mm:ss.fff} | {CURRENT_ROUND}. round | - {fileOrDirectoryName}");
        }

        public string PathParser(string path)
        {
            var pathArr = path.Split(Path.DirectorySeparatorChar);
            return pathArr[pathArr.Length - 1];
        }
        
     
        public void ClearForm()
        {
            FileList.Items.Clear();
        }
        #endregion

    }
}
