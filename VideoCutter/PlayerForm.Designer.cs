namespace VideoCutter
{
    partial class PlayerForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.入点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.出点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.裁剪ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vlcControl = new Vlc.DotNet.Forms.VlcControl();
            this.videoTrackBar = new System.Windows.Forms.TrackBar();
            this.timeNowLabel = new System.Windows.Forms.Label();
            this.timeTotalLable = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoTrackBar)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.入点ToolStripMenuItem,
            this.出点ToolStripMenuItem,
            this.裁剪ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1280, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开文件ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "媒体";
            // 
            // 打开文件ToolStripMenuItem
            // 
            this.打开文件ToolStripMenuItem.Name = "打开文件ToolStripMenuItem";
            this.打开文件ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.打开文件ToolStripMenuItem.Text = "打开文件";
            this.打开文件ToolStripMenuItem.Click += new System.EventHandler(this.打开文件ToolStripMenuItem_Click);
            // 
            // 入点ToolStripMenuItem
            // 
            this.入点ToolStripMenuItem.Name = "入点ToolStripMenuItem";
            this.入点ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.入点ToolStripMenuItem.Text = "入点";
            this.入点ToolStripMenuItem.Click += new System.EventHandler(this.入点ToolStripMenuItem_Click);
            // 
            // 出点ToolStripMenuItem
            // 
            this.出点ToolStripMenuItem.Name = "出点ToolStripMenuItem";
            this.出点ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.出点ToolStripMenuItem.Text = "出点";
            this.出点ToolStripMenuItem.Click += new System.EventHandler(this.出点ToolStripMenuItem_Click);
            // 
            // 裁剪ToolStripMenuItem
            // 
            this.裁剪ToolStripMenuItem.Name = "裁剪ToolStripMenuItem";
            this.裁剪ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.裁剪ToolStripMenuItem.Text = "裁剪";
            this.裁剪ToolStripMenuItem.Click += new System.EventHandler(this.裁剪ToolStripMenuItem_Click);
            // 
            // vlcControl
            // 
            this.vlcControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vlcControl.BackColor = System.Drawing.Color.Black;
            this.vlcControl.Location = new System.Drawing.Point(0, 28);
            this.vlcControl.Name = "vlcControl";
            this.vlcControl.Size = new System.Drawing.Size(1280, 720);
            this.vlcControl.Spu = -1;
            this.vlcControl.TabIndex = 1;
            this.vlcControl.Text = "vlcControl";
            this.vlcControl.VlcLibDirectory = null;
            this.vlcControl.VlcMediaplayerOptions = null;
            this.vlcControl.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl1_VlcLibDirectoryNeeded);
            this.vlcControl.LengthChanged += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerLengthChangedEventArgs>(this.vlcControl_LengthChanged);
            this.vlcControl.MediaChanged += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerMediaChangedEventArgs>(this.vlcControl_MediaChanged);
            this.vlcControl.TimeChanged += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerTimeChangedEventArgs>(this.vlcControl_TimeChanged);
            // 
            // videoTrackBar
            // 
            this.videoTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoTrackBar.Location = new System.Drawing.Point(74, 754);
            this.videoTrackBar.Maximum = 1000;
            this.videoTrackBar.Name = "videoTrackBar";
            this.videoTrackBar.Size = new System.Drawing.Size(1132, 45);
            this.videoTrackBar.TabIndex = 2;
            this.videoTrackBar.TickFrequency = 10;
            this.videoTrackBar.Scroll += new System.EventHandler(this.videoTrackBar_Scroll);
            this.videoTrackBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.videoTrackBar_KeyDown);
            // 
            // timeNowLabel
            // 
            this.timeNowLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.timeNowLabel.AutoSize = true;
            this.timeNowLabel.Location = new System.Drawing.Point(12, 754);
            this.timeNowLabel.Name = "timeNowLabel";
            this.timeNowLabel.Size = new System.Drawing.Size(56, 17);
            this.timeNowLabel.TabIndex = 3;
            this.timeNowLabel.Text = "00:00:00";
            this.timeNowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timeTotalLable
            // 
            this.timeTotalLable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.timeTotalLable.AutoSize = true;
            this.timeTotalLable.Location = new System.Drawing.Point(1212, 754);
            this.timeTotalLable.Name = "timeTotalLable";
            this.timeTotalLable.Size = new System.Drawing.Size(56, 17);
            this.timeTotalLable.TabIndex = 4;
            this.timeTotalLable.Text = "00:00:00";
            this.timeTotalLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 799);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1280, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel.Text = "就绪";
            // 
            // PlayerForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 821);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.timeTotalLable);
            this.Controls.Add(this.timeNowLabel);
            this.Controls.Add(this.videoTrackBar);
            this.Controls.Add(this.vlcControl);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PlayerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "视频裁剪助手";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayerForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoTrackBar)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private Vlc.DotNet.Forms.VlcControl vlcControl;
        private System.Windows.Forms.TrackBar videoTrackBar;
        private System.Windows.Forms.Label timeNowLabel;
        private System.Windows.Forms.Label timeTotalLable;
        private System.Windows.Forms.ToolStripMenuItem 打开文件ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem 入点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 出点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 裁剪ToolStripMenuItem;
    }
}

