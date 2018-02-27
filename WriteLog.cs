using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TGNoticeServer
{
    public class WriteLog
    {
        /// <summary>
        /// 保存日志的文件夹
        /// </summary>
        private static string logPath = Application.StartupPath + @"\SystemLog";
       
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="strFuncation">功能模块</param>
        /// <param name="strSql">报错语句</param>
        /// <param name="strException">异常提示</param>
        public static void WriteLogMessage(string strFuncation, string strException, String Subdirectory = "")
        {
            try
            {
                bool boolFile = Directory.Exists(logPath);
                if (boolFile == false)
                {
                    Directory.CreateDirectory(logPath);
                }
                
                StreamWriter sw;
                string fileName = logPath + @"\" + (string.IsNullOrEmpty(Subdirectory) ? "" : (@"\" + Subdirectory + @"\")) ;
                if (!Directory.Exists(fileName))
                {
                    Directory.CreateDirectory(fileName);//创建新路径
                }
                fileName = fileName + DateTime.Now.ToString("yyyyMMdd") + ".Log";
                boolFile = File.Exists(fileName);
                if (boolFile == true)
                {
                    sw = File.AppendText(fileName);
                }
                else
                {
                    sw = File.CreateText(fileName);
                }

                StringBuilder sb = new StringBuilder();
                sb.Append("\r\n---------------------------------------------------------------\r\n");
                sb.Append("\r\n报错时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n");
                sb.Append("\r\n功能模块：" + strFuncation + "\r\n");
                sb.Append("\r\n异常提示：" + strException + "\r\n");
                sb.Append("\r\n---------------------------------------------------------------\r\n");
                sw.WriteLine(sb.ToString());
                sw.Close();
            }
            catch (Exception ex)
            {
            }
        }



        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="strMessage">日志内容</param>
        public static void WriteTxtMessage(string strMessage, String Subdirectory = "")
        {
            try
            {
                bool boolFile = Directory.Exists(logPath);
                if (boolFile == false)
                {
                    Directory.CreateDirectory(logPath);
                }

                StreamWriter sw;
                string fileName = logPath + @"\" + (string.IsNullOrEmpty(Subdirectory) ? "" : (@"\" + Subdirectory + @"\"));
                if (!Directory.Exists(fileName))
                {
                    Directory.CreateDirectory(fileName);//创建新路径
                }
                fileName = fileName + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                boolFile = File.Exists(fileName);
                if (boolFile == true)
                {
                    sw = File.AppendText(fileName);
                }
                else
                {
                    sw = File.CreateText(fileName);
                }

                StringBuilder sb = new StringBuilder();
                sb.Append("\r\n---------------------------------------------------------------\r\n");
                sb.Append("\r\n时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n");
                sb.Append("\r\n内容：" + strMessage + "\r\n");
                sb.Append("\r\n---------------------------------------------------------------\r\n");
                sw.WriteLine(sb.ToString());
                sw.Close();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
