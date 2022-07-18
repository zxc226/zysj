using System;
using System.Collections.Generic;
using System.Text;

namespace ZYSJBal
{
    public class LOCK
    {
        /// <summary>
        /// 转换矩阵
        /// </summary>
        private static string[,] matrix = new string[26, 26];
        /// <summary>
        /// ASCIIEncoding
        /// </summary>
        private static ASCIIEncoding ascii = new ASCIIEncoding();
        /// <summary>
        /// 判断工具类是否已初始化 true：已初始化，false未初始化
        /// </summary>
        private static bool isInit = false;
        /// <summary>
        /// 初始化工具类
        /// </summary>
        private static void InitVigenereHelper()
        {
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    int num = i + j + 65;
                    num = num <= 90 ? num : num - 26;
                    byte[] barray = new byte[] { (byte)num };
                    matrix[i, j] = ascii.GetString(barray);
                }
            }
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="text">明文</param>
        /// <param name="key">密钥</param>
        /// <returns>密文</returns>
        public string Encrypt(string text, string key)
        {
            if (!isInit) InitVigenereHelper();
            if (string.IsNullOrWhiteSpace(text)) return "";
            if (string.IsNullOrWhiteSpace(key)) throw new Exception("密钥无效");

            string code = "";
            key = key.ToUpper();
            text = text.ToUpper();

            List<int> keyNumList = new List<int>(); ;
            for (int i = 0; i < key.Length; i++)
            {
                string str = key.Substring(i, 1);
                keyNumList.Add((int)ascii.GetBytes(str)[0] - 65);
            }
            int idx = -1;
            for (int i = 0; i < text.Length; i++)
            {
                if (text.Substring(i, 1).ToString() == " ")
                {
                    code += " ";
                    continue;
                }
                idx++;
                code += matrix[keyNumList[idx % key.Length], (int)ascii.GetBytes(text.Substring(i, 1))[0] - 65];
            }
            return code.ToString();
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="code">密文</param>
        /// <param name="key">密钥</param>
        /// <returns>明文</returns>
        public string Decrypt(string code, string key)
        {
            if (!isInit) InitVigenereHelper();
            if (string.IsNullOrWhiteSpace(code)) return "";
            if (string.IsNullOrWhiteSpace(key)) throw new Exception("密钥无效");

            string text = "";
            key = key.ToString().ToUpper();
            code = code.ToString().ToUpper();

            List<int> keyNumList = new List<int>();
            for (int i = 0; i < key.Length; i++)
            {
                string str = key.Substring(i, 1);
                keyNumList.Add((int)ascii.GetBytes(str)[0] - 65);
            }

            int idx = -1;
            for (int i = 0; i < code.Length; i++)
            {
                if (code.Substring(i, 1).ToString() == " ")
                {
                    text += " ";
                    continue;
                }
                idx++;

                for (int j = 0; j < 26; j++)
                {
                    if (code.Substring(i, 1).ToString() == matrix[keyNumList[idx % key.Length], j])
                    {
                        byte[] bt = new byte[] { (byte)(j + 65) };
                        text += ascii.GetString(bt);
                    }
                }
            }

            return text.ToString();
        }
    }
}
