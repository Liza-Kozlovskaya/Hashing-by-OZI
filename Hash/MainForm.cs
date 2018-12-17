using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace HashUtil
{
    public partial class MainForm : Form
    {
        private List<FileInfo> FileList = new List<FileInfo>();
        private List<FileInfo> VerifyList = new List<FileInfo>();
        private BackgroundWorker bw = new BackgroundWorker();
        private bool running = false;

        private Hashes.Type currentHash;

        public MainForm()
        {
            InitializeComponent();

            
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = false;
            bw.DoWork += Bw_DoWork;
            bw.ProgressChanged += Bw_ProgressChanged;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
            
            //Создание таблицы с заголовками
            ColumnHeader h1 = new ColumnHeader();
            h1.Text = "Filename";

            ColumnHeader h2 = new ColumnHeader();
            h2.Text = "Hash";

            ColumnHeader h3 = new ColumnHeader();
            h3.Text = "Comparison hash";

            lvMain.Columns.AddRange(new ColumnHeader[] { h1, h2, h3});
            lvMain.SmallImageList = imgList;

            foreach (ColumnHeader header in lvMain.Columns)
                if (header.Width < 150)
                    header.Width = 150;

            btnSave.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            
            // Вывод суммы
            ToolStripMenuItem h_crc32 = new ToolStripMenuItem();
            h_crc32.Text = "CRC32";
            h_crc32.Checked = true;
            h_crc32.Click += Hash_Click;

            ToolStripMenuItem h_md5 = new ToolStripMenuItem();
            h_md5.Text = "MD5";
            h_md5.Checked = false;
            h_md5.Click += Hash_Click;

            ToolStripMenuItem h_sha1 = new ToolStripMenuItem();
            h_sha1.Text = "SHA1";
            h_sha1.Checked = false;
            h_sha1.Click += Hash_Click;

            hashTypeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { h_crc32, h_md5, h_sha1 });

            // хэш по умолчанию 32
            currentHash = Hashes.Type.CRC32;
        }

        // Отключить хэширование
        private void uncheck_hashes()
        {
            foreach(ToolStripMenuItem item in hashTypeToolStripMenuItem.DropDownItems)
                item.Checked = false;
        }

        //хэш-переключатель
        private void hashes_toggleEnable()
        {
            foreach(ToolStripMenuItem item in hashTypeToolStripMenuItem.DropDownItems)
                item.Enabled = !item.Enabled;
        }

        // Подсчёт хэша и вывод в таблицу
        private void Hash_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            uncheck_hashes();
            item.Checked = true;
            currentHash = Hashes.ParseType(item.Text);
            lvMain.Columns[1].Text = item.Text;
            VerifyList.Clear();
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e) {
            HashAlgorithm sp = null;
            switch (currentHash)
            {
                case Hashes.Type.CRC32:
                    sp = new Crc32();
                    break;
                case Hashes.Type.MD5:
                    sp = new MD5CryptoServiceProvider();
                    break;
                case Hashes.Type.SHA1:
                    sp = new SHA1CryptoServiceProvider();
                    break;
                default:
                    bw.ReportProgress(-2, "Invalid hash type: " + currentHash.ToString());
                    return;
            }

             //хэш каждого файла в списке
            List<FileInfo> fileList = (List<FileInfo>)e.Argument;
            foreach(FileInfo file in fileList) {
               //попытка открыть файл, если нет, то пропускаем
                FileStream fs = null;
                try {
                    fs = new FileStream(file.Name, FileMode.Open);
                } catch (Exception ex) {
                    file.Error = ex.Message;
                    file.status = FileInfo.FileStatus.NOTOK;
                    bw.ReportProgress(-1, file);
                    continue;
                }
                
                file.status = FileInfo.FileStatus.WORKING;
                bw.ReportProgress(1, file);
                byte[] hash = sp.ComputeHash(fs);
                fs.Close();
                
                //обновление экрана и вывод хэша
                file.Hash = BitConverter.ToString(hash);
                bw.ReportProgress(2, file);
            }
        }

        // Обновляем список файлов на экране, чтобы отразить их текущий статус
        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            FileInfo f = (FileInfo)e.UserState;

            //поиск нужного файла в списке
            int idx;
            for(idx = 0; idx < FileList.Count; idx++) {
                if (FileList[idx].Name == f.Name)
                    break;
            }

            //если не удаётся посчитать хэш
            if (e.ProgressPercentage < 0) {
                lvMain.Items[idx].SubItems[1].Text = f.Error;
            }
            //идёт пожсчёт хэша
            if (e.ProgressPercentage == 1) {
                lvMain.Items[idx].SubItems[1].Text = "Working...";
                f.status = FileInfo.FileStatus.WORKING;
            }
            else //подсчёт прошёл успешно/не успешно
            {
                lvMain.Items[idx].SubItems[1].Text = f.Hash;
                if (VerifyList.Count > 0) {
                    if (VerifyList[idx].Hash != f.Hash) {
                        f.status = FileInfo.FileStatus.NOTOK;
                        Console.WriteLine("Verify failed: " + VerifyList[idx].Hash + " != " + f.Hash);
                    } else {
                        f.status = FileInfo.FileStatus.OK;
                        Console.WriteLine("Verify passed: " + VerifyList[idx].Hash + " == " + f.Hash);
                    }
                } else
                    f.status = FileInfo.FileStatus.OK;
            }

            lvMain.Items[idx].ImageIndex = (int)f.status;
            //вывод
            Console.WriteLine("Verify: " + VerifyList.Count + "; status: " + f.status);
        }

       //очистка после завершения
        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnAdd.Enabled = true;
            btnClear.Enabled = true;
            btnExit.Enabled = true;
            btnSave.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            hashes_toggleEnable();
            UpdateListView();
        }

        // Очиститка предыдущие хэшей. Отключение некоторых кнопок и запуск в фоновом режиме.
        private void StartHashing()
        {
            for(int i = 0; i < FileList.Count; i++)
            {
                FileList.ElementAt(i).Hash = "";
                FileList.ElementAt(i).status = FileInfo.FileStatus.UNKNOWN;
            }
            running = true;
            UpdateListView();
            btnAdd.Enabled = false;
            btnClear.Enabled = false;
            btnExit.Enabled = false;
            btnSave.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            hashes_toggleEnable();
            bw.RunWorkerAsync(FileList);
        }

        //очистка старых файлов и открытие новых
        private void OpenFiles()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Multiselect = true;
            fd.CheckFileExists = true;
            DialogResult res = fd.ShowDialog();
            if (res == DialogResult.OK)
            {
                FileList.Clear();
                foreach (string file in fd.FileNames)
                    FileList.Add(new FileInfo(file));
                UpdateListView();
            }
        }

        //метод сохранения 
        private void SaveHashes()
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "Hash File|*.txt";
            fd.CheckFileExists = false;
            DialogResult res = fd.ShowDialog();
            if (res == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(fd.FileName);
                foreach (FileInfo f in FileList)
                    writer.WriteLine(f.FileString());
                writer.Close();
            }

        }

        //обновление таблицы с файлами
        private void UpdateListView()
        {
            lvMain.Items.Clear();
            lvMain.BeginUpdate();   
            bool even = true;
            bool verifying = false;
            if (VerifyList.Count > 0)
                verifying = true;

            for( int idx = 0; idx < FileList.Count(); idx++) {
                FileInfo file = FileList[idx];
                ListViewItem i = new ListViewItem();
                i.Text = file.Basename;
                i.ImageIndex = (int)file.status;

                if (file.Hash == null)
                    if (running)
                        i.SubItems.Add("Waiting...");
                    else
                        i.SubItems.Add("");
                else
                    i.SubItems.Add(file.Hash);
                
                if (verifying)
                    i.SubItems.Add(VerifyList[idx].Hash);
                else
                    i.SubItems.Add("");

                if (even)
                    i.BackColor = Color.LightBlue;
                even = !even;
                lvMain.Items.Add(i);
            }
            lvMain.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            foreach(ColumnHeader header in lvMain.Columns)
                if (header.Width < 150)
                    header.Width = 150;
            lvMain.EndUpdate();
            lblFileCount.Text = lvMain.Items.Count.ToString();
        }

        //очистка всех файлов из таблицы
        private void ClearList()
        {
            FileList.Clear();
            VerifyList.Clear();
            UpdateListView();
            btnSave.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
        }

        //проверка файлов
        private void VerifyFiles()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Text files|*.txt|All Files|*.*";
            fd.CheckFileExists = true;
            DialogResult res = fd.ShowDialog();
            if (res == DialogResult.Cancel || res == DialogResult.Abort)
                return;

            string dirname = Path.GetDirectoryName(fd.FileName);

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = dirname;
            res = fbd.ShowDialog();
            if (res == DialogResult.Cancel || res == DialogResult.Abort)
                return;

            StreamReader reader = new StreamReader(fd.FileName);
            string[] lines = Regex.Split(reader.ReadToEnd(), "\r\n");
            reader.Close();

            VerifyList.Clear();
            FileList.Clear();
            foreach(string line in lines) {
                if (line.Length > 0) {
                    FileInfo fi = FileInfo.ParseInfoLine(line);
                    fi.SetDirectory(dirname);
                    VerifyList.Add(fi);
                    FileList.Add(new FileInfo(fi.Name));
                }
            }

            currentHash = VerifyList[0].HashType;
            lvMain.Columns[1].Text = Hashes.String(currentHash);

            UpdateListView();
            StartHashing();
        }

        //кнопка подсчёта хэша файлов
        private void btnHash_Click(object sender, EventArgs e) {
            StartHashing();
        }

        //кнопка сохранения
        private void btnSave_Click(object sender, EventArgs e) {
            SaveHashes();
        }

        //кнопка выхода
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        //кнопка очистки 
        private void clearToolStripMenuItem_Click(object sender, EventArgs e) {
            ClearList();
        }

        //кнопка очистки
        private void btnClear_Click(object sender, EventArgs e) {
            ClearList();
        }

        //кнопка сохранения
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveHashes();
        }

        //кнопка открытия файлов
        private void openFilesToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFiles();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            OpenFiles();
        }

        private void btnExit_Click(object sender, EventArgs e) {
            Close();
        }

        private void verifyFilesToolStripMenuItem_Click(object sender, EventArgs e) {
            VerifyFiles();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void rSAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RSA rSA = new RSA();
            rSA.Show();
        }
    }
}
