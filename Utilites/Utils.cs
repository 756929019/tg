using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CYQ.Data;

namespace TGNoticeServer.Utilites
{
    public class Utils
    {
        /// <summary>
        /// 获取GUID
        /// </summary>
        /// <returns></returns>
        public static String GUID()
        {
            return System.Guid.NewGuid().ToString().ToUpper();
        }

        /// <summary>
        /// 获取数据库时间，默认格式2016-06-22 14:33:19
        /// </summary>
        /// <param name="mode">显示模式:20（2016-06-22 14:33:19） 23（2016-06-22） </param>
        /// <returns></returns>
        public static String DBDateTime(int mode = 20)
        {
            using (MAction action = new MAction(string.Format("(Select CONVERT(varchar(100), GETDATE(), {0}) field) V", mode)))
            {
                return action.Select().GetString(0);
            }
        }

        /// <summary>
        /// 获取数据库时间
        /// </summary>
        /// <returns></returns>
        public static DateTime DBSysTime()
        {
            using (MAction action = new MAction("(Select GETDATE() field) V"))
            {
                return action.Select().GetDateTime(0);
            }
        }

        /// <summary>
        /// 格式化日期时间
        /// </summary>
        /// <param name="dt">日期时间</param>
        /// <param name="mode">显示模式</param>
        /// <returns>0-8种模式的日期</returns>
        public static string GetFormatDateTime(DateTime dt, string mode = "1")
        {
            switch (mode)
            {
                case "0":
                    return dt.ToString("yyyy-MM-dd");
                case "1":
                    return dt.ToString("yyyy-MM-dd HH:mm:ss");
                case "2":
                    return dt.ToString("yyyy/MM/dd");
                case "3":
                    return dt.ToString("yyyy/MM/dd HH:mm:ss");
                case "4":
                    return dt.ToString("yyyy年MM月dd日");
                case "5":
                    return dt.ToString("yyyy年MM月dd日 HH:mm:ss");
                case "6":
                    return dt.ToString("yyyy-MM");
                case "7":
                    return dt.ToString("yyyy/MM");
                case "8":
                    return dt.ToString("yyyy年MM月");
                case "9":
                    return dt.ToString("yyyyMM");
                case "10":
                    return dt.ToString("yyyyMMddHHmmss");
                case "11":
                    return dt.ToString("yyyy");
                case "12":
                    return dt.ToString("MM");
                case "13":
                    return dt.ToString("yyyyMMdd");
                default:
                    return dt.ToString();
            }
        }

        /// <summary>
        /// 将时间格式化成年月日的形式,如果时间为null，返回""
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <param name="Separator">年月日分隔符</param>
        /// <returns></returns>
        public static string GetFormatDate(DateTime dt, char Separator = '-')
        {
            if (dt != null && !dt.Equals(DBNull.Value))
            {
                string temp = string.Format("yyyy{0}MM{0}dd", Separator);
                return dt.ToString(temp);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 将时间格式化成时分秒的形式,如果时间为null，返回""
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <param name="Separator">时分秒分隔符</param>
        /// <returns></returns>
        public static string GetFormatTime(DateTime dt, char Separator = ':')
        {
            if (dt != null && !dt.Equals(DBNull.Value))
            {
                string tem = string.Format("hh{0}mm{0}ss", Separator);
                return dt.ToString(tem);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 获取当前工作月
        /// </summary>
        /// <returns></returns>
        public static String WorkMonth()
        {
            try
            {
                using (MAction action = new MAction("(SELECT TOP 1 WorkMonth FROM WorkMonth WHERE Status = 0 ORDER BY WorkMonth)V"))
                {
                    return action.Select().GetString(0);
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
