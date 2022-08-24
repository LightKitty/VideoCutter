using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoCutter
{
    static class VideoPlayTimeHelper
    {
        const string filePath = "videoPlayTime.ini";

        public static long? GetVideoPlayTime(string videoName)
        {
            Dictionary<string, long> dic = ReadTimeDic();
            long time = 0;
            if(dic?.TryGetValue(videoName, out time) == true)
            {
                return time;
            }
            else
            {
                return null;
            }
        }

        public static void SaveVideoPlayTime(string videoName, long time)
        {
            if (!File.Exists(filePath))
            {
                string text = $"{videoName} {time}";
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    streamWriter.Write(text);
                }
            }
            else
            {
                Dictionary<string, long> dic = ReadTimeDic();
                dic[videoName] = time;
                SaveTimeDic(dic);
            }
        }

        private static Dictionary<string, long> ReadTimeDic()
        {
            Dictionary<string, long> dic = new Dictionary<string, long>();
            if(File.Exists(filePath))
            {
                using (StreamReader streamReader = new StreamReader(filePath))
                {
                    string line = null;
                    line = streamReader.ReadLine();
                    while (!string.IsNullOrEmpty(line))
                    {
                        string[] texts = line.Split(' ');
                        long value = 0;
                        if (texts?.Length > 1 && long.TryParse(texts[1], out value))
                        {
                            dic[texts[0]] = value;
                        }
                        line = streamReader.ReadLine();
                    }
                    streamReader.Close();
                }
            }
            return dic;
        }

        private static void SaveTimeDic(Dictionary<string, long> dic)
        {
            if (dic.Count > 100)
            { //最多保存100个
                dic.Remove(dic.Keys.First());
            }
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                foreach (var pair in dic)
                {
                    streamWriter.WriteLine($"{pair.Key} {pair.Value}");
                }
            }
        }
    }
}
