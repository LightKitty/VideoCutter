using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoCutter
{
    public static class CmdHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static Process CmdCommand(string command)
        {
            Process p = new Process();
            //设置要启动的应用程序
            p.StartInfo.FileName = "cmd.exe";
            //是否使用操作系统shell启动
            p.StartInfo.UseShellExecute = false;
            // 接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardInput = true;
            //输出信息
            p.StartInfo.RedirectStandardOutput = false;
            // 输出错误
            p.StartInfo.RedirectStandardError = false;
            //不显示程序窗口
            //p.StartInfo.CreateNoWindow = true;
            //启动程序
            p.Start();

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(command);

            p.StandardInput.AutoFlush = true;

            //获取输出信息
            //string strOuput = p.StandardOutput.ReadToEnd();
            ////等待程序执行完退出进程
            //p.WaitForExit();
            //p.Close();
            return p;
        }

        public static Process CmdCommandV2(string command)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = " /k " + command;
            process.Start();
            return process;
        }
    }
}
