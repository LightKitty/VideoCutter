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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vlcControl = new Vlc.DotNet.Forms.VlcControl();
            this.videoTrackBar = new System.Windows.Forms.TrackBar();
            this.timeNowLabel = new System.Windows.Forms.Label();
            this.timeTotalLable = new System.Windows.Forms.Label();
            this.startTimeTextBox = new System.Windows.Forms.TextBox();
            this.endTimeTextBox = new System.Windows.Forms.TextBox();
            this.startTimeButton = new System.Windows.Forms.Button();
            this.endTimeButton = new System.Windows.Forms.Button();
            this.cutButton = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem});
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
            // vlcControl
            // 
            this.vlcControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vlcControl.BackColor = System.Drawing.Color.Black;
            this.vlcControl.Location = new System.Drawing.Point(0, 28);
            this.vlcControl.Name = "vlcControl";
            this.vlcControl.Size = new System.Drawing.Size(1280, 724);
            this.vlcControl.Spu = -1;
            this.vlcControl.TabIndex = 1;
            this.vlcControl.Text = "vlcControl";
            this.vlcControl.VlcLibDirectory = null;
            this.vlcControl.VlcMediaplayerOptions = null;
            this.vlcControl.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl1_VlcLibDirectoryNeeded);
            this.vlcControl.LengthChanged += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerLengthChangedEventArgs>(this.vlcControl_LengthChanged);
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
            this.timeNowLabel.Location = new System.Drawing.Point(12, 755);
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
            this.timeTotalLable.Location = new System.Drawing.Point(1212, 755);
            this.timeTotalLable.Name = "timeTotalLable";
            this.timeTotalLable.Size = new System.Drawing.Size(56, 17);
            this.timeTotalLable.TabIndex = 4;
            this.timeTotalLable.Text = "00:00:00";
            this.timeTotalLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // startTimeTextBox
            // 
            this.startTimeTextBox.Location = new System.Drawing.Point(277, 805);
            this.startTimeTextBox.Name = "startTimeTextBox";
            this.startTimeTextBox.Size = new System.Drawing.Size(75, 23);
            this.startTimeTextBox.TabIndex = 7;
            // 
            // endTimeTextBox
            // 
            this.endTimeTextBox.Location = new System.Drawing.Point(439, 805);
            this.endTimeTextBox.Name = "endTimeTextBox";
            this.endTimeTextBox.Size = new System.Drawing.Size(75, 23);
            this.endTimeTextBox.TabIndex = 8;
            // 
            // startTimeButton
            // 
            this.startTimeButton.Location = new System.Drawing.Point(221, 805);
            this.startTimeButton.Name = "startTimeButton";
            this.startTimeButton.Size = new System.Drawing.Size(50, 23);
            this.startTimeButton.TabIndex = 9;
            this.startTimeButton.Text = "入点";
            this.startTimeButton.UseVisualStyleBackColor = true;
            this.startTimeButton.Click += new System.EventHandler(this.startTimeButton_Click);
            // 
            // endTimeButton
            // 
            this.endTimeButton.Location = new System.Drawing.Point(383, 805);
            this.endTimeButton.Name = "endTimeButton";
            this.endTimeButton.Size = new System.Drawing.Size(50, 23);
            this.endTimeButton.TabIndex = 10;
            this.endTimeButton.Text = "出点";
            this.endTimeButton.UseVisualStyleBackColor = true;
            this.endTimeButton.Click += new System.EventHandler(this.endTimeButton_Click);
            // 
            // cutButton
            // 
            this.cutButton.Location = new System.Drawing.Point(535, 805);
            this.cutButton.Name = "cutButton";
            this.cutButton.Size = new System.Drawing.Size(50, 23);
            this.cutButton.TabIndex = 11;
            this.cutButton.Text = "裁剪";
            this.cutButton.UseVisualStyleBackColor = true;
            this.cutButton.Click += new System.EventHandler(this.cutButton_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(102, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(15, 796);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 43);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // PlayerForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 884);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cutButton);
            this.Controls.Add(this.endTimeButton);
            this.Controls.Add(this.startTimeButton);
            this.Controls.Add(this.endTimeTextBox);
            this.Controls.Add(this.startTimeTextBox);
            this.Controls.Add(this.timeTotalLable);
            this.Controls.Add(this.timeNowLabel);
            this.Controls.Add(this.videoTrackBar);
            this.Controls.Add(this.vlcControl);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PlayerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.TextBox startTimeTextBox;
        private System.Windows.Forms.TextBox endTimeTextBox;
        private System.Windows.Forms.Button startTimeButton;
        private System.Windows.Forms.Button endTimeButton;
        private System.Windows.Forms.Button cutButton;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

