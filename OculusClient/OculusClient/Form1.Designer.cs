namespace OculusClient
{
    partial class frm_Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmb_ClientList = new System.Windows.Forms.ComboBox();
            this.txtb_ClientDisplay = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.btn_SendFile = new System.Windows.Forms.Button();
            this.txtb_SendData = new System.Windows.Forms.TextBox();
            this.ntfy_Tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.disconnectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(610, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // connectToToolStripMenuItem
            // 
            this.connectToToolStripMenuItem.Name = "connectToToolStripMenuItem";
            this.connectToToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.connectToToolStripMenuItem.Text = "&Connect To..";
            this.connectToToolStripMenuItem.Click += new System.EventHandler(this.connectToToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.disconnectToolStripMenuItem.Text = "&Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // cmb_ClientList
            // 
            this.cmb_ClientList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_ClientList.FormattingEnabled = true;
            this.cmb_ClientList.Location = new System.Drawing.Point(12, 534);
            this.cmb_ClientList.Name = "cmb_ClientList";
            this.cmb_ClientList.Size = new System.Drawing.Size(342, 21);
            this.cmb_ClientList.TabIndex = 1;
            this.cmb_ClientList.DropDown += new System.EventHandler(this.cmb_ClientList_DropDown);
            // 
            // txtb_ClientDisplay
            // 
            this.txtb_ClientDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtb_ClientDisplay.BackColor = System.Drawing.SystemColors.Info;
            this.txtb_ClientDisplay.Location = new System.Drawing.Point(13, 28);
            this.txtb_ClientDisplay.Multiline = true;
            this.txtb_ClientDisplay.Name = "txtb_ClientDisplay";
            this.txtb_ClientDisplay.ReadOnly = true;
            this.txtb_ClientDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtb_ClientDisplay.Size = new System.Drawing.Size(585, 483);
            this.txtb_ClientDisplay.TabIndex = 2;
            // 
            // btn_Send
            // 
            this.btn_Send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Send.Location = new System.Drawing.Point(361, 532);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 54);
            this.btn_Send.TabIndex = 3;
            this.btn_Send.Text = "Send IM";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // btn_SendFile
            // 
            this.btn_SendFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SendFile.Location = new System.Drawing.Point(442, 532);
            this.btn_SendFile.Name = "btn_SendFile";
            this.btn_SendFile.Size = new System.Drawing.Size(75, 54);
            this.btn_SendFile.TabIndex = 4;
            this.btn_SendFile.Text = "Send File";
            this.btn_SendFile.UseVisualStyleBackColor = true;
            this.btn_SendFile.Click += new System.EventHandler(this.btn_SendFile_Click);
            // 
            // txtb_SendData
            // 
            this.txtb_SendData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtb_SendData.Location = new System.Drawing.Point(13, 562);
            this.txtb_SendData.Multiline = true;
            this.txtb_SendData.Name = "txtb_SendData";
            this.txtb_SendData.Size = new System.Drawing.Size(341, 90);
            this.txtb_SendData.TabIndex = 5;
            this.txtb_SendData.TextChanged += new System.EventHandler(this.txtb_SendData_TextChanged);
            this.txtb_SendData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtb_SendData_KeyDown);
            this.txtb_SendData.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtb_SendData_KeyUp);
            // 
            // ntfy_Tray
            // 
            this.ntfy_Tray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ntfy_Tray.BalloonTipText = "New Message";
            this.ntfy_Tray.ContextMenuStrip = this.contextMenuStrip1;
            this.ntfy_Tray.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfy_Tray.Icon")));
            this.ntfy_Tray.Text = "Oculus Client";
            this.ntfy_Tray.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disconnectToolStripMenuItem1,
            this.exitToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(134, 48);
            // 
            // disconnectToolStripMenuItem1
            // 
            this.disconnectToolStripMenuItem1.Name = "disconnectToolStripMenuItem1";
            this.disconnectToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.disconnectToolStripMenuItem1.Text = "Disconnect";
            this.disconnectToolStripMenuItem1.Click += new System.EventHandler(this.disconnectToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 664);
            this.Controls.Add(this.txtb_SendData);
            this.Controls.Add(this.btn_SendFile);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.txtb_ClientDisplay);
            this.Controls.Add(this.cmb_ClientList);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_Main";
            this.Text = "Oculus Client v1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Main_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmb_ClientList;
        private System.Windows.Forms.TextBox txtb_ClientDisplay;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Button btn_SendFile;
        private System.Windows.Forms.TextBox txtb_SendData;
        private System.Windows.Forms.NotifyIcon ntfy_Tray;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

