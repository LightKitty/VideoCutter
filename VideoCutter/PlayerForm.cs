using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoCutter
{
    public partial class PlayerForm : Form
    {
        string videoPath = null;
        DateTime videoStartDateTime = new DateTime();
        string startTimeText = string.Empty;
        string endTimeText = string.Empty;
        long? lastTime = null;
        //DateTime cutVideoStartDateTime = new DateTime();
        //long cutStartTime = 0;
        //long cutEndTime = 0;

        public PlayerForm()
        {
            InitializeComponent();
        }

        private void vlcControl1_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;

            if (currentDirectory == null)
                return;
            if (IntPtr.Size == 4)
                e.VlcLibDirectory = new DirectoryInfo(Path.GetFullPath(@".\libvlc\win-x86\"));
            else
                e.VlcLibDirectory = new DirectoryInfo(Path.GetFullPath(@".\libvlc\win-x64\"));

            if (!e.VlcLibDirectory.Exists)
            {
                var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
                folderBrowserDialog.Description = "Select Vlc libraries folder.";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
                folderBrowserDialog.ShowNewFolderButton = true;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    e.VlcLibDirectory = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                }
            }
        }

        private void 打开文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                RestoreDirectory = true,
                Multiselect = false,
                Title = "请选择视频",
                Filter = "视频(*.flv;*.mp4)|*.flv;*.mp4|所有文件(*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                videoPath = openFileDialog.FileName;
                videoStartDateTime = GetDateTimeFromFileName(openFileDialog.FileName);
                vlcControl.SetMedia(new FileInfo(openFileDialog.FileName));
                vlcControl.Play();
                ToLastTime(); //恢复播放进度
            }
        }

        private void ToLastTime()
        {
            if (lastTime > 0)
            {
                vlcControl.Time = (long)lastTime;
                ShowTip("已恢复到上次播放进度");
            }
        }

        private DateTime GetDateTimeFromFileName(string fileName)
        {
            string[] strs = Path.GetFileNameWithoutExtension(fileName).Split('-');
            string timeStr = $"{strs[0]}/{strs[1]}/{strs[2]} {strs[3].Substring(0, 2)}:{strs[3].Substring(2, 2)}:{strs[4]}";
            return DateTime.Parse(timeStr);
        }

        private void vlcControl_LengthChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerLengthChangedEventArgs e)
        {
            string timeTotalText = RevertToTime(vlcControl.Length);
            this.BeginInvoke(new Action(() =>
            {
                timeTotalLable.Text = timeTotalText;
            }));
        }

        private string RevertToTime(long time)//转换为时分秒格式
        {
            long hour = 0;
            long minute = 0;
            long second = 0;

            second = time / 1000;

            if (second > 60)
            {
                minute = second / 60;
                second = second % 60;
            }
            if (minute > 60)
            {
                hour = minute / 60;
                minute = minute % 60;
            }
            return (hour.ToString() + ":"
                    + minute.ToString("D2") + ":"
                    + second.ToString("D2"));
        }

        private void vlcControl_TimeChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerTimeChangedEventArgs e)
        {
            SetVideoTrackBar(e.NewTime);
        }

        private void SetVideoTrackBar(long time)
        {
            string timeNowStr = RevertToTime(time);
            int videoProcess = Convert.ToInt32(((double)time / vlcControl.Length) * videoTrackBar.Maximum);
            this.BeginInvoke(new Action(() =>
            {
                if (this.IsHandleCreated)
                {
                    timeNowLabel.Text = timeNowStr;
                    videoTrackBar.Value = videoProcess;
                }
            }));
        }

        private void videoTrackBar_Scroll(object sender, EventArgs e)
        {
            double videoProcess = (double)videoTrackBar.Value / videoTrackBar.Maximum;
            long time = Convert.ToInt64(videoProcess * vlcControl.Length);
            vlcControl.Time = time;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    vlcControl.Pause();
                    break;
                case Keys.Left:
                    long timeReduce = vlcControl.Time - 10000;
                    if (timeReduce < 0) timeReduce = 0;
                    vlcControl.Time = timeReduce;
                    break;
                case Keys.Right:
                    long timeAdd = vlcControl.Time + 10000;
                    if (timeAdd > vlcControl.Length) timeAdd = vlcControl.Length;
                    vlcControl.Time = timeAdd;
                    break;
            }
        }

        private void videoTrackBar_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                    e.Handled = true;
                    return;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)//取消方向键对控件的焦点的控件，用自己自定义的函数处理各个方向键的处理函数
        {
            switch (keyData)
            {
                case Keys.Up:
                    UpKey();
                    return true;//不继续处理
                case Keys.Down:
                    DownKey();
                    return true;
                case Keys.Left:
                    LeftKey();
                    return true;
                case Keys.Control | Keys.Left:
                    CtrlLeftKey();
                    return true;
                case Keys.Shift | Keys.Left:
                    ShiftLeftKey();
                    return true;
                case Keys.Right:
                    RightKey();
                    return true;
                case Keys.Control | Keys.Right:
                    CtrlRightKey();
                    return true;
                case Keys.Shift | Keys.Right:
                    ShiftRightKey();
                    return true;
                case Keys.Space:
                    SpaceKey();
                    return true;
                case Keys.Enter:
                    StartCut();
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SpaceKey()
        {
            vlcControl.Pause();
        }

        private void UpKey()
        {
            
        }

        private void DownKey()
        {
            
        }

        private void LeftKey()
        {
            VlcTimeAdd(-10000);
        }

        private void CtrlLeftKey()
        {
            VlcTimeAdd(-60000);
        }

        private void ShiftLeftKey()
        {
            VlcTimeAdd(-1000);
        }

        private void RightKey()
        {
            VlcTimeAdd(10000);
        }

        private void CtrlRightKey()
        {
            VlcTimeAdd(60000);
        }

        private void ShiftRightKey()
        {
            VlcTimeAdd(1000);
        }

        private void VlcTimeAdd(long addTime)
        {
            long timeAdd = vlcControl.Time + addTime;
            if (timeAdd < 0) timeAdd = 0;
            if (timeAdd > vlcControl.Length) timeAdd = vlcControl.Length;
            vlcControl.Time = timeAdd;
            SetVideoTrackBar(vlcControl.Time);
        }


        private void SetStartTimeText()
        {
            startTimeText = RevertToTime(vlcControl.Time);
            ShowTip($"入点 {startTimeText}");
        }

        private void SetEndTimeText()
        {
            endTimeText = RevertToTime(vlcControl.Time);
            ShowTip($"出点 {endTimeText}");
        }

        private void StartCut()
        {
            try
            {
                TimeSpan timeSpan = GetTimeSpan();
                string cutVideoPath = $"{Path.GetDirectoryName(videoPath)}\\{videoStartDateTime.Add(timeSpan).ToString("yyyyMMdd_HHmmss")}.mp4";
                string comCommand = $"ffmpeg -i \"{videoPath}\" -vcodec copy -acodec copy -ss {startTimeText} -to {endTimeText} \"{cutVideoPath}\" &exit";
                CmdHelper.CmdCommandV2(comCommand);
                ShowTip($"开始裁剪 {startTimeText} - {endTimeText}");
            }
            catch (Exception ex)
            {
                ShowTip($"裁剪错误：{ex.Message}");
            }
            
        }

        private void ShowTip(string text)
        {
            toolStripStatusLabel.Text = text;
        }

        private TimeSpan GetTimeSpan()
        {
            string[] timeStrArr = startTimeText.Trim().Split(':');
            int[] timeIntArr = new int[3];
            for (int i = 0; i < timeStrArr.Length; i++)
            {
                timeIntArr[3 - timeStrArr.Length + i] = Convert.ToInt32(timeStrArr[i]);
            }
            int day = timeIntArr[0] / 24;
            if (timeIntArr[0] > 0) timeIntArr[0] %= 24;
            return new TimeSpan(day, timeIntArr[0], timeIntArr[1], timeIntArr[2]);
        }

        private void 入点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetStartTimeText();
        }

        private void 出点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetEndTimeText();
        }

        private void 裁剪ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartCut();
        }

        private void vlcControl_MediaChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerMediaChangedEventArgs e)
        {
            string title = e?.NewMedia?.Title;
            this.Text = title;

            if(!string.IsNullOrEmpty(title))
            {
                lastTime = VideoPlayTimeHelper.GetVideoPlayTime(title);
            }
        }

        private void PlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //记录视频播放时间
            string title = vlcControl?.GetCurrentMedia()?.Title;
            if(!string.IsNullOrEmpty(title))
            {
                VideoPlayTimeHelper.SaveVideoPlayTime(title, vlcControl.Time);
            }
        }
    }
}
