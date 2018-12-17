using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashUtil
{
    public partial class Form1 : Form
    {
        private const int BUFFER_SIZE = 1200000;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            DialogResult openFileResult = openFileDialog1.ShowDialog();

            if(openFileResult == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog1.FileName;

                using (var stream = new BufferedStream((File.OpenRead(openFileDialog1.FileName)), BUFFER_SIZE))
                {
                    Application.DoEvents();

                    Crc32 crc32 = new Crc32();
                    byte[] checksumCRC = crc32.ComputeHash(stream);
                    
                    txtCRC.Text = BitConverter.ToString(checksumCRC).Replace("-", String.Empty);

                }
            }
        }

        private String CalculateCRC(String pFilePath)
        {
            String result = "";
            try
            {
                using (var stream = new BufferedStream((File.OpenRead(pFilePath)), BUFFER_SIZE))
                {
                    Application.DoEvents();
                    Crc32 crc32 = new Crc32();
                    byte[] checksum = crc32.ComputeHash(stream);
                    result = BitConverter.ToString(checksum).Replace("-", String.Empty);
                }
            }
            catch(Exception ex)
            {
                //not handle
            }
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            Hide();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "Hash File (*.txt)|*.txt|All files (*.*)|*.*";
            if(fd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(fd.FileName, txtCRC.Text, Encoding.Default);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter= "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if(o.ShowDialog() == DialogResult.OK)
            {

                textBox1.Text = File.ReadAllText(o.FileName, Encoding.Default);
            }

            if(txtCRC.Text == textBox1.Text)
            {
                label3.Text = "изменений не было";
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                label3.Text = "сумма была изменена";
                MessageBox.Show("Сумма была изменена. Закрытие программы");
                Application.Exit();

            }
        }

        private void mainFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
