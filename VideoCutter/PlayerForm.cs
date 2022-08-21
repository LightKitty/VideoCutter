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
            string timeNowStr = RevertToTime(e.NewTime);
            int videoProcess = Convert.ToInt32(((double)e.NewTime / vlcControl.Length) * videoTrackBar.Maximum);
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

        private void startTimeButton_Click(object sender, EventArgs e)
        {
            string timeNowStr = RevertToTime(vlcControl.Time);
            startTimeTextBox.Text = timeNowStr;
        }

        private void endTimeButton_Click(object sender, EventArgs e)
        {
            string timeNowStr = RevertToTime(vlcControl.Time);
            endTimeTextBox.Text = timeNowStr;
        }

        private void cutButton_Click(object sender, EventArgs e)
        {
            TimeSpan timeSpan = GetTimeSpan();
            string cutVideoPath = $"{Path.GetDirectoryName(videoPath)}\\{videoStartDateTime.Add(timeSpan).ToString("yyyyMMdd_HHmmss")}.mp4";
            string comCommand = $"ffmpeg -i \"{videoPath}\" -vcodec copy -acodec copy -ss {startTimeTextBox.Text} -to {endTimeTextBox.Text} \"{cutVideoPath}\" &exit";
            CmdHelper.CmdCommandV2(comCommand);
            //MessageBox.Show("开始裁剪视频");
        }

        private TimeSpan GetTimeSpan()
        {
            string[] timeStrArr = startTimeTextBox.Text.Trim().Split(':');
            int[] timeIntArr = new int[3];
            for (int i = 0; i < timeStrArr.Length; i++)
            {
                timeIntArr[3 - timeStrArr.Length + i] = Convert.ToInt32(timeStrArr[i]);
            }
            int day = timeIntArr[0] / 24;
            if (timeIntArr[0] > 0) timeIntArr[0] %= 24;
            return new TimeSpan(day, timeIntArr[0], timeIntArr[1], timeIntArr[2]);
        }
    }
}
