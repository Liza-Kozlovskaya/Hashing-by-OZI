namespace HashUtil
{
    partial class RSA
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtResult = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.pnlRSA = new System.Windows.Forms.Panel();
            this.txtPrivateKey = new System.Windows.Forms.TextBox();
            this.lblPrivateKey = new System.Windows.Forms.Label();
            this.txtPublicKey = new System.Windows.Forms.TextBox();
            this.lblPublicKey = new System.Windows.Forms.Label();
            this.lblKeySizeValue = new System.Windows.Forms.Label();
            this.lblKeySize = new System.Windows.Forms.Label();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mniRSA = new System.Windows.Forms.ToolStripMenuItem();
            this.mniKeySize = new System.Windows.Forms.ToolStripMenuItem();
            this.mniKeySize512 = new System.Windows.Forms.ToolStripMenuItem();
            this.mniKeySize1024 = new System.Windows.Forms.ToolStripMenuItem();
            this.mniKeySize2048 = new System.Windows.Forms.ToolStripMenuItem();
            this.mniKeySize5096 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mniGenerate = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.saveKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlRSA.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(213, 352);
            this.txtResult.Margin = new System.Windows.Forms.Padding(4);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(811, 399);
            this.txtResult.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(213, 293);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(812, 52);
            this.panel2.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 52);
            this.label1.TabIndex = 1;
            this.label1.Text = "Text result";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(213, 98);
            this.txtContent.Margin = new System.Windows.Forms.Padding(4);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(811, 175);
            this.txtContent.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnEncrypt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnDecrypt);
            this.panel1.Location = new System.Drawing.Point(213, 34);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(812, 52);
            this.panel1.TabIndex = 14;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.BackColor = System.Drawing.Color.Transparent;
            this.btnEncrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncrypt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEncrypt.Location = new System.Drawing.Point(597, 10);
            this.btnEncrypt.Margin = new System.Windows.Forms.Padding(4);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(95, 32);
            this.btnEncrypt.TabIndex = 2;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = false;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click_1);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 52);
            this.label3.TabIndex = 1;
            this.label3.Text = "Text content";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecrypt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDecrypt.Location = new System.Drawing.Point(715, 10);
            this.btnDecrypt.Margin = new System.Windows.Forms.Padding(4);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(93, 32);
            this.btnDecrypt.TabIndex = 0;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // pnlRSA
            // 
            this.pnlRSA.BackColor = System.Drawing.Color.Transparent;
            this.pnlRSA.Controls.Add(this.txtPrivateKey);
            this.pnlRSA.Controls.Add(this.lblPrivateKey);
            this.pnlRSA.Controls.Add(this.txtPublicKey);
            this.pnlRSA.Controls.Add(this.lblPublicKey);
            this.pnlRSA.Controls.Add(this.lblKeySizeValue);
            this.pnlRSA.Controls.Add(this.lblKeySize);
            this.pnlRSA.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlRSA.Location = new System.Drawing.Point(0, 28);
            this.pnlRSA.Margin = new System.Windows.Forms.Padding(4);
            this.pnlRSA.Name = "pnlRSA";
            this.pnlRSA.Padding = new System.Windows.Forms.Padding(4);
            this.pnlRSA.Size = new System.Drawing.Size(200, 732);
            this.pnlRSA.TabIndex = 13;
            // 
            // txtPrivateKey
            // 
            this.txtPrivateKey.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPrivateKey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrivateKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrivateKey.Location = new System.Drawing.Point(4, 395);
            this.txtPrivateKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrivateKey.Multiline = true;
            this.txtPrivateKey.Name = "txtPrivateKey";
            this.txtPrivateKey.ReadOnly = true;
            this.txtPrivateKey.Size = new System.Drawing.Size(192, 333);
            this.txtPrivateKey.TabIndex = 9;
            // 
            // lblPrivateKey
            // 
            this.lblPrivateKey.BackColor = System.Drawing.Color.DimGray;
            this.lblPrivateKey.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPrivateKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrivateKey.ForeColor = System.Drawing.Color.White;
            this.lblPrivateKey.Location = new System.Drawing.Point(4, 379);
            this.lblPrivateKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrivateKey.Name = "lblPrivateKey";
            this.lblPrivateKey.Size = new System.Drawing.Size(192, 16);
            this.lblPrivateKey.TabIndex = 8;
            this.lblPrivateKey.Text = "Private Key";
            this.lblPrivateKey.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtPublicKey
            // 
            this.txtPublicKey.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPublicKey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPublicKey.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPublicKey.Location = new System.Drawing.Point(4, 70);
            this.txtPublicKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtPublicKey.Multiline = true;
            this.txtPublicKey.Name = "txtPublicKey";
            this.txtPublicKey.ReadOnly = true;
            this.txtPublicKey.Size = new System.Drawing.Size(192, 309);
            this.txtPublicKey.TabIndex = 7;
            // 
            // lblPublicKey
            // 
            this.lblPublicKey.BackColor = System.Drawing.Color.DimGray;
            this.lblPublicKey.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPublicKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPublicKey.ForeColor = System.Drawing.Color.White;
            this.lblPublicKey.Location = new System.Drawing.Point(4, 54);
            this.lblPublicKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPublicKey.Name = "lblPublicKey";
            this.lblPublicKey.Size = new System.Drawing.Size(192, 16);
            this.lblPublicKey.TabIndex = 6;
            this.lblPublicKey.Text = "Public Key";
            this.lblPublicKey.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblKeySizeValue
            // 
            this.lblKeySizeValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblKeySizeValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKeySizeValue.Location = new System.Drawing.Point(4, 29);
            this.lblKeySizeValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKeySizeValue.Name = "lblKeySizeValue";
            this.lblKeySizeValue.Size = new System.Drawing.Size(192, 25);
            this.lblKeySizeValue.TabIndex = 5;
            this.lblKeySizeValue.Text = "512";
            this.lblKeySizeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKeySize
            // 
            this.lblKeySize.BackColor = System.Drawing.Color.DimGray;
            this.lblKeySize.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKeySize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeySize.ForeColor = System.Drawing.Color.White;
            this.lblKeySize.Location = new System.Drawing.Point(4, 4);
            this.lblKeySize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKeySize.Name = "lblKeySize";
            this.lblKeySize.Size = new System.Drawing.Size(192, 25);
            this.lblKeySize.TabIndex = 4;
            this.lblKeySize.Text = "Key Size";
            this.lblKeySize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mnuMain
            // 
            this.mnuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniRSA});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mnuMain.Size = new System.Drawing.Size(1041, 28);
            this.mnuMain.TabIndex = 12;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mniRSA
            // 
            this.mniRSA.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniKeySize,
            this.toolStripSeparator1,
            this.mniGenerate,
            this.saveKeyToolStripMenuItem,
            this.openKeyToolStripMenuItem});
            this.mniRSA.Name = "mniRSA";
            this.mniRSA.Size = new System.Drawing.Size(48, 24);
            this.mniRSA.Text = "RSA";
            // 
            // mniKeySize
            // 
            this.mniKeySize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniKeySize512,
            this.mniKeySize1024,
            this.mniKeySize2048,
            this.mniKeySize5096});
            this.mniKeySize.Name = "mniKeySize";
            this.mniKeySize.Size = new System.Drawing.Size(172, 26);
            this.mniKeySize.Text = "Key Size";
            // 
            // mniKeySize512
            // 
            this.mniKeySize512.Checked = true;
            this.mniKeySize512.CheckOnClick = true;
            this.mniKeySize512.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mniKeySize512.Name = "mniKeySize512";
            this.mniKeySize512.Size = new System.Drawing.Size(116, 26);
            this.mniKeySize512.Tag = "512";
            this.mniKeySize512.Text = "512";
            // 
            // mniKeySize1024
            // 
            this.mniKeySize1024.CheckOnClick = true;
            this.mniKeySize1024.Name = "mniKeySize1024";
            this.mniKeySize1024.Size = new System.Drawing.Size(116, 26);
            this.mniKeySize1024.Tag = "1024";
            this.mniKeySize1024.Text = "1024";
            // 
            // mniKeySize2048
            // 
            this.mniKeySize2048.CheckOnClick = true;
            this.mniKeySize2048.Name = "mniKeySize2048";
            this.mniKeySize2048.Size = new System.Drawing.Size(116, 26);
            this.mniKeySize2048.Tag = "2048";
            this.mniKeySize2048.Text = "2048";
            // 
            // mniKeySize5096
            // 
            this.mniKeySize5096.CheckOnClick = true;
            this.mniKeySize5096.Name = "mniKeySize5096";
            this.mniKeySize5096.Size = new System.Drawing.Size(116, 26);
            this.mniKeySize5096.Tag = "5096";
            this.mniKeySize5096.Text = "5096";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // mniGenerate
            // 
            this.mniGenerate.Name = "mniGenerate";
            this.mniGenerate.Size = new System.Drawing.Size(216, 26);
            this.mniGenerate.Text = "Generate Pair";
            this.mniGenerate.Click += new System.EventHandler(this.mniGenerate_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(928, 241);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 32);
            this.button1.TabIndex = 18;
            this.button1.Text = "Open hash";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveKeyToolStripMenuItem
            // 
            this.saveKeyToolStripMenuItem.Name = "saveKeyToolStripMenuItem";
            this.saveKeyToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.saveKeyToolStripMenuItem.Text = "Save key";
            this.saveKeyToolStripMenuItem.Click += new System.EventHandler(this.saveKeyToolStripMenuItem_Click);
            // 
            // openKeyToolStripMenuItem
            // 
            this.openKeyToolStripMenuItem.Name = "openKeyToolStripMenuItem";
            this.openKeyToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.openKeyToolStripMenuItem.Text = "Open key";
            this.openKeyToolStripMenuItem.Click += new System.EventHandler(this.openKeyToolStripMenuItem_Click);
            // 
            // RSA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(1041, 760);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlRSA);
            this.Controls.Add(this.mnuMain);
            this.Name = "RSA";
            this.Text = "RSA";
            this.Load += new System.EventHandler(this.RSA_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlRSA.ResumeLayout(false);
            this.pnlRSA.PerformLayout();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Panel pnlRSA;
        private System.Windows.Forms.TextBox txtPrivateKey;
        private System.Windows.Forms.Label lblPrivateKey;
        private System.Windows.Forms.TextBox txtPublicKey;
        private System.Windows.Forms.Label lblPublicKey;
        private System.Windows.Forms.Label lblKeySizeValue;
        private System.Windows.Forms.Label lblKeySize;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mniRSA;
        private System.Windows.Forms.ToolStripMenuItem mniKeySize;
        private System.Windows.Forms.ToolStripMenuItem mniKeySize512;
        private System.Windows.Forms.ToolStripMenuItem mniKeySize1024;
        private System.Windows.Forms.ToolStripMenuItem mniKeySize2048;
        private System.Windows.Forms.ToolStripMenuItem mniKeySize5096;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mniGenerate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem saveKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openKeyToolStripMenuItem;
    }
}