namespace UnderwaterVideo2
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.videoCaptureBtn = new System.Windows.Forms.ToolStripButton();
            this.txBtn = new System.Windows.Forms.ToolStripButton();
            this.rxBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.vIDEOCAPTUREDEVICEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoCaptureDeviceCbx = new System.Windows.Forms.ToolStripComboBox();
            this.aUDIOINPUTDEVICEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audioInputDeviceCbx = new System.Windows.Forms.ToolStripComboBox();
            this.sAMPLERATEHZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sampleRateCbx = new System.Windows.Forms.ToolStripComboBox();
            this.infoBtn = new System.Windows.Forms.ToolStripButton();
            this.isSaveFramesBtn = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.srcGroup = new System.Windows.Forms.GroupBox();
            this.srcPbx = new System.Windows.Forms.PictureBox();
            this.txGroup = new System.Windows.Forms.GroupBox();
            this.txPbx = new System.Windows.Forms.PictureBox();
            this.rxGroup = new System.Windows.Forms.GroupBox();
            this.rxPbx = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.syncTkb = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sensTkb = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.interframePauseTkb = new System.Windows.Forms.TrackBar();
            this.toolStrip.SuspendLayout();
            this.srcGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.srcPbx)).BeginInit();
            this.txGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txPbx)).BeginInit();
            this.rxGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rxPbx)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.syncTkb)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensTkb)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.interframePauseTkb)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoCaptureBtn,
            this.txBtn,
            this.rxBtn,
            this.toolStripSeparator1,
            this.settingsBtn,
            this.infoBtn,
            this.isSaveFramesBtn});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1017, 30);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // videoCaptureBtn
            // 
            this.videoCaptureBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.videoCaptureBtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.videoCaptureBtn.Image = ((System.Drawing.Image)(resources.GetObject("videoCaptureBtn.Image")));
            this.videoCaptureBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.videoCaptureBtn.Name = "videoCaptureBtn";
            this.videoCaptureBtn.Size = new System.Drawing.Size(145, 27);
            this.videoCaptureBtn.Text = "VIDEO CAPTURE";
            this.videoCaptureBtn.Click += new System.EventHandler(this.videoCaptureBtn_Click);
            // 
            // txBtn
            // 
            this.txBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.txBtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txBtn.Image = ((System.Drawing.Image)(resources.GetObject("txBtn.Image")));
            this.txBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.txBtn.Name = "txBtn";
            this.txBtn.Size = new System.Drawing.Size(131, 27);
            this.txBtn.Text = "TRANSMITTER";
            this.txBtn.Click += new System.EventHandler(this.txBtn_Click);
            // 
            // rxBtn
            // 
            this.rxBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.rxBtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rxBtn.Image = ((System.Drawing.Image)(resources.GetObject("rxBtn.Image")));
            this.rxBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rxBtn.Name = "rxBtn";
            this.rxBtn.Size = new System.Drawing.Size(90, 27);
            this.rxBtn.Text = "RECEIVER";
            this.rxBtn.Click += new System.EventHandler(this.rxBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // settingsBtn
            // 
            this.settingsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.settingsBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vIDEOCAPTUREDEVICEToolStripMenuItem,
            this.aUDIOINPUTDEVICEToolStripMenuItem,
            this.sAMPLERATEHZToolStripMenuItem});
            this.settingsBtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settingsBtn.Image = ((System.Drawing.Image)(resources.GetObject("settingsBtn.Image")));
            this.settingsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(102, 27);
            this.settingsBtn.Text = "SETTINGS";
            // 
            // vIDEOCAPTUREDEVICEToolStripMenuItem
            // 
            this.vIDEOCAPTUREDEVICEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoCaptureDeviceCbx});
            this.vIDEOCAPTUREDEVICEToolStripMenuItem.Name = "vIDEOCAPTUREDEVICEToolStripMenuItem";
            this.vIDEOCAPTUREDEVICEToolStripMenuItem.Size = new System.Drawing.Size(274, 28);
            this.vIDEOCAPTUREDEVICEToolStripMenuItem.Text = "VIDEO CAPTURE DEVICE";
            // 
            // videoCaptureDeviceCbx
            // 
            this.videoCaptureDeviceCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.videoCaptureDeviceCbx.Name = "videoCaptureDeviceCbx";
            this.videoCaptureDeviceCbx.Size = new System.Drawing.Size(121, 28);
            this.videoCaptureDeviceCbx.SelectedIndexChanged += new System.EventHandler(this.videoCaptureDeviceCbx_SelectedIndexChanged);
            // 
            // aUDIOINPUTDEVICEToolStripMenuItem
            // 
            this.aUDIOINPUTDEVICEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.audioInputDeviceCbx});
            this.aUDIOINPUTDEVICEToolStripMenuItem.Name = "aUDIOINPUTDEVICEToolStripMenuItem";
            this.aUDIOINPUTDEVICEToolStripMenuItem.Size = new System.Drawing.Size(274, 28);
            this.aUDIOINPUTDEVICEToolStripMenuItem.Text = "AUDIO INPUT DEVICE";
            // 
            // audioInputDeviceCbx
            // 
            this.audioInputDeviceCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.audioInputDeviceCbx.Name = "audioInputDeviceCbx";
            this.audioInputDeviceCbx.Size = new System.Drawing.Size(121, 28);
            this.audioInputDeviceCbx.SelectedIndexChanged += new System.EventHandler(this.audioInputDeviceCbx_SelectedIndexChanged);
            // 
            // sAMPLERATEHZToolStripMenuItem
            // 
            this.sAMPLERATEHZToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sampleRateCbx});
            this.sAMPLERATEHZToolStripMenuItem.Name = "sAMPLERATEHZToolStripMenuItem";
            this.sAMPLERATEHZToolStripMenuItem.Size = new System.Drawing.Size(274, 28);
            this.sAMPLERATEHZToolStripMenuItem.Text = "SAMPLE RATE, HZ";
            // 
            // sampleRateCbx
            // 
            this.sampleRateCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sampleRateCbx.Name = "sampleRateCbx";
            this.sampleRateCbx.Size = new System.Drawing.Size(121, 28);
            this.sampleRateCbx.SelectedIndexChanged += new System.EventHandler(this.sampleRateCbx_SelectedIndexChanged);
            // 
            // infoBtn
            // 
            this.infoBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.infoBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.infoBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoBtn.Image = ((System.Drawing.Image)(resources.GetObject("infoBtn.Image")));
            this.infoBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Size = new System.Drawing.Size(54, 27);
            this.infoBtn.Text = "INFO";
            this.infoBtn.Click += new System.EventHandler(this.infoBtn_Click);
            // 
            // isSaveFramesBtn
            // 
            this.isSaveFramesBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.isSaveFramesBtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.isSaveFramesBtn.Image = ((System.Drawing.Image)(resources.GetObject("isSaveFramesBtn.Image")));
            this.isSaveFramesBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.isSaveFramesBtn.Name = "isSaveFramesBtn";
            this.isSaveFramesBtn.Size = new System.Drawing.Size(127, 27);
            this.isSaveFramesBtn.Text = "SAVE FRAMES";
            this.isSaveFramesBtn.Click += new System.EventHandler(this.isSaveSnapShotsBtn_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 483);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(1017, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // srcGroup
            // 
            this.srcGroup.Controls.Add(this.srcPbx);
            this.srcGroup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.srcGroup.Location = new System.Drawing.Point(16, 34);
            this.srcGroup.Margin = new System.Windows.Forms.Padding(4);
            this.srcGroup.Name = "srcGroup";
            this.srcGroup.Padding = new System.Windows.Forms.Padding(4);
            this.srcGroup.Size = new System.Drawing.Size(320, 268);
            this.srcGroup.TabIndex = 2;
            this.srcGroup.TabStop = false;
            this.srcGroup.Text = "SOURCE";
            // 
            // srcPbx
            // 
            this.srcPbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.srcPbx.Location = new System.Drawing.Point(8, 26);
            this.srcPbx.Margin = new System.Windows.Forms.Padding(4);
            this.srcPbx.Name = "srcPbx";
            this.srcPbx.Size = new System.Drawing.Size(304, 235);
            this.srcPbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.srcPbx.TabIndex = 0;
            this.srcPbx.TabStop = false;
            // 
            // txGroup
            // 
            this.txGroup.Controls.Add(this.txPbx);
            this.txGroup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txGroup.Location = new System.Drawing.Point(344, 34);
            this.txGroup.Margin = new System.Windows.Forms.Padding(4);
            this.txGroup.Name = "txGroup";
            this.txGroup.Padding = new System.Windows.Forms.Padding(4);
            this.txGroup.Size = new System.Drawing.Size(320, 268);
            this.txGroup.TabIndex = 3;
            this.txGroup.TabStop = false;
            this.txGroup.Text = "TX/LOOP";
            // 
            // txPbx
            // 
            this.txPbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txPbx.Location = new System.Drawing.Point(8, 26);
            this.txPbx.Margin = new System.Windows.Forms.Padding(4);
            this.txPbx.Name = "txPbx";
            this.txPbx.Size = new System.Drawing.Size(304, 235);
            this.txPbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.txPbx.TabIndex = 0;
            this.txPbx.TabStop = false;
            // 
            // rxGroup
            // 
            this.rxGroup.Controls.Add(this.rxPbx);
            this.rxGroup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rxGroup.Location = new System.Drawing.Point(672, 34);
            this.rxGroup.Margin = new System.Windows.Forms.Padding(4);
            this.rxGroup.Name = "rxGroup";
            this.rxGroup.Padding = new System.Windows.Forms.Padding(4);
            this.rxGroup.Size = new System.Drawing.Size(320, 268);
            this.rxGroup.TabIndex = 4;
            this.rxGroup.TabStop = false;
            this.rxGroup.Text = "RX";
            // 
            // rxPbx
            // 
            this.rxPbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rxPbx.Location = new System.Drawing.Point(8, 26);
            this.rxPbx.Margin = new System.Windows.Forms.Padding(4);
            this.rxPbx.Name = "rxPbx";
            this.rxPbx.Size = new System.Drawing.Size(304, 235);
            this.rxPbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rxPbx.TabIndex = 0;
            this.rxPbx.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.syncTkb);
            this.groupBox1.Location = new System.Drawing.Point(16, 309);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 77);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sync";
            // 
            // syncTkb
            // 
            this.syncTkb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.syncTkb.LargeChange = 8;
            this.syncTkb.Location = new System.Drawing.Point(8, 15);
            this.syncTkb.Maximum = 480;
            this.syncTkb.Name = "syncTkb";
            this.syncTkb.Size = new System.Drawing.Size(407, 56);
            this.syncTkb.TabIndex = 0;
            this.syncTkb.TickFrequency = 8;
            this.syncTkb.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.syncTkb.Scroll += new System.EventHandler(this.syncTkb_Scroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sensTkb);
            this.groupBox2.Location = new System.Drawing.Point(16, 392);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(421, 77);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Threshold";
            // 
            // sensTkb
            // 
            this.sensTkb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sensTkb.Location = new System.Drawing.Point(8, 15);
            this.sensTkb.Maximum = 10000;
            this.sensTkb.Minimum = 100;
            this.sensTkb.Name = "sensTkb";
            this.sensTkb.Size = new System.Drawing.Size(407, 56);
            this.sensTkb.SmallChange = 100;
            this.sensTkb.TabIndex = 0;
            this.sensTkb.TickFrequency = 100;
            this.sensTkb.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.sensTkb.Value = 500;
            this.sensTkb.Scroll += new System.EventHandler(this.sensTkb_Scroll);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.interframePauseTkb);
            this.groupBox3.Location = new System.Drawing.Point(443, 309);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(421, 77);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Interframe pause, ms";
            // 
            // interframePauseTkb
            // 
            this.interframePauseTkb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.interframePauseTkb.LargeChange = 8;
            this.interframePauseTkb.Location = new System.Drawing.Point(8, 15);
            this.interframePauseTkb.Maximum = 500;
            this.interframePauseTkb.Name = "interframePauseTkb";
            this.interframePauseTkb.Size = new System.Drawing.Size(407, 56);
            this.interframePauseTkb.TabIndex = 0;
            this.interframePauseTkb.TickFrequency = 10;
            this.interframePauseTkb.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.interframePauseTkb.Scroll += new System.EventHandler(this.interframePauseTkb_Scroll);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 505);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rxGroup);
            this.Controls.Add(this.txGroup);
            this.Controls.Add(this.srcGroup);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "UnderwaterVideo2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.srcGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.srcPbx)).EndInit();
            this.txGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txPbx)).EndInit();
            this.rxGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rxPbx)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.syncTkb)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensTkb)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.interframePauseTkb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripButton videoCaptureBtn;
        private System.Windows.Forms.ToolStripButton txBtn;
        private System.Windows.Forms.ToolStripButton rxBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton settingsBtn;
        private System.Windows.Forms.ToolStripButton infoBtn;
        private System.Windows.Forms.GroupBox srcGroup;
        private System.Windows.Forms.PictureBox srcPbx;
        private System.Windows.Forms.GroupBox txGroup;
        private System.Windows.Forms.PictureBox txPbx;
        private System.Windows.Forms.GroupBox rxGroup;
        private System.Windows.Forms.PictureBox rxPbx;
        private System.Windows.Forms.ToolStripMenuItem vIDEOCAPTUREDEVICEToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox videoCaptureDeviceCbx;
        private System.Windows.Forms.ToolStripMenuItem aUDIOINPUTDEVICEToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox audioInputDeviceCbx;
        private System.Windows.Forms.ToolStripMenuItem sAMPLERATEHZToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox sampleRateCbx;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar syncTkb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar sensTkb;
        private System.Windows.Forms.ToolStripButton isSaveFramesBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TrackBar interframePauseTkb;
    }
}

