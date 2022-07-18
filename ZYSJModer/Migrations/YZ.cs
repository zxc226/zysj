using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace ZYSJModer.Migrations
{
    public class YZ
    {
        public string yzxx{ get; set; }
        public string yzjg { get; set; }

        private static YZ cxy = new YZ();

        public bool GetEmailYZ(string yz)
        {
            string yzm = "";
            Random random = new Random();
            for (int i = 0; i <= 3; i++)
            {
                yzm  += random.Next(100, 999).ToString();
                if (i<2)
                {
                    yzm = yzm + "-";
                }
            }
            
            string ZCYZM = string.Format("{0},{1}", yz, yzm);
            var picTimePath = Directory.GetCurrentDirectory()+ "\\obj\\Debug\\myEmailFS.exe";
            StartProcc(picTimePath, ZCYZM);
            cxy.yzxx = yzm;
            return true;
        }


        public static void StartProcc(string path, string yzm)
        {
                string debugPath = System.Environment.CurrentDirectory + "\\obj\\Debug\\myEmailFS.exe";           //此c#项目的debug文件夹路径
                //string pyexePath = @"C:\Users\user\Desktop\test\dist\main.exe";
                //python文件所在路径，一般不使用绝对路径，此处仅作为例子，建议转移到debug文件夹下

                Process p = new Process();
                p.StartInfo.FileName = debugPath;//需要执行的文件路径
                p.StartInfo.UseShellExecute = false; //必需
                p.StartInfo.RedirectStandardOutput = true;//输出参数设定
                p.StartInfo.RedirectStandardInput = true;//传入参数设定
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.Arguments = yzm;//参数以空格分隔，如果某个参数为空，可以传入””
                p.Start();
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();//关键，等待外部程序退出后才能往下执行}
                Console.Write(output);//输出
                
                p.Close();

        }

        public static string GetZCYZM()
        {
            return YZ.cxy.yzxx;
        }

    }
}
