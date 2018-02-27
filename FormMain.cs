using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TGNoticeServer.Utilites;
using System.Threading;
using CYQ.Data;
using CYQ.Data.Table;
using System.Data.SqlClient;
using System.Net;
using System.IO;

namespace TGNoticeServer
{
    public partial class FormMain : Form
    {
        private string WeChatDB = "";
        private Int32 ServerSleepTime = 60000;
        private Int32 WorkCount = 2;
        private string ServerStartTime = "";
        private string ServerEndTime = "";
        private string ServerSendStartTime = "";
        private string SendUrl = "";
        private string Remark1 = "";
        private string Remark2 = "";

        private string J_ServerStartTime = "";
        private string J_ServerEndTime = "";
        private string J_ServerSendStartTime = "";
        private string J_SendUrl = "";
        private string J_Remark1 = "";
        private string J_Remark2 = "";
        private Int32 J_Month = 3;

        private string workMonth = "";
        private bool workMonthIsCreateNotice = false;
        private bool workMonthIsSendNotice = false;

        private string j_workMonth = "";
        private bool j_workMonthIsCreateNotice = false;
        private bool j_workMonthIsSendNotice = false;


        //处理数据的线程
        Thread serverThread;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //获取数据库连接
            WeChatDB = new Encrypt().DecryptString(System.Configuration.ConfigurationManager.AppSettings["WeChatDB"].ToString());
            ServerSleepTime = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["ServerSleepTime"].ToString()) * 60 * 1000;
            WorkCount = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["WorkCount"].ToString());
            ServerStartTime = System.Configuration.ConfigurationManager.AppSettings["ServerStartTime"].ToString();
            ServerEndTime = System.Configuration.ConfigurationManager.AppSettings["ServerEndTime"].ToString();
            ServerSendStartTime = System.Configuration.ConfigurationManager.AppSettings["ServerSendStartTime"].ToString();
            SendUrl = System.Configuration.ConfigurationManager.AppSettings["SendUrl"].ToString();
            Remark1 = System.Configuration.ConfigurationManager.AppSettings["Remark1"].ToString();
            Remark2 = System.Configuration.ConfigurationManager.AppSettings["Remark2"].ToString();

            J_ServerStartTime = System.Configuration.ConfigurationManager.AppSettings["J_ServerStartTime"].ToString();
            J_ServerEndTime = System.Configuration.ConfigurationManager.AppSettings["J_ServerEndTime"].ToString();
            J_ServerSendStartTime = System.Configuration.ConfigurationManager.AppSettings["J_ServerSendStartTime"].ToString();
            J_SendUrl = System.Configuration.ConfigurationManager.AppSettings["J_SendUrl"].ToString();
            J_Remark1 = System.Configuration.ConfigurationManager.AppSettings["J_Remark1"].ToString();
            J_Remark2 = System.Configuration.ConfigurationManager.AppSettings["J_Remark2"].ToString();
            J_Month = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["J_Month"].ToString());
            //ThreadStart();
            //启动线程
            ThreadStart();
        }

        #region 线程处理
        private void ThreadStart()
        {
            if (serverThread == null)
            {
                serverThread = new Thread(ThreadFun);
            }
            rtbText.Text = "数据处理服务开启\r\n";
            serverThread.Start();
        }

        private void ThreadFun()
        {
            while (true)
            {
                DateTime sysTime = DateTime.Now; //Utils.DBSysTime();
                try
                {
                    #region 当月账单
                    DateTime starttime = DateTime.Parse(sysTime.ToString("yyyy-MM") + "-" + ServerStartTime + ":00");
                    DateTime endtime = DateTime.Parse(sysTime.ToString("yyyy-MM") + "-" + ServerEndTime + ":00");
                    DateTime sendstarttime = DateTime.Parse(sysTime.ToString("yyyy-MM") + "-" + ServerSendStartTime + ":00");
                    if (starttime <= sysTime && sysTime <= endtime)
                    {
                        //时间范围内--
                        if (!workMonthIsCreateNotice)
                        {
                            //没有处理数据
                            //查询工作月
                            if (string.IsNullOrEmpty(workMonth))
                            {
                                workMonth = Utils.WorkMonth();
                            }
                            if (!string.IsNullOrEmpty(workMonth))
                            {
                                //判断当前工作月是否已处理
                                #region 查询表结构NoticeDt(如果没有重新创建)
                                DataTable temdt = null;
                                using (MAction action = new MAction("(SELECT OBJECT_ID('WCNotice" + workMonth + "') ObjeId)V", WeChatDB))
                                {
                                    temdt = action.Select().ToDataTable();
                                }
                                //判断是否已经有数据
                                int res = 0;
                                DataTable NoticeDt = null;

                                if (temdt != null && temdt.Rows.Count > 0)
                                {
                                    if (temdt.Rows[0]["ObjeId"] == null || temdt.Rows[0]["ObjeId"] == DBNull.Value)
                                    {
                                        //新建表
                                        //创建表
                                        using (MProc proc = new MProc("CreateTabWCNotice", WeChatDB))
                                        {
                                            proc.Set("WorkMonth", workMonth);
                                            proc.ExeNonQuery();
                                        }
                                        using (MAction action = new MAction("WCNotice" + workMonth + "", WeChatDB))
                                        {
                                            NoticeDt = action.Select("1=2").ToDataTable();
                                        }
                                        ConsoleAppend("创建表WCNotice" + workMonth + "完成");
                                    }
                                    else
                                    {
                                        using (MAction action = new MAction("WCNotice" + workMonth + "", WeChatDB))
                                        {
                                            res = action.GetCount("NoticeType='1'");
                                            NoticeDt = action.Select("1=2").ToDataTable();
                                        }
                                        ConsoleAppend("本月条数" + res);
                                    }
                                }
                                #endregion

                                if (res > 0)
                                {
                                    //本月已经处理
                                    #region 标记已经处理
                                    workMonthIsCreateNotice = true;
                                    using (MAction action = new MAction("WCNotice" + workMonth + "", WeChatDB))
                                    {
                                        res = action.GetCount("NoticeType='1' AND IsFinish = 1");
                                        if (res > 0)
                                        {
                                            //本月已经发送
                                            workMonthIsSendNotice = true;
                                        }
                                        else
                                        {
                                            workMonthIsSendNotice = false;
                                        }
                                    }
                                    #endregion
                                    ConsoleAppend("本月通知单已经生成");
                                }
                                else
                                {
                                    #region 1.转移绑定的用户信息到营业库临时数据
                                    //开始处理数据
                                    string sql = "SELECT OpenId,CustomerID,AccountNumber FROM UserBindInfo WHERE Flag = '0'";//AND OpenId IN ('o4Uz_v3mcR7-kUlzy6cWu5R6h2ZM','o4Uz_v1fJYZkGY2YHgc2l0kDIzVc')
                                    //挪移绑定的openid，只查询绑定范围内的数据
                                    MDataTable bindDt = null;
                                    DataTable bindTmpDt = null;
                                    using (MAction action = new MAction("(" + sql + ")V", WeChatDB))
                                    {
                                        bindDt = action.Select();
                                    }
                                    string con = "";
                                    using (MAction action = new MAction("UserBindInfoTemp"))
                                    {
                                        //清空表
                                        action.BatchDelete("1=1");
                                        action.ResetTable("UserBindInfoTemp");
                                        bindTmpDt = action.Select().ToDataTable();//获取表结构
                                        con = action.ConnectionString;
                                    }
                                    if (bindDt != null && bindDt.Rows.Count > 0)
                                    {
                                        //获取sysdata UserBindInfo表结构
                                        foreach (MDataRow row in bindDt.Rows)
                                        {
                                            DataRow _row = bindTmpDt.NewRow();
                                            _row["OpenId"] = row.Get<string>("OpenId");
                                            _row["CustomerID"] = row.Get<string>("CustomerID");
                                            _row["AccountNumber"] = row.Get<string>("AccountNumber");
                                            _row["BatchNo"] = "";
                                            bindTmpDt.Rows.Add(_row);
                                        }

                                        using (System.Data.SqlClient.SqlBulkCopy bcp = new System.Data.SqlClient.SqlBulkCopy(con, SqlBulkCopyOptions.CheckConstraints))
                                        {
                                            bcp.BatchSize = 100;              //每次传输的行数
                                            bcp.DestinationTableName = "UserBindInfoTemp"; //目标表
                                            bcp.WriteToServer(bindTmpDt, DataRowState.Added);
                                        }
                                    }
                                    else
                                    {
                                        ConsoleAppend("没有绑定的用户");
                                    }
                                    #endregion
                                    ConsoleAppend("转移绑定的用户信息到营业库完成" + bindDt.Rows.Count);

                                    #region 2.查询营业库需要发送的数据 并写入微信库
                                    sql = "";
                                    sql += "SELECT T1.CustomerAddr,T1.CustomerNo";
                                    sql += ",T1.CustomerID,T1.CustomerName";
                                    sql += ",T5.OpenID,T4.Balance,T2.Amount";
                                    sql += ",T2.Charge,T2.NowOweCharge,T3.OweAmount";
                                    sql += ",T3.OweCharge,T3.OweCnt,T3.MinMonth,T3.MaxMonth,ROUTE.Mobile ";
                                    sql += " FROM Customer T1";
                                    //关联微信信息-排除未绑定-获取openid
                                    sql += " LEFT JOIN UserBindInfoTemp T5 ON T1.CustomerID = T5.CustomerID";
                                    //关联本月抄表-排除未绑定-获取本月信息(不包括红蓝笔核销掉的数据)
                                    sql += " LEFT JOIN";
                                    sql += " (SELECT CustomerID,SUM(AccountAmount) Amount,SUM(ReceivableCharge) Charge";
                                    sql += ",SUM(CASE WHEN ProcessingStateID<>'" + WaterConst.ProcessingState.ChargeOff + "' THEN ReceivableCharge ELSE 0.0 END) NowOweCharge";
                                    sql += "  FROM Receivable WHERE ReceivableCharge>0 AND ChargeOffTypeID<>'" + WaterConst.ChargeOffType.RedBluePen + "' ";
                                    sql += " AND AccountMonth = '" + workMonth + "'";
                                    sql += " GROUP BY CustomerID ) T2";
                                    sql += " ON T1.CustomerID = T2.CustomerID";
                                    //关联往月外欠
                                    sql += " LEFT JOIN";
                                    sql += " (SELECT CustomerID,COUNT(ReceivableID) OweCnt";
                                    sql += ",SUM(AccountAmount) OweAmount,SUM(ReceivableCharge) OweCharge";
                                    sql += ",MAX(AccountMonth) MaxMonth,Min(AccountMonth) MinMonth";
                                    sql += " FROM Receivable WHERE ReceivableCharge>0 AND ProcessingStateID<>'" + WaterConst.ProcessingState.ChargeOff + "' ";
                                    sql += " AND AccountMonth < '" + workMonth + "'";
                                    sql += " GROUP BY CustomerID ) T3";
                                    sql += " ON T1.CustomerID = T3.CustomerID";
                                    sql += " LEFT JOIN PrePaidAccount T4 ON T1.CustomerID = T4.CustomerID";
                                    //关联收费路线
                                    sql += " LEFT JOIN";
                                    sql += " (SELECT CustomerID,MAX(Mobile) Mobile FROM (";
                                    sql += " SELECT T1.CustomerID,T3.Mobile FROM dbo.Meter T1, dbo.Customer T2 ";
                                    sql += " ,(SELECT T1.SmallZoneID,T1.MeterKindID,T2.Mobile,T2.Name EmpName ";
                                    sql += " FROM MeterChargeSetting T1 LEFT JOIN Employee T2 ON T1.EmployeeID = T2.EmployeeID";
                                    sql += " WHERE T1.WorkMonth = '" + workMonth + "' AND AdminTypeID = '2')";
                                    sql += " T3 WHERE T1.CustomerID = T2.CustomerID AND T2.SmallZoneID = T3.SmallZoneID AND T1.MeterKindID = T3.MeterKindID ";
                                    sql += " UNION ALL ";
                                    sql += " SELECT CustomerID,T2.Mobile FROM Meter T1 , (";
                                    sql += " SELECT T1.BookNo,T1.AdminTypeID,T2.Mobile,T2.Name EmpName ";
                                    sql += " FROM MeterReadSetting T1 LEFT JOIN Employee T2 ON T1.EmployeeID = T2.EmployeeID";
                                    sql += " WHERE T1.WorkMonth = '" + workMonth + "' AND SettingType = '2' AND AdminTypeID = '1'";
                                    sql += " ) T2 WHERE T1.AdminTypeID = T2.AdminTypeID AND T1.Book = T2.BookNo";
                                    sql += " ) T GROUP BY CustomerID";
                                    sql += " ) ROUTE ON T1.CustomerID = ROUTE.CustomerID";
                                    sql += " ";

                                    sql += " WHERE T5.CustomerID IS NOT NULL";
                                    //本月有抄表或者有历史外欠才推送
                                    sql += " AND (T2.Amount>0 OR T3.OweCnt>0)";
                                    //--AND (T2.NowOweCharge+T3.OweCharge)>T4.Balance
                                    //查询本月应收--以往外欠
                                    MDataTable dbdt = null;
                                    using (MAction action = new MAction("(" + sql + ")V"))
                                    {
                                        dbdt = action.Select();//获取
                                    }
                                    if (dbdt != null && dbdt.Rows.Count > 0)
                                    {
                                        foreach (MDataRow row in dbdt.Rows)
                                        {
                                            DataRow _row = NoticeDt.NewRow();
                                            _row["NoticeNo"] = Utils.GUID();
                                            _row["NoticeType"] = "1";
                                            _row["WorkMonth"] = workMonth;
                                            _row["BatchNo"] = sysTime.ToString("yyyyMMddHHmmss");
                                            _row["OpenID"] = row.Get<string>("OpenID");
                                            _row["CustomerID"] = row.Get<string>("CustomerID");
                                            _row["CustomerNo"] = row.Get<string>("CustomerNo");
                                            _row["CustomerName"] = row.Get<string>("CustomerName");
                                            _row["CustomerAddr"] = row.Get<string>("CustomerAddr");
                                            _row["Amount"] = row.Get<decimal>("Amount");
                                            _row["Charge"] = row.Get<decimal>("Charge");
                                            _row["NowOweCharge"] = row.Get<decimal>("NowOweCharge");
                                            _row["IsChargeOff"] = row.Get<decimal>("NowOweCharge") == row.Get<decimal>("Charge") ? "0" : "1";
                                           string Mobile = row.Get<string>("Mobile");
                                           if (!string.IsNullOrEmpty(Mobile) && Mobile.Trim().Length == 11)
                                           {
                                               Remark2 = string.Format(Remark2, Mobile);
                                           }
                                           else
                                           {
                                               Remark2 = string.Format(Remark2, "[营业厅]");
                                           }
                                            if (string.IsNullOrEmpty(row.Get<string>("MinMonth")))
                                            {
                                                _row["OweMonth"] = "";
                                                _row["OweAmount"] = 0;
                                                _row["OweCharge"] = 0;
                                                _row["OweCnt"] = 0;
                                                _row["Remark"] = Remark2;
                                            }
                                            else
                                            {
                                                if (row.Get<string>("MinMonth") == row.Get<string>("MaxMonth"))
                                                {
                                                    _row["OweMonth"] = row.Get<string>("MinMonth");
                                                }
                                                else
                                                {
                                                    _row["OweMonth"] = row.Get<string>("MinMonth") + " - " + row.Get<string>("MaxMonth");
                                                }
                                                _row["OweAmount"] = row.Get<decimal>("OweAmount");
                                                _row["OweCharge"] = row.Get<decimal>("OweCharge");
                                                _row["OweCnt"] = row.Get<int>("OweCnt");
                                                _row["Remark"] = string.Format(Remark1, row.Get<int>("OweCnt"), row.Get<decimal>("OweCharge"), row.Get<decimal>("OweAmount"), _row["OweMonth"]) + Remark2;
                                            }

                                            _row["Account"] = row.Get<decimal>("Balance");
                                            _row["SendCnt"] = "0";
                                            _row["LastSendTime"] = sysTime.ToString("yyyy-MM-dd HH:mm:ss");
                                            _row["IsFinish"] = "0";
                                            NoticeDt.Rows.Add(_row);
                                        }
                                        #region 把查询出的数据写入微信库
                                        using (System.Data.SqlClient.SqlBulkCopy bcp = new System.Data.SqlClient.SqlBulkCopy(WeChatDB, SqlBulkCopyOptions.CheckConstraints))
                                        {
                                            bcp.BatchSize = 100;              //每次传输的行数
                                            bcp.DestinationTableName = "WCNotice" + workMonth + ""; //目标表
                                            bcp.WriteToServer(NoticeDt, DataRowState.Added);
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        ConsoleAppend("没有需要发送的数据");
                                    }
                                    #endregion
                                    ConsoleAppend("查询营业库需要发送的数据 并写入微信库" + dbdt.Rows.Count);

                                    #region 3.清除营业库临时数据
                                    using (MAction action = new MAction("UserBindInfoTemp"))
                                    {
                                        //清空表
                                        action.BatchDelete("1=1");
                                    }
                                    #endregion
                                    ConsoleAppend("清除营业库临时数据完成");

                                    #region 4.标记处理完成
                                    //处理完成
                                    workMonthIsCreateNotice = true;
                                    workMonthIsSendNotice = false;
                                    #endregion

                                    labLastNum.BeginInvoke((Action)delegate
                                    {
                                        labLastNum.Text = dbdt.Rows.Count + "";
                                    });
                                    labLastTime.BeginInvoke((Action)delegate
                                    {
                                        labLastTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                    });
                                    ConsoleAppend("标记处理完成");
                                }
                            }
                        }
                        else
                        {
                            string _workMonth = Utils.WorkMonth();
                            if (_workMonth != workMonth)
                            {
                                //新的一月
                                workMonth = _workMonth;
                                workMonthIsCreateNotice = false;
                                workMonthIsSendNotice = false;
                                ConsoleAppend("取得新的工作月");
                            }
                        }
                    }

                    if (sendstarttime <= sysTime && !workMonthIsSendNotice)
                    {
                        //创建一个HTTP请求
                        try
                        {
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(SendUrl);
                            request.Method = "get";
                            request.Timeout = 30000;
                            HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                            Stream s = response.GetResponseStream();
                            StreamReader reader = new StreamReader(s);
                            string htmlText = reader.ReadToEnd();
                            labLastSendTime.BeginInvoke((Action)delegate
                            {
                                labLastSendTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            });
                            ConsoleAppend("请求推送消息完成");
                            WriteLog.WriteLogMessage("ThreadFun-Send", htmlText);
                            workMonthIsSendNotice = true;
                        }
                        catch (Exception ex)
                        {
                            ConsoleAppend(ex.Message);
                            WriteLog.WriteLogMessage("ThreadFun-sendmsg", ex.Message);
                        }

                    }
                    #endregion

                    #region 长期未交警示
                    DateTime j_starttime = DateTime.Parse(sysTime.ToString("yyyy-MM") + "-" + J_ServerStartTime + ":00");
                    DateTime j_endtime = DateTime.Parse(sysTime.ToString("yyyy-MM") + "-" + J_ServerEndTime + ":00");
                    DateTime j_sendstarttime = DateTime.Parse(sysTime.ToString("yyyy-MM") + "-" + J_ServerSendStartTime + ":00");
                    if (j_starttime <= sysTime && sysTime <= j_endtime)
                    {
                        //时间范围内--
                        if (!j_workMonthIsCreateNotice)
                        {
                            //没有处理数据
                            //查询工作月
                            if (string.IsNullOrEmpty(j_workMonth))
                            {
                                j_workMonth = Utils.WorkMonth();
                            }
                            if (!string.IsNullOrEmpty(j_workMonth))
                            {
                                string J_Month_workMonth = MonthAdd(j_workMonth, -J_Month);
                                //判断当前工作月是否已处理
                                #region 查询表结构NoticeDt(如果没有重新创建)
                                DataTable temdt = null;
                                using (MAction action = new MAction("(SELECT OBJECT_ID('WCNotice" + j_workMonth + "') ObjeId)V", WeChatDB))
                                {
                                    temdt = action.Select().ToDataTable();
                                }
                                //判断是否已经有数据
                                int res = 0;
                                DataTable NoticeDt = null;

                                if (temdt != null && temdt.Rows.Count > 0)
                                {
                                    if (temdt.Rows[0]["ObjeId"] == null || temdt.Rows[0]["ObjeId"] == DBNull.Value)
                                    {
                                        //新建表
                                        //创建表
                                        using (MProc proc = new MProc("CreateTabWCNoticeJS", WeChatDB))
                                        {
                                            proc.Set("WorkMonth", j_workMonth);
                                            proc.ExeNonQuery();
                                        }
                                        using (MAction action = new MAction("WCNotice" + j_workMonth + "", WeChatDB))
                                        {
                                            NoticeDt = action.Select("1=2").ToDataTable();
                                        }
                                        ConsoleAppend("创建表WCNoticeJS" + j_workMonth + "完成");
                                    }
                                    else
                                    {
                                        using (MAction action = new MAction("WCNotice" + j_workMonth + "", WeChatDB))
                                        {
                                            res = action.GetCount("NoticeType='2'");
                                            NoticeDt = action.Select("1=2").ToDataTable();
                                        }
                                        ConsoleAppend("本月条数JS" + res);
                                    }
                                }
                                #endregion

                                if (res > 0)
                                {
                                    //本月已经处理
                                    #region 标记已经处理
                                    j_workMonthIsCreateNotice = true;
                                    using (MAction action = new MAction("WCNotice" + j_workMonth + "", WeChatDB))
                                    {
                                        res = action.GetCount("NoticeType='2' AND IsFinish = 1");
                                        if (res > 0)
                                        {
                                            //本月已经发送
                                            j_workMonthIsSendNotice = true;
                                        }
                                        else
                                        {
                                            j_workMonthIsSendNotice = false;
                                        }
                                    }
                                    #endregion
                                    ConsoleAppend("本月通知单已经生成JS");
                                }
                                else
                                {
                                    #region 1.转移绑定的用户信息到营业库临时数据
                                    //开始处理数据
                                    string sql = "SELECT OpenId,CustomerID,AccountNumber FROM UserBindInfo WHERE Flag = '0'";//AND OpenId IN ('o4Uz_v3mcR7-kUlzy6cWu5R6h2ZM','o4Uz_v1fJYZkGY2YHgc2l0kDIzVc')
                                    //挪移绑定的openid，只查询绑定范围内的数据
                                    MDataTable bindDt = null;
                                    DataTable bindTmpDt = null;
                                    using (MAction action = new MAction("(" + sql + ")V", WeChatDB))
                                    {
                                        bindDt = action.Select();
                                    }
                                    string con = "";
                                    using (MAction action = new MAction("UserBindInfoTemp"))
                                    {
                                        //清空表
                                        action.BatchDelete("1=1");
                                        action.ResetTable("UserBindInfoTemp");
                                        bindTmpDt = action.Select().ToDataTable();//获取表结构
                                        con = action.ConnectionString;
                                    }
                                    if (bindDt != null && bindDt.Rows.Count > 0)
                                    {
                                        //获取sysdata UserBindInfo表结构
                                        foreach (MDataRow row in bindDt.Rows)
                                        {
                                            DataRow _row = bindTmpDt.NewRow();
                                            _row["OpenId"] = row.Get<string>("OpenId");
                                            _row["CustomerID"] = row.Get<string>("CustomerID");
                                            _row["AccountNumber"] = row.Get<string>("AccountNumber");
                                            _row["BatchNo"] = "";
                                            bindTmpDt.Rows.Add(_row);
                                        }

                                        using (System.Data.SqlClient.SqlBulkCopy bcp = new System.Data.SqlClient.SqlBulkCopy(con, SqlBulkCopyOptions.CheckConstraints))
                                        {
                                            bcp.BatchSize = 100;              //每次传输的行数
                                            bcp.DestinationTableName = "UserBindInfoTemp"; //目标表
                                            bcp.WriteToServer(bindTmpDt, DataRowState.Added);
                                        }
                                    }
                                    else
                                    {
                                        ConsoleAppend("没有绑定的用户JS");
                                    }
                                    #endregion
                                    ConsoleAppend("转移绑定的用户信息到营业库完成JS" + bindDt.Rows.Count);

                                    #region 2.查询营业库需要发送的数据 并写入微信库
                                    sql = "";
                                    sql += "SELECT T1.CustomerAddr,T1.CustomerNo";
                                    sql += ",T1.CustomerID,T1.CustomerName";
                                    sql += ",T5.OpenID,T4.Balance,0 as Amount";
                                    sql += ",0.0 as Charge,0.0 as NowOweCharge,T3.OweAmount";
                                    sql += ",T3.OweCharge,T3.OweCnt,T3.MinMonth,T3.MaxMonth,ROUTE.Mobile ";
                                    sql += " FROM Customer T1";
                                    //关联微信信息-排除未绑定-获取openid
                                    sql += " LEFT JOIN UserBindInfoTemp T5 ON T1.CustomerID = T5.CustomerID";
                                    //关联往月外欠
                                    sql += " LEFT JOIN";
                                    sql += " (SELECT CustomerID,COUNT(ReceivableID) OweCnt";
                                    sql += ",SUM(AccountAmount) OweAmount,SUM(ReceivableCharge) OweCharge";
                                    sql += ",MAX(AccountMonth) MaxMonth,Min(AccountMonth) MinMonth";
                                    sql += " FROM Receivable WHERE ReceivableCharge>0 AND ProcessingStateID<>'" + WaterConst.ProcessingState.ChargeOff + "' ";
                                    sql += " AND AccountMonth <= '" + J_Month_workMonth + "'";
                                    sql += " GROUP BY CustomerID ) T3";
                                    sql += " ON T1.CustomerID = T3.CustomerID";
                                    sql += " LEFT JOIN PrePaidAccount T4 ON T1.CustomerID = T4.CustomerID";
                                    //关联收费路线
                                    sql += " LEFT JOIN";
                                    sql += " (SELECT CustomerID,MAX(Mobile) Mobile FROM (";
                                    sql += " SELECT T1.CustomerID,T3.Mobile FROM dbo.Meter T1, dbo.Customer T2 ";
                                    sql += " ,(SELECT T1.SmallZoneID,T1.MeterKindID,T2.Mobile,T2.Name EmpName ";
                                    sql += " FROM MeterChargeSetting T1 LEFT JOIN Employee T2 ON T1.EmployeeID = T2.EmployeeID";
                                    sql += " WHERE T1.WorkMonth = '" + j_workMonth + "' AND AdminTypeID = '2')";
                                    sql += " T3 WHERE T1.CustomerID = T2.CustomerID AND T2.SmallZoneID = T3.SmallZoneID AND T1.MeterKindID = T3.MeterKindID ";
                                    sql += " UNION ALL ";
                                    sql += " SELECT CustomerID,T2.Mobile FROM Meter T1 , (";
                                    sql += " SELECT T1.BookNo,T1.AdminTypeID,T2.Mobile,T2.Name EmpName ";
                                    sql += " FROM MeterReadSetting T1 LEFT JOIN Employee T2 ON T1.EmployeeID = T2.EmployeeID";
                                    sql += " WHERE T1.WorkMonth = '" + j_workMonth + "' AND SettingType = '2' AND AdminTypeID = '1'";
                                    sql += " ) T2 WHERE T1.AdminTypeID = T2.AdminTypeID AND T1.Book = T2.BookNo";
                                    sql += " ) T GROUP BY CustomerID";
                                    sql += " ) ROUTE ON T1.CustomerID = ROUTE.CustomerID";
                                    sql += " ";

                                    sql += " WHERE T5.CustomerID IS NOT NULL";
                                    //本月有抄表或者有历史外欠才推送
                                    sql += " AND T3.OweCnt>0";
                                    //--AND (T2.NowOweCharge+T3.OweCharge)>T4.Balance
                                    //查询本月应收--以往外欠
                                    MDataTable dbdt = null;
                                    using (MAction action = new MAction("(" + sql + ")V"))
                                    {
                                        dbdt = action.Select();//获取
                                    }
                                    if (dbdt != null && dbdt.Rows.Count > 0)
                                    {
                                        foreach (MDataRow row in dbdt.Rows)
                                        {
                                            DataRow _row = NoticeDt.NewRow();
                                            _row["NoticeNo"] = Utils.GUID();
                                            _row["NoticeType"] = "2";
                                            _row["WorkMonth"] = j_workMonth;
                                            _row["BatchNo"] = sysTime.ToString("yyyyMMddHHmmss");
                                            _row["OpenID"] = row.Get<string>("OpenID");
                                            _row["CustomerID"] = row.Get<string>("CustomerID");
                                            _row["CustomerNo"] = row.Get<string>("CustomerNo");
                                            _row["CustomerName"] = row.Get<string>("CustomerName");
                                            _row["CustomerAddr"] = row.Get<string>("CustomerAddr");
                                            _row["Amount"] = row.Get<decimal>("Amount");
                                            _row["Charge"] = row.Get<decimal>("Charge");
                                            _row["NowOweCharge"] = row.Get<decimal>("NowOweCharge");
                                            _row["IsChargeOff"] = "0";
                                            string Mobile = row.Get<string>("Mobile");
                                            if (!string.IsNullOrEmpty(Mobile) && Mobile.Trim().Length == 11)
                                            {
                                                Remark2 = string.Format(Remark2, Mobile);
                                            }
                                            else
                                            {
                                                Remark2 = string.Format(Remark2, "[营业厅]");
                                            }
                                            if (string.IsNullOrEmpty(row.Get<string>("MinMonth")))
                                            {
                                                _row["OweMonth"] = "";
                                                _row["OweAmount"] = 0;
                                                _row["OweCharge"] = 0;
                                                _row["OweCnt"] = 0;
                                                _row["Remark"] = Remark2;
                                            }
                                            else
                                            {
                                                if (row.Get<string>("MinMonth") == row.Get<string>("MaxMonth"))
                                                {
                                                    _row["OweMonth"] = row.Get<string>("MinMonth");
                                                }
                                                else
                                                {
                                                    _row["OweMonth"] = row.Get<string>("MinMonth") + " - " + row.Get<string>("MaxMonth");
                                                }
                                                _row["OweAmount"] = row.Get<decimal>("OweAmount");
                                                _row["OweCharge"] = row.Get<decimal>("OweCharge");
                                                _row["OweCnt"] = row.Get<int>("OweCnt");
                                                _row["Remark"] = string.Format(Remark1) + Remark2;
                                            }

                                            _row["Account"] = row.Get<decimal>("Balance");
                                            _row["SendCnt"] = "0";
                                            _row["LastSendTime"] = sysTime.ToString("yyyy-MM-dd HH:mm:ss");
                                            _row["IsFinish"] = "0";
                                            NoticeDt.Rows.Add(_row);
                                        }
                                        #region 把查询出的数据写入微信库
                                        using (System.Data.SqlClient.SqlBulkCopy bcp = new System.Data.SqlClient.SqlBulkCopy(WeChatDB, SqlBulkCopyOptions.CheckConstraints))
                                        {
                                            bcp.BatchSize = 100;              //每次传输的行数
                                            bcp.DestinationTableName = "WCNotice" + workMonth + ""; //目标表
                                            bcp.WriteToServer(NoticeDt, DataRowState.Added);
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        ConsoleAppend("没有需要发送的数据JS");
                                    }
                                    #endregion
                                    ConsoleAppend("查询营业库需要发送的数据 并写入微信库JS" + dbdt.Rows.Count);

                                    #region 3.清除营业库临时数据
                                    using (MAction action = new MAction("UserBindInfoTemp"))
                                    {
                                        //清空表
                                        action.BatchDelete("1=1");
                                    }
                                    #endregion
                                    ConsoleAppend("清除营业库临时数据完成JS");

                                    #region 4.标记处理完成
                                    //处理完成
                                    j_workMonthIsCreateNotice = true;
                                    j_workMonthIsSendNotice = false;
                                    #endregion

                                    labLastNumJS.BeginInvoke((Action)delegate
                                    {
                                        labLastNumJS.Text = dbdt.Rows.Count + "";
                                    });
                                    labLastTimeJS.BeginInvoke((Action)delegate
                                    {
                                        labLastTimeJS.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                    });
                                    ConsoleAppend("标记处理完成JS");
                                }
                            }
                        }
                        else
                        {
                            string _workMonth = Utils.WorkMonth();
                            if (_workMonth != j_workMonth)
                            {
                                //新的一月
                                j_workMonth = _workMonth;
                                j_workMonthIsCreateNotice = false;
                                j_workMonthIsSendNotice = false;
                                ConsoleAppend("取得新的工作月JS");
                            }
                        }
                    }
                    if (j_sendstarttime <= sysTime && !j_workMonthIsSendNotice)
                    {
                        //创建一个HTTP请求
                        try
                        {
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(J_SendUrl);
                            request.Method = "get";
                            request.Timeout = 30000;
                            HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                            Stream s = response.GetResponseStream();
                            StreamReader reader = new StreamReader(s);
                            string htmlText = reader.ReadToEnd();
                            labLastSendTimeJS.BeginInvoke((Action)delegate
                            {
                                labLastSendTimeJS.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            });
                            ConsoleAppend("请求推送消息完成JS");
                            WriteLog.WriteLogMessage("ThreadFun-Send", htmlText);
                            j_workMonthIsSendNotice = true;
                        }
                        catch (Exception ex)
                        {
                            ConsoleAppend(ex.Message);
                            WriteLog.WriteLogMessage("ThreadFun-sendmsg", ex.Message);
                        }

                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    ConsoleAppend(ex.Message);
                    WriteLog.WriteLogMessage("ThreadFun-createmsg", ex.Message);
                }
                
                Thread.Sleep(ServerSleepTime);
            }
        }
        private string MonthAdd(String workMonth, int month)
        {
            DateTime dt = DateTime.ParseExact(workMonth + "01", "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
            return dt.AddMonths(month).ToString("yyyyMM");
        }
        private void ConsoleAppend(string text)
        {
            rtbText.BeginInvoke((Action)delegate
            {
                if (rtbText.Lines.Length > 100)
                {
                    WriteLog.WriteTxtMessage(rtbText.Text.Replace("\n", "\r\n"), "ConsoleBak");
                    rtbText.Text = "";
                }
                rtbText.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n");
                rtbText.AppendText(text + "\r\n");
            });
        }

        #endregion

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (serverThread != null)
                {
                    serverThread.Abort();
                }
            }
            catch (Exception ex)
            {
                WriteLog.WriteLogMessage("FormMain_FormClosing", ex.Message);
            }
        }


    }
}
