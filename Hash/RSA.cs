using RSAManager.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashUtil
{
    public partial class RSA : Form
    {
        private RSAHelper _rsa = null;

        public RSA()
        {
            InitializeComponent();
        }

        private void RSA_Load(object sender, EventArgs e)
        {

        }
        private void mniKeySize512_CheckedChanged(object sender, EventArgs e)
        {
            var mniState = ((ToolStripMenuItem)sender).Checked;
            if (mniState) changeCheckMenuItems(sender, false);
        }

        private void changeCheckMenuItems(object sender, bool chacked)
        {
            foreach (var item in mniKeySize.DropDownItems)
            {
                ((ToolStripMenuItem)item).CheckedChanged -= mniKeySize512_CheckedChanged;
            }

            foreach (var item in mniKeySize.DropDownItems)
            {
                if (item != sender)
                {
                    ((ToolStripMenuItem)item).Checked = chacked;
                }
            }

            foreach (var item in mniKeySize.DropDownItems)
            {
                ((ToolStripMenuItem)item).CheckedChanged += mniKeySize512_CheckedChanged;
            }
        }

        private int getKeySize()
        {
            foreach (var item in mniKeySize.DropDownItems)
            {
                var mni = ((ToolStripMenuItem)item);
                if (mni.Checked) return int.Parse(mni.Text);
            }
            return 0;
        }

        private void mniGenerate_Click_1(object sender, EventArgs e)
        {
            // look for the selcted menu item
            var keySize = getKeySize();
            if (keySize == 0)
            {
                MessageBox.Show("Please, selected a key size!");
                return;
            }
            // conver the menu item key size (512, 1024, ....) and generate a key pair
            // attention! you can not use a different private key to decrypt an encrypted data
            // if you realize, we are saving the pair (public and private keys) 
            lblKeySizeValue.Text = keySize.ToString();
            _rsa = new RSAHelper(keySize);
            txtPublicKey.Text = _rsa.PublicKey();
            txtPrivateKey.Text = _rsa.PrivateKey();
        }

        private void btnEncrypt_Click_1(object sender, EventArgs e)
        {
            if (_rsa == null)
            {
                MessageBox.Show("Please, generate a key pair first!");
                return;
            }
            if (string.IsNullOrEmpty(txtContent.Text))
            {
                MessageBox.Show("Please, inform some content!");
                return;
            }
            try
            {
                txtResult.Text = _rsa.EncryptString(txtContent.Text, txtPublicKey.Text);
            }
            catch (Exception ex)
            {
                txtResult.Text = "";
                MessageBox.Show("There was an error trying to encrypt the text content. Check if the key size is enought to the text size!");
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (_rsa == null)
            {
                MessageBox.Show("Please, generate a key pair first!");
                return;
            }
            if (string.IsNullOrEmpty(txtContent.Text))
            {
                MessageBox.Show("Please, inform some content!");
                return;
            }
            try
            {
                txtResult.Text = _rsa.DecryptString(txtContent.Text, txtPrivateKey.Text);
            }
            catch (Exception ex)
            {
                txtResult.Text = "";
                MessageBox.Show("There was an error trying to decrypt the text content. Check if the private key is linked with the public key used to encrypt the text content!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (o.ShowDialog() == DialogResult.OK)
            {

                txtContent.Text = File.ReadAllText(o.FileName, Encoding.Default);
            }
        }

        private void saveKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "Hash File (*.txt)|*.txt|All files (*.*)|*.*";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(fd.FileName, txtPublicKey.Text, Encoding.Default);
            }
            SaveFileDialog pd = new SaveFileDialog();
            pd.Filter = "Hash File (*.txt)|*.txt|All files (*.*)|*.*";
            if (pd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(pd.FileName, txtPrivateKey.Text, Encoding.Default);
            }
        }

        private void openKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog priv = new OpenFileDialog();
            priv.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (priv.ShowDialog() == DialogResult.OK)
            {
                txtPrivateKey.Text = File.ReadAllText(priv.FileName, Encoding.Default);
            }
            OpenFileDialog publ = new OpenFileDialog();
            publ.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (publ.ShowDialog() == DialogResult.OK)
            {

                txtPublicKey.Text = File.ReadAllText(publ.FileName, Encoding.Default);
            }
        }
    }
}
