using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TGNoticeServer.Utilites
{
    public class WaterConst
    {
        //本状态
        //public enum BOOK_STATUS {
        //    ENABLE = 1,//在用
        //    DISABLE = 2//停用
        //}
        public readonly static String DEFALUT_FOLDER = "D:\\小额\\";

        public readonly static String INIT_PASSWORD = "888888";

        public readonly static String BOOK_STATUS_ENABLE = "1"; //在用
        public readonly static String BOOK_STATUS_DISABLE = "2"; //停用

        public readonly static String DEFAULT_COMPANY_ID = "1"; //默认分公司ID
        public readonly static String DEFAULT_BUSINESS_PLACE_ID = "1"; //默认营业所ID
        public readonly static String DEFAULT_BUSINESS_SITE_ID = "1"; //默认营业网点ID
        public readonly static String DEFAULT_REGION_ID = "1"; //默认区域ID

        public readonly static Int32 DEFAULT_CUSTOMER_POPULATION = 4; //默认人口数

        //客户地址拼串默认字符
        public readonly static String DEFAULT_ADDR_PREFIX = "无"; //默认人口数

        //工行行号
        public readonly static String ICBC_BANK_NO = "0202";

        //非工行水费代码
        public readonly static String WATER_FEES_CODE = "00201";

        //用水类型
        public readonly static String UseKind1 = "1"; //阶梯水价

        //违约天数（违约金）
        public readonly static String PenaltyDaysID = "1";      

        //透支限制购水量
        public readonly static Int32 LimitedAmount = 5;

        // 默认营业网点
        public struct DefaultBusinessSite
        {
            public readonly static String No = "1";
            public readonly static String Name = "塘沽营业网点"; 
        }

        // 是否阶梯
        public struct IsStair
        {
            // 否
            public readonly static string No = "0";
            // 是
            public readonly static string Yes = "1";
        }

        public struct MeterIsVIP
        {
            // 否
            public readonly static string No = "0";
            // 是
            public readonly static string Yes = "1";
        }

        /// <summary>
        /// 表库类型
        /// </summary>
        // 新装
        public readonly static String WAREHOUSE_INSTALL = "0";
        // 维修
        public readonly static String WAREHOUSE_MAINTAIN = "1";

        /// <summary>
        /// 入出库类型
        /// </summary>
        // 入库
        public readonly static String WAREHOUSE_IN = "0";
        // 出库
        public readonly static String WAREHOUSE_OUT = "1";

        /// <summary>
        /// 操作类型
        /// </summary>
        // 新建
        public readonly static String OPERATE_NEW = "0";
        // 编辑
        public readonly static String OPERATE_EDIT = "1";
        // 查看
        public readonly static String OPERATE_VIEW = "2";

        // 路线
        public readonly static String MeterSettingType1 = "1"; //抄表
        public readonly static String MeterSettingType2 = "2"; //收费
        public readonly static String MeterSettingType3 = "3"; //催欠

        // 开账状态
        public struct BillingStatus
        {
            public readonly static int Enabled = 0; // 开账
            public readonly static int Disabled = 1; // 不开账
        }

        // 用户状态
        public struct CustomerStatus
        {
            // 在用
            public readonly static string Enabled = "0";
            // 销户
            public readonly static string Disabled = "1";
            // 删除
            public readonly static string Deleted = "9";
        }

        // 水表状态
        public struct MeterStatus
        {
            // 在用
            public readonly static string Enabled = "0";
            public readonly static string EnabledText = "启用";
            // 停用
            public readonly static string Disabled = "1";
            public readonly static string DisabledText = "停用";
            // 落表
            public readonly static string Removed = "2";
            public readonly static string RemovedText = "落表";
            // 删除
            public readonly static string Deleted = "9";
            public readonly static string DeletedText = "删除";
            // 新装
            public readonly static string Install = "3";
            public readonly static string InstallText = "新装";
        }

        // 缴费类型
        public struct PayKind
        {
            // 现金
            public const String Cash = "1";
            // 小额支付
            public const String SmallPayment = "2";
            // 银行代收
            public const String BankCollection = "3";
            // 小额自缴
            public const String SmallSelfPayment = "4";
            // 卡表预付
            public const String CardPrepaid = "5";
            // 预缴费
            public const String Reserve = "6";
        }

        /// <summary>
        /// 计划支付类别
        /// </summary>
        public struct PrePayKind
        {
            // 卡表预付
            public const String CardPrepaid = "6";
        }

        /// <summary>
        /// 工单类别
        /// </summary>
        public struct WorkorderType
        {
            // 落表
            public readonly static string Dismantle = "1";
            public readonly static string DismantleText = "落表";
            // 换表
            public readonly static string Change = "2";
            public readonly static string ChangeText = "换表";
            // 复装
            public readonly static string Reinstall = "3";
            public readonly static string ReinstallText = "复装";
            // 赔表
            public readonly static string Damage = "4";
            public readonly static string DamageText = "赔表";
            // 更名
            public readonly static string Rename = "1";
            public readonly static string RenameText = "申请更名";
            // 过户
            public readonly static string Assigned = "2";
            public readonly static string AssignedText = "申请过户";
            // 变更用水性质
            public readonly static string UseKind = "3";
            public readonly static string UseKindText = "变更用水性质";
            // 变更支付类别
            public readonly static string PayKind = "4";
            public readonly static string PayKindText = "变更支付类别";
            // 申请人口增量
            public readonly static string Population = "5";
            public readonly static string PopulationText = "申请人口增量";
        }

        /// <summary>
        /// 业务类别
        /// </summary>
        public struct BusinessType
        {
            // 申请更名
            public readonly static string Rename = "5";
            public readonly static string RenameText = "申请更名";
            // 申请过户
            public readonly static string Assigned = "6";
            public readonly static string AssignedText = "申请过户";
            // 变更用水性质
            public readonly static string UseKind = "7";
            public readonly static string UseKindText = "变更用水性质";
            // 变更支付类别
            public readonly static string PayKind = "8";
            public readonly static string PayKindText = "变更支付类别";
            // 申请人口增量
            public readonly static string Population = "9";
            public readonly static string PopulationText = "申请人口增量";
        }

        /// <summary>
        /// 管理类型
        /// </summary>
        public struct AdminType
        {
            // 贸易结算总表
            public readonly static string ZB = "1";
            public readonly static string ZBText = "贸易结算总表";
            // 贸易结算户表
            public readonly static string HB = "2";
            public readonly static string HBText = "贸易结算户表";
            // 考核表
            public readonly static string KHB = "3";
            public readonly static string KHBText = "考核表";
        }

        /// <summary>
        /// 水表类型
        /// </summary>
        public struct MeterType
        {
            //机械表
            public readonly static string JX = "1";
            public readonly static string JXText = "机械表";
            // IC卡表
            public readonly static string IC = "2";
            public readonly static string ICText = "IC卡表";
            // 远传表
            public readonly static string YC = "3";
            public readonly static string YCText = "远传表";
            // 流量计
            public readonly static string LLJ = "4";
            public readonly static string LLJText = "流量计";
        }

        /// <summary>
        /// 水表型号
        /// </summary>
        public struct MeterKind
        {
            //无表防险
            public readonly static string WBFX = "0";
            public readonly static string WBFXText = "无表防险";
            // A级机械表
            public readonly static string AJJXB = "1";
            public readonly static string AJJXBText = "A级机械表";
            // B级机械表
            public readonly static string BJJXB = "2";
            public readonly static string BJJXBText = "B级机械表";
            // 翔龙无线一代表
            public readonly static string XLWXYD = "3";
            public readonly static string XLWXYDText = "翔龙无线一代表";
            // 翔龙远红外表
            public readonly static string XLYHW = "4";
            public readonly static string XLYHWText = "翔龙远红外表";
            // 流量计
            public readonly static string LLJ = "5";
            public readonly static string LLJText = "流量计";
            // 翔龙无线二代表
            public readonly static string XLWXED = "8";
            public readonly static string XLWXEDText = "翔龙无线二代表";
            // 翔龙无线三代表
            public readonly static string XLWXSD = "9";
            public readonly static string XLWXSDText = "翔龙无线三代表";
            // 创世无线表
            public readonly static string CSWX = "10";
            public readonly static string CSWXText = "创世无线表";
            // 瑞泉远传表
            public readonly static string RQYC = "11";
            public readonly static string RQYCText = "瑞泉远传表";

            /// <summary>
            /// 华淼存储卡IC卡表
            /// </summary>
            public const string HMCCK = "14";
            public const string HMCCKText = "华淼存储卡IC卡表";
            /// <summary>
            /// 华淼射频卡IC卡表
            /// </summary>
            public const string HMSPK = "23";
            public const string HMSPKText = "华淼射频卡IC卡表";
            /// <summary>
            /// 华淼射频卡远传IC卡表
            /// </summary>
            public const string HMSPKYC = "24";
            public const string HMSPKYCText = "华淼射频卡远传IC卡表";
            /// <summary>
            /// 华旭存IC卡表
            /// </summary>
            public const string HX = "25";
            public const string HXText = "华旭IC卡表";
        }

        /// <summary>
        /// 录入方式
        /// </summary>
        public struct InputFlag
        {
            // 手工录入
            public readonly static string SG = "1";
            public readonly static string SGText = "手工录入";
            // 手持机导入
            public readonly static string SCJ = "2";
            public readonly static string SCJText = "手持机导入";
            // 翔龙抄表器导入
            public readonly static string XL = "3";
            public readonly static string XLText = "翔龙抄表器导入";
            // 银联POS机导入
            public readonly static string POS = "4";
            public readonly static string POSText = "银联POS机导入";
            // 瑞泉
            public readonly static string RQ = "5";
            public readonly static string RQText = "瑞泉抄表器机导入";
        }

        /// <summary>
        /// 记账方式
        /// </summary>
        public struct AccountMode
        {
            // 手工录入记账
            public readonly static string SG = "1";
            public readonly static string SGText = "手工录入记账";
            // 手持机导入
            public readonly static string SCJ = "2";
            public readonly static string SCJText = "手持机导入记账";
            // 远传抄表导入记账
            public readonly static string YC = "3";
            public readonly static string YCText = "远传抄表导入记账";
            // 银联POS机导入
            public readonly static string POS = "4";
            public readonly static string POSText = "银联POS机导入记账";
            // 红蓝笔记账
            public readonly static string RedBlue = "5";
            public readonly static string RedBlueText = "红蓝笔记账";
        }

        /// <summary>
        /// 计量类型
        /// </summary>
        public struct CalculateType
        {
            // 手工录入/手持机导入/银联POS机导入
            public readonly static string RG = "1";
            public readonly static string RGText = "人工现场抄表";
            // 翔龙抄表器导入
            public readonly static string YC = "2";
            public readonly static string YCText = "远传抄表导入";
            // 用户自报指数
            public readonly static string YHZB = "3";
            public readonly static string YHZBText = "用户自报指数";
            // 蓝笔
            public readonly static string LB = "5";
            public readonly static string LBText = "纯蓝笔";
            // 减免蓝笔
            public readonly static string JMLB = "6";
            public readonly static string JMLBText = "减免蓝笔";
            // 减免红笔
            public readonly static string JMHB = "7";
            public readonly static string JMHBText = "减免红笔";
            // 红笔
            public readonly static string HB = "8";
            public readonly static string HBText = "当月红笔";
            // 过月红笔
            public readonly static string GYHB = "9";
            public readonly static string GYHBText = "过月红笔";
        }

        // 应收处理状态
        public struct ProcessingState
        {
            //已记账
            public readonly static string Account = "1";
            public readonly static string AccountText = "已记账";
            //已销账
            public readonly static string ChargeOff = "3";
            public readonly static string ChargeOffText = "已销账";
            //在途(减免)
            //public readonly static string WaterReduction = "4";
            //public readonly static string WaterReductionText = "在途(减免)";
            //在途(小额)
            public readonly static string SmallTransmit = "5";
            public readonly static string SmallTransmitText = "在途(小额)";
            //在途(代收)
            public readonly static string BanktTransmit = "6";
            public readonly static string BanktTransmitText = "在途(代收)";
            //在途(红蓝笔)
            public readonly static string AdjustTransmit = "7";
            public readonly static string AdjustTransmitText = "在途(红蓝笔)";
            //在途(POS)
            public readonly static string PosTransmit = "8";
            public readonly static string PosTransmitText = "在途(POS)";
        }

        // 记账业务类型
        public struct AccountType
        {
            //计量水量
            public readonly static string AmountNormal = "1";
            public readonly static string AmountNormalText = "计量水量";
            //红笔减免
            public readonly static string Red = "2";
            public readonly static string RedText = "红笔减免";
            //红笔
            public readonly static string RedPen = "3";
            public readonly static string RedPenText = "红笔";
            //蓝笔
            public readonly static string BluePen = "4";
            public readonly static string BluePenText = "蓝笔";
        }

        // 浦发交费来源
        public struct PFPaymentSource
        {
            //支付宝
            public readonly static string Alipay = "85";
            public readonly static string AlipayText = "支付宝缴费";

            //柜面
            public readonly static string Counter = "00";
            public readonly static string CounterText = "柜面";

            //自助终端
            public readonly static string VTM = "02";
            public readonly static string VTMText = "自助终端";

            //网银
            public readonly static string CyberBank = "03";
            public readonly static string CyberBankText = "网银";

            //电话银行
            public readonly static string PhoneBank = "04";
            public readonly static string PhoneBankText = "电话银行";

            ////柜面
            //public readonly static string Alipay = "00";
            //public readonly static string AlipayText = "柜面";
        }

        // 交费来源
        public struct PaymentSource
        {
            //柜台收费
            public readonly static string Counter = "1";
            public readonly static string CounterText = "柜台收费";
            //抄收POS机
            public readonly static string POSMachine = "2";
            public readonly static string POSMachineText = "抄收POS机";
            //小额支付
            public readonly static string SmallPayment = "3";
            public readonly static string SmallPaymentText = "小额支付";
            //银行代收
            public readonly static string BankCollection = "4";
            public readonly static string BankCollectionText = "银行代收";
            //批量制卡充值
            public readonly static string BatchCard = "5";
            public readonly static string BatchCardText = "制卡充值";
            //上数销账
            public readonly static string ReadChargeOff = "6";
            public readonly static string ReadChargeOffText = "上数销账";
            //手工销账
            public readonly static string Hand = "7";
            public readonly static string HandText = "手工销账";
            //抄收自交
            public readonly static string ReadCharger = "8";
            public readonly static string ReadChargerText = "抄收自交";
            //电汇
            public readonly static string Transfer = "9";
            public readonly static string TransferText = "电汇转账";
            //承兑汇票
            public readonly static string AcceptanceBill = "10";
            public readonly static string AcceptanceBillText = "承兑汇票";
            //预置水量收费
            public readonly static string PreSet = "11";
            public readonly static string PreSetText = "预置水量收费";
            //第三方售水
            public readonly static string Third = "21";
            public readonly static string ThirdText = "第三方售水";

            //支付宝
            public readonly static string Alipay = "22";
            public readonly static string AlipayText = "浦发网络支付";
        }

        // 交费业务类型
        public struct PaymentType
        {
            //预缴存款
            public readonly static string PrepaidDeposit = "1";
            public readonly static string PrepaidDepositText = "预缴存款";
            //预缴退费
            public readonly static string PrepaidWithdraw = "2";
            public readonly static string PrepaidWithdrawText = "预缴退费";
            //购水
            public readonly static string BuyWater = "3";
            public readonly static string BuyWaterText = "购水";
            //续费
            public readonly static string Renew = "4";
            public readonly static string RenewText = "续费";
            //水费结算
            public readonly static string PrepaidDeduction = "5";
            public readonly static string PrepaidDeductionText = "水费结算";
            //冲存
            public readonly static string RedDeposit = "6";
            public readonly static string RedDepositText = "冲存";
            //冲缴
            public readonly static string RedWithdraw = "7";
            public readonly static string RedWithdrawText = "冲缴";
            // 退费【购水】
            public readonly static string RefundWater = "8";
            public readonly static string RefundWaterText = "购水退费";
            // 退费【续费】
            public readonly static string RefundMoney = "9";
            public readonly static string RefundMoneyText = "续费退费";
            // 换表补水
            public readonly static string FillWater = "10";
            public readonly static string FillWaterText = "换表补水";
            // 补费
            public readonly static string FillMoney = "11";
            public readonly static string FillMoneyText = "换表补费";
            // 撤销补水
            public readonly static string CancelFillWater = "12";
            public readonly static string CancelFillWaterText = "撤销补水";
            // 撤销补费
            public readonly static string CancelFillMoney = "13";
            public readonly static string CancelFillMoneyText = "撤销补费";
            // 撤销购水
            public readonly static string CancelWater = "14";
            public readonly static string CancelWaterText = "撤销购水";
            // 撤销续费
            public readonly static string CancelMoney = "15";
            public readonly static string CancelMoneyText = "撤销续费";
            // 补水
            public readonly static string AddWater = "16";
            public readonly static string AddWaterText = "补水";

            public readonly static string ClearFillMoney = "17";
            public readonly static string ClearFillMoneyText = "清表补费";

            public readonly static string TotalFillMoney = "18";
            public readonly static string TotalFillMoneyText = "累加补费";

            public readonly static string AddMoney = "19";
            public readonly static string AddMoneyText = "补费";
        }

        //销账类型
        public struct ChargeOffType
        {
            //柜台核销
            public readonly static string Counter = "1";
            public readonly static string CounterText = "柜台核销";
            //抄收POS机核销--用户卡
            public readonly static string POSMachine = "2";
            public readonly static string POSMachineText = "POS机核销(用户卡)";
            //抄收POS机核销--收费员卡
            public readonly static string POSStaffMachine = "3";
            public readonly static string POSStaffMachineText = "POS机核销(收费员卡)";
            //预缴核销
            public readonly static string Prepaid = "4";
            public readonly static string PrepaidText = "预缴核销";
            //小额核销
            public readonly static string SmallPayment = "5";
            public readonly static string SmallPaymentText = "小额核销";
            //代收核销
            public readonly static string BankCollection = "6";
            public readonly static string BankCollectionText = "代收核销";
            //红笔核销
            public readonly static string RedBluePen = "7";
            public readonly static string RedBluePenText = "红蓝笔核销";
            //手工核销
            public readonly static string Hand = "8";
            public readonly static string HandText = "手工核销";
            //上数销账
            public readonly static string ReadChargeOff = "9";
            public readonly static string ReadChargeOffText = "上数销账";
            //现金核销
            public readonly static string ReadOwe = "10";
            public readonly static string ReadOweText = "现金核销";

            //支付宝
            public readonly static string Alipay = "11";
            public readonly static string AlipayText = "浦发网络支付核销";
        }

        // 支付方式
        public struct PaymentMode
        {
            //现金
            public readonly static string Cash = "1";
            public readonly static string CashText = "现金";
            //支票
            public readonly static string Check = "2";
            public readonly static string CheckText = "支票";
            //刷卡
            public readonly static string Pos = "3";
            public readonly static string PosText = "刷卡";
            //银行转账
            public readonly static string BankTransfer = "4";
            public readonly static string BankTransferText = "银行转账";
        }

        // 预缴账户状态
        public struct PrePaidAccountStatus
        {
            // 可用
            public const string Enabled = "0";      
            public const string EnabledText = "可用";
            // 冻结
            public const string Frozen = "1";      
            public const string FrozenText = "冻结";
        }

        // 凭证打印类型
        public struct PrintType
        {
            //正常
            public readonly static string Normal = "1";
            public readonly static string NormalText = "正常";
            //补打
            public readonly static string MakeUp = "1";
            public readonly static string MakeUpText = "补打";
        }

        /// <summary>
        /// 工单状态
        /// </summary>
        public struct WorkorderStatus
        {
            // 保存
            public readonly static string Save = "1";
            public readonly static string SaveText = "保存";
            // 生效
            public readonly static string Finish = "2";
            public readonly static string FinishText = "生效";
        }

        /// <summary>
        /// 红蓝笔状态
        /// </summary>
        public struct AdjustStatus
        {
            // 提交
            public readonly static string Submit = "1";
            public readonly static string SubmitText = "提交";
            // 生效
            public readonly static string Validity = "2";
            public readonly static string ValidityText = "生效";
            // 作废
            public readonly static string Cancel = "3";
            public readonly static string CancelText = "作废";
            // 撤销
            public readonly static string Repeal = "4";
            public readonly static string RepealText = "撤销";
        }

        /// <summary>
        /// 剔牌-抄表状态
        /// </summary>
        public struct RejectResultNo
        {
            public const string Calculated = "1";   // 抄表完成
            public const string Pass = "2";         // 剔牌通过
            public const string Reject = "3";       // 被剔牌
            public const string Reviewed = "4";     // 复查通过
        }

        /// <summary>
        /// 抄表任务状态
        /// </summary>
        public struct TaskStatusID
        {
            /// <summary>
            /// 未安排
            /// </summary>
            public const string None = "0";
            /// <summary>
            /// 已安排
            /// </summary>
            public const string Plan = "1";
            /// <summary>
            /// 已发布
            /// </summary>
            public const string Publish = "2";
            /// <summary>
            /// 已下载
            /// </summary>
            public const string Download = "3";
            /// <summary>
            /// 已完成
            /// </summary>
            public const string Finish = "4";
        }

        /// <summary>
        /// 抄表任务状态
        /// </summary>
        public struct TaskStatusName
        {
            /// <summary>
            /// 未安排
            /// </summary>
            public const string None = "未安排";
            /// <summary>
            /// 已安排
            /// </summary>
            public const string Plan = "已安排";
            /// <summary>
            /// 已发布
            /// </summary>
            public const string Publish = "已发布";
            /// <summary>
            /// 已下载
            /// </summary>
            public const string Download = "已下载";
            /// <summary>
            /// 已完成
            /// </summary>
            public const string Finish = "已完成";
        }

        // 账户类型（预交、专项）
        public struct FundAccountType
        {
            public const string PrePaid = "1";       // 预缴资金账户
            public const string SpecialFund = "2";   // 专项资金账户
        }

        //是否抄表
        public struct ReadingFlag
        {
            public const string Yes = "1";       //是
            public const string No = "0";   //否
        }

        /// <summary>
        /// 交款状态
        /// </summary>
        public struct TransferStatus
        {
            // 未交款
            public readonly static string No = "0";
            public readonly static string NoText = "未交款";
            // 已交款
            public readonly static string Already = "1";
            public readonly static string AlreadyText = "已交款";
        }

        /// <summary>
        /// 撤销标志
        /// </summary>
        public struct CancelFlag
        {
            // 未撤销
            public readonly static string NoCancel = "0";
            // 已撤销
            public readonly static string Cancel = "1";
        }

         /// <summary>
        /// 发票状态
        /// </summary>
        public struct InvoiceStatus
        {
            // 未开票
            public readonly static string No = "0";
            public readonly static string NoText = "未开票";
            // 已开票
            public readonly static string Already = "1";
            public readonly static string AlreadyText = "已开票";
        }

        /// <summary>
        /// 交款单状态
        /// </summary>
        public struct AuditStatus
        {
            // 待审核
            public readonly static string PendingAudit = "1";
            public readonly static string PendingAuditText = "待审核";
            // 审核通过
            public readonly static string AuditPass = "2";
            public readonly static string AuditPassText = "审核通过";
        }

        /// <summary>
        /// 支票状态
        /// </summary>
        public struct CheckStatus
        {
            // 正常
            public readonly static string Normal = "1";
            public readonly static string NormalText = "正常";
            // 撤销
            public readonly static string Back = "4";
            public readonly static string BackText = "撤销";
            // 退票
            public readonly static string Refund = "2";
            public readonly static string RefundText = "退票";
            // 回单到账
            public readonly static string BankSlip = "3";
            public readonly static string BankSlipText = "回单到账";
        }

        /// <summary>
        /// 交款凭证状态
        /// </summary>
        public struct ReceiptStatus
        {
            // 未打印
            public readonly static string NoPrint = "1";
            public readonly static string NoPrintText = "未打印";
            // 已打印
            public readonly static string AlreadyPrint = "2";
            public readonly static string AlreadyPrintText = "已打印";
            // 已打印
            public readonly static string OtherPrint = "3";
            public readonly static string OtherPrintText = "其他";
        }

        /// <summary>
        /// 部门/组
        /// </summary>
        public struct Department
        {
            // 抄表组
            public readonly static string MeterReadingGroup = "13";
            public readonly static string MeterReadingGroupText = "居民抄表组";
            
            //收费
            public readonly static string ChargeGroup = "14";
            public readonly static string ChargeGroupText = "居民收费组";

            /// <summary>
            /// 总表抄表科
            /// </summary>
            public readonly static string D_TotalMeterReading = "2";
            public readonly static string D_TotalMeterReadingText = "抄表科";
            /// <summary>
            /// 查表复查组
            /// </summary>
            public readonly static string G_TotalMeterReading = "6";
            public readonly static string G_TotalMeterReadingText = "查表复查组";            
        }

        /// <summary>
        ///角色
        /// </summary>
        public struct Role
        {
            // 抄表员
            public readonly static string MeterReading = "1";
            //收费
            public readonly static string Charge = "12";
        }

        /// <summary>
        /// 在用状态
        /// </summary>
        public struct IsUse
        {
            //在用
            public readonly static string Enabled = "1";
            //停用
            public readonly static string Disabled = "0";
        }
        
        /// <summary>
        /// 银行类别
        /// </summary>
        public struct BankType
        {
            public readonly static string IsICBC = "2";// 工商银行
            public readonly static string NotICBC = "1";// 非工商银行
        }

        /// <summary>
        /// 抄表记账状态
        /// </summary>
        public struct KeepAccountStatus
        {
            /// <summary>
            /// 已记账
            /// </summary>
            public const string Kept = "1";
            /// <summary>
            /// 已记账
            /// </summary>
            public const string KeptText = "已记账"; 
        }

        /// <summary>
        /// 账号属性
        /// </summary>
        public struct EmployeeProperties
        {
            /// <summary>
            /// 账号状态【正常】
            /// </summary>
            public const string AccountStatusNormal = "1";
            /// <summary>
            /// 账号状态【锁定】
            /// </summary>
            public const string AccountStatusLocked = "0";
            /// <summary>
            /// 在用状态【正常】
            /// </summary>
            public const string Enable = "1";
            /// <summary>
            /// 在用状态【不用】
            /// </summary>
            public const string Disable = "0";
        }

        /// <summary>
        /// 用户组类型
        /// </summary>
        public struct GroupType
        {
            /// <summary>
            /// 居民抄表
            /// </summary>
            public const string HouseholdMeterReader = "01";
            /// <summary>
            /// 总表抄表
            /// </summary>
            public const string TotalMeterReader = "02";
            /// <summary>
            /// 居民收费
            /// </summary>
            public const string HouseholdCharge = "03";
            /// <summary>
            /// 营业组
            /// </summary>
            public const string CounterCharge = "04";
            /// <summary>
            /// 地表收费
            /// </summary>
            public const string TotalMeterCharge = "05";
            /// <summary>
            /// 第三方售水
            /// </summary>
            public const string ThirdParty = "06";
        }

        /// <summary>
        /// 批次状态（小额、代收）
        /// </summary>
        public struct BatchStatus
        {
            //未传盘
            public const string NoTrans = "1";
            public const string NoTransText = "未传盘";

            //未回盘
            public const string NoBack = "2";
            public const string NoBackText = "未回盘";

            //已回盘
            public const string Complete = "3";
            public const string CompleteText = "已回盘";

            //已撤销
            public const string Revoke = "4";
            public const string RevokeText = "已撤销";
        }

        /// <summary>
        /// 批次类型（小额、代收）
        /// </summary>
        public struct BatchType
        {
            //小额支付
            public const string SmallPaid = "1";
            public const string SmallPaidText = "小额支付";

            //银行代收
            public const string BankCollection = "2";
            public const string BankCollectionText = "银行代收";
        }

        /// <summary>
        /// 数据提交状态
        /// </summary>
        public struct DataSubmitStatus
        {
            //未提交
            public const string NoSubmit = "0";
            public const string NoSubmitText = "未提交";

            //提交导数据组
            public const string DataTeam = "1";
            public const string DataTeamText = "提交数据组";

            //提交营业
            public const string Submitted = "2";
            public const string SubmittedText = "已提交营业";
        }

        /// <summary>
        /// 手持机上传数据类型
        /// </summary>
        public struct DataRecordType
        {
            /// <summary>
            /// 抄表
            /// </summary>
            public const string Read = "1";
            /// <summary>
            /// 复核
            /// </summary>
            public const string Review = "2";
        }

        /// <summary>
        /// 正散标记
        /// </summary>
        public struct ReadingZSFlag
        {
            // 正路
            public const string ZL = "1";
            public const string ZLText = "正路";

            // 散牌
            public const string SP = "0";
            public const string SPText = "散牌";
        }

        /// <summary>
        /// 是否见表
        /// </summary>
        public struct SeePerosn
        {
            // 原因无
            public const string None = "0";
            public const string NoneText = "无";
        }

        /// <summary>
        /// 估数原因
        /// </summary>
        public struct Estimate
        {
            // 未估数
            public const string None = "0";
            public const string NoneText = "未估数";
        }

        /// <summary>
        /// 水量业务处理状态
        /// </summary>
        public struct AmountState
        {
            // 无状态
            public const string None = "0";
            public const string NoneText = "无";
        }

        /// <summary>
        /// 应收审核状态
        /// </summary>
        public struct RecCheckStatus
        {
            // 已审核
            public const string Checked = "1";
            public const string CheckedText = "已审核";
        }

        /// <summary>
        /// 是否代办
        /// </summary>
        public struct IsAgent
        {
            // 否
            public readonly static string No = "0";
            public readonly static string NoText = "否";
            // 是
            public readonly static string Yes = "1";
            public readonly static string YesText = "是";
        }

        /// <summary>
        /// 月结转状态
        /// </summary>
        public struct MonthlyTransfer
        {
            public readonly static string TransferStarted = "1";//开始结转
            public readonly static string TransferFinished = "0";//结转完成
            public readonly static string TransferFailed = "9";//结转数据异常
        }

        /// <summary>
        /// 月结转DB
        /// </summary>
        public struct MTDbType
        {
            public readonly static string SYSDB = "1-SYSDB";
            public readonly static string ICDB = "2-ICDB";
        }

        /// <summary>
        /// 月结转
        /// </summary>
        public struct MTType
        {
            public readonly static string SYS = "[SYS]";
            public readonly static string IC = "[I C]";
        }

        /// <summary>
        /// 用水分类
        /// </summary>
        public struct UseType
        {
            // 8大类
            public readonly static string Eight = "8";
            // 11大类
            public readonly static string Eleven = "11";
            // 98大类
            public readonly static string NinetyEight = "98";
        }

        /// <summary>
        /// 外欠原因
        /// </summary>
        public struct UnReceivedCause
        {
            // 未录入原因
            public readonly static string Nothing = "0";
        }

        /// <summary>
        /// 统计类别
        /// </summary>
        public struct StatisticsType
        {
            // 纯红笔
            public readonly static string Red = "1";
            // 纯蓝笔
            public readonly static string Blue = "2";
        }

        /// <summary>
        /// 新装类别
        /// </summary>
        public struct NewInstallType
        {
            // 普通新装
            public readonly static string NewInstall = "0";
            // 拆改修装
            public readonly static string NewModify = "1";
        }

        /// <summary>
        /// 当月/过月区分
        /// </summary>
        public struct MonthFlag
        {
            /// <summary>
            /// 当月
            /// </summary>
            public const string ThisMonth = "1";
            /// <summary>
            /// 过月
            /// </summary>
            public const string PastMonth = "2";
        }

        // 其他收费分类
        public struct ChargeType
        {
            //过户费
            public readonly static string TransferFee = "1";
            public readonly static string TransferFeeText = "过户费";
            //补卡费
            public readonly static string CardFee = "2";
            public readonly static string CardFeeText = "补卡费";
            //赔表费
            public readonly static string MeterFee = "3";
            public readonly static string MeterFeeText = "赔表费";
            //违约金
            public readonly static string PenaltyFee= "4";
            public readonly static string PenaltyFeeText = "违约金";
            //塑封费
            public readonly static string PlasticFee = "5";
            public readonly static string PlasticFeeText = "塑封费";
            //透支费
            public readonly static string OverdraftFee = "6";
            public readonly static string OverdraftFeeText = "透支费";
            //复装费
            public readonly static string InstallFee = "7";
            public readonly static string InstallFeeText = "复装费";

            //退过户费
            public readonly static string TransferFeeBack = "9001";
            public readonly static string TransferFeeBackText = "退过户费";
            //退补卡费
            public readonly static string CardFeeBack = "9002";
            public readonly static string CardFeeBackText = "退补卡费";
            //退赔表费
            public readonly static string MeterFeeBack = "9003";
            public readonly static string MeterFeeBackText = "退赔表费";
            //退违约金
            public readonly static string PenaltyFeeBack = "9004";
            public readonly static string PenaltyFeeBackText = "退违约金";
            //退塑封费
            public readonly static string PlasticFeeBack = "9005";
            public readonly static string PlasticFeeBackText = "退塑封费";
            //退复装费
            public readonly static string InstallFeeBack = "9007";
            public readonly static string InstallFeeBackText = "退复装费";
        }

        //预缴账户类型
        public struct PrePaidAccountType
        {
            //协议预缴账户
            public readonly static string AgreementAccount = "1";
            //系统默认预缴账户
            public readonly static string CommonAccount = "0";
        }

        //预缴卡片交易类型
        public struct PrePaidCardBusiness
        {
            //开卡
            public readonly static string ActivateCard = "1";
            public readonly static string ActivateCardText = "开卡";
            //补卡
            public readonly static string FillCard = "2";
            public readonly static string FillCardText = "补卡";
            //换卡
            public readonly static string Replace = "3";
            public readonly static string ReplaceCardText = "换卡";
        }

        //预缴扣款数据类型
        public struct ChargeBackDataType
        {
            //当月
            public readonly static string NowMonth = "1";
            public readonly static string NowMonthText = "当月";
            //外欠
            public readonly static string BeforeMonth= "2";
            public readonly static string BeforeMonthText = "外欠";
        }

        //银行回单类型
        public struct BankSlipsType
        {
            //支票
            public readonly static string Cheque = "2";
            public readonly static string ChequeText = "支票";
            //电汇
            public readonly static string Transfer = "3";
            public readonly static string TransferText = "电汇";
        }

        //银行回单状态
        public struct BankSlipStatus
        {
            public readonly static string NoChecked = "1";
            public readonly static string NoCheckedText = "未核对";
            public readonly static string Checked = "2";
            public readonly static string CheckedText = "核对完成";
        }

        // 客户类型
        public struct CustomerType
        {
            // 小商户
            public readonly static string SmallBusiness = "3";
            // 开发小区户
            public readonly static string DevelopmentArea = "7";
        }

        /// <summary>
        /// 发卡状态
        /// </summary>
        public struct CardStatusID
        {
            /// <summary>
            /// 未制卡
            /// </summary>
            public readonly static int UnFinished = 1;
            /// <summary>
            /// 已制卡
            /// </summary>
            public readonly static int Finished = 2;
        }

        /// <summary>
        /// 卡片操作明细类别
        /// </summary>
        public struct CardDetailsType
        {
            /// <summary>
            /// 新装发卡
            /// </summary>
            public readonly static string PublishCard = "01";
            public readonly static string PublishCardText = "新装发卡";
            /// <summary>
            /// 新装绑卡(华旭)
            /// </summary>
            public readonly static string BindCard = "02";
            public readonly static string BindCardText = "新装绑卡";
            /// <summary>
            /// 换表绑卡(华旭)
            /// </summary>
            public readonly static string ChangeCard = "03";
            public readonly static string ChangeCardText = "换表绑卡";
            /// <summary>
            /// 补卡
            /// </summary>
            public readonly static string FillCard = "04";
            public readonly static string FillCardText = "补卡";
            /// <summary>
            /// 清卡初始化
            /// </summary>
            public readonly static string InitCard = "05";
            public readonly static string InitCardText = "清卡初始化";
            /// <summary>
            /// 购水写卡
            /// </summary>
            public readonly static string BuyWater = "06";
            public readonly static string BuyWaterText = "购水";
            /// <summary>
            /// 续费写卡
            /// </summary>
            public readonly static string Renew = "07";
            public readonly static string RenewText = "续费";
            /// <summary>
            /// 退费【购水】
            /// </summary>
            public readonly static string RefundWater = "08";
            public readonly static string RefundWaterText = "购水退费";
            /// <summary>
            /// 退费【续费】
            /// </summary>
            public readonly static string RefundMoney = "09";
            public readonly static string RefundMoneyText = "续费退费";
            /// <summary>
            /// 换表绑卡撤销
            /// </summary>
            public readonly static string RefundChangeCard = "10";
            public readonly static string RefundChangeCardText = "撤销换表绑卡";
            /// <summary>
            /// 解除绑定
            /// </summary>
            public readonly static string RemoveCard = "11";
            public readonly static string RemoveCardText = "解除绑定";
            /// <summary>
            /// 换卡
            /// </summary>
            public readonly static string ReplaceCard = "12";
            public readonly static string ReplaceCardText = "换卡";
            /// <summary>
            /// 第三方售水补水
            /// </summary>
            public readonly static string SupplyWater = "13";
            public readonly static string SupplyWaterText = "第三方售水补水";

            /// <summary>
            /// 最后一次购水补水
            /// </summary>
            public readonly static string LastFillWater = "14";
            public readonly static string LastFillWaterText = "最后一次购水写卡";

            /// <summary>
            /// 最后一次续费补费
            /// </summary>
            public readonly static string LastFillMoney = "15";
            public readonly static string LastFillMoneyText = "最后一次续费写卡";

            // 补水
            public readonly static string AddWater = "16";
            public readonly static string AddWaterText = "补水";

            public readonly static string ClearFillMoney = "17";
            public readonly static string ClearFillMoneyText = "清表补费";

            public readonly static string TotalFillMoney = "18";
            public readonly static string TotalFillMoneyText = "累加补费";

            public readonly static string AddMoney = "19";
            public readonly static string AddMoneyText = "补费";

        }

        public readonly static string CardModel = "B1";
        

        /// <summary>
        /// 撤销标记
        /// </summary>
        public struct RevokeFlag
        {
            /// <summary>
            /// 未撤销
            /// </summary>
            public readonly static string NotRevoked = "0";
            /// <summary>
            /// 已撤销
            /// </summary>
            public readonly static string Revoked = "1";
        }

        /// <summary>
        /// 档案变更业务种类
        /// </summary>
        public struct ArchiveBusinessType
        {
            /// <summary>
            /// 修改用户档案
            /// </summary>
            public const string ModifyCustomerArchive = "01";
            public const string ModifyCustomerArchiveText = "修改用户档案";
            /// <summary>
            /// 修改水表档案
            /// </summary>
            public const string ModifyMeterArchive = "02";
            public const string ModifyMeterArchiveText = "修改水表档案";
            /// <summary>
            /// 调整用户水表
            /// </summary>
            public const string AdjustMeter = "03";
            public const string AdjustMeterText = "调整用户水表";
            /// <summary>
            /// 更名
            /// </summary>
            public const string Rename = "04";
            public const string RenameText = "更名";
            /// <summary>
            /// 过户
            /// </summary>
            public const string TransferCustomer = "05";
            public const string TransferCustomerText = "过户";
            /// <summary>
            /// 调整人口数
            /// </summary>
            public const string AdjustPopulation = "06";
            public const string AdjustPopulationText = "调整人口数";
            /// <summary>
            /// 换表
            /// </summary>
            public const string ChangeMeter = "07";
            public const string ChangeMeterText = "换表";
            /// <summary>
            /// 停用水表
            /// </summary>
            public const string StopMeter = "08";
            public const string StopMeterText = "停用水表";
            /// <summary>
            /// 启用水表
            /// </summary>
            public const string StartMeter = "09";
            public const string StartMeterText = "启用水表";
            /// <summary>
            /// 落表
            /// </summary>
            public const string DropMeter = "10";
            public const string DropMeterText = "落表";
            /// <summary>
            /// 落表
            /// </summary>
            public const string ReInstalled = "11";
            public const string ReInstalledText = "复装";
            /// 删除用户
            /// </summary>
            public const string DeleteCustomer = "12";
            public const string DeleteCustomerText = "删除用户";
            /// <summary>
            /// 删除水表
            /// </summary>
            public const string DeleteMeter = "13";
            public const string DeleteMeterText = "删除水表";
        }

        /// <summary>
        /// 柜台提示 是否限制购水
        /// </summary>
        public struct PromptLimited
        {
            /// <summary>
            /// 是
            /// </summary>
            public const string Yes = "1";
            public const string No = "0";
        }

        /// <summary>
        /// 柜台提示 消除标志
        /// </summary>
        public struct PromptRevokeFlag
        {
            /// <summary>
            /// 未消除
            /// </summary>
            public const string Unrevoked = "0";
            /// <summary>
            /// 已消除
            /// </summary>
            public const string Revoked = "1";
        }

        /// <summary>
        /// 柜台提示 生成标志
        /// </summary>
        public struct PromptGenerateFlag
        {
            /// <summary>
            /// 透支生成
            /// </summary>
            public const string Generate = "1";
            /// <summary>
            /// 录入
            /// </summary>
            public const string Input = "2";
        }

        /// <summary>
        /// 是否写卡
        /// </summary>
        public struct WriteCardFlag
        {
            /// <summary>
            /// 否
            /// </summary>
            public const string No = "0";
            /// <summary>
            /// 是
            /// </summary>
            public const string Yes = "1";
        }

        /// <summary>
        /// 换表状态
        /// </summary>
        public struct ReplaceStatus
        {
            // 未写卡
            public readonly static string NoWrite = "1";
            public readonly static string NoWriteText = "未写卡";
            // 已写卡
            public readonly static string Write = "2";
            public readonly static string WriteText = "已写卡";
            // 撤销
            public readonly static string Cancel = "3";
            public readonly static string CancelText = "撤销";
        }

        /// <summary>
        /// IC卡用户管理性质
        /// </summary>
        public struct AdminProperty
        {
            // 非居贸易结算总表
            public readonly static string FJZB = "1";
            public readonly static string FJZBText = "非居贸易结算总表";
            // 考核表内非居贸易结算户表
            public readonly static string KHFJHB = "2";
            public readonly static string KHFJHBText = "考核表内非居贸易结算户表";
            // 混合性质客户
            public readonly static string HHKH = "3";
            public readonly static string HHKHText = "混合性质客户";
            // 考核表内居民户表
            public readonly static string KHJMHB = "4";
            public readonly static string KHJMHBText = "考核表内居民户表";
        }

        /// <summary>
        /// IC卡水表性质
        /// </summary>
        public struct MeterNature
        {
            // 正式表
            public readonly static string Official = "1";
            public readonly static string OfficialText = "正式表";
        }

        /// <summary>
        /// 远传抄表任务状态
        /// </summary>
        public struct YCTaskSendFlag
        {
            /// <summary>
            /// 已生成
            /// </summary>
            public readonly static string Generated = "0";
            /// <summary>
            /// 已发送
            /// </summary>
            public readonly static string Sent = "1";
        }

        /// <summary>
        /// 购水记录修改类型
        /// </summary>
        public struct SWRModifyType
        {
            //删除
            public readonly static string Delete = "1";
            public readonly static string DeleteText = "删除";

            //调整前
            public readonly static string ModifyBefore = "2";
            public readonly static string ModifyBeforeText = "调整前";

            //调整后
            public readonly static string ModifyLater = "3";
            public readonly static string ModifyLaterText = "调整后";

            //新增
            public readonly static string Add = "4";
            public readonly static string AddText = "新增";

            //解绑删除
            public readonly static string RemoveCard= "5";
            public readonly static string RemoveCardText = "解绑删除";
        }

        /// <summary>
        /// 补费类型
        /// </summary>
        public struct FillMoneyType
        {
            //清表补费
            public readonly static string ClearMeter = "1";
            public readonly static string ClearMeterText = "清表补费";

            //远磁换远磁
            public readonly static string YCiReplace = "2";
            public readonly static string YCiReplaceText = "远磁换远磁";

            //累加补费
            public readonly static string TotalMoney = "3";
            public readonly static string TotalMoneyText = "累加补费";
        }

        /// <summary>
        /// 透支处理
        /// </summary>
        public struct OverdraftType
        {
            //水表停用
            public readonly static string StopMeter = "1";
            public readonly static string StopMeterText = "水表停用";

            //限制购水量
            public readonly static string LimitedAmount = "2";
            public readonly static string LimitedAmountText = "限制购水量";
        }

        /// <summary>
        /// 换表类型
        /// </summary>
        public struct MeterReplaceType
        {
            //远传换磁卡
            public readonly static string YCChangeIC = "1";
            public readonly static string YCChangeICText = "远传换磁卡";

            //磁卡换磁卡
            public readonly static string ICChangeIC = "2";
            public readonly static string ICChangeICText = "磁卡换磁卡";
        }


        /// <summary>
        /// 手持机连接端口波特率
        /// </summary>
        public const uint BAUDRATE = 115200;
        /// <summary>
        /// 集抄手持机工作路径
        /// </summary>
        public const string WORK_PATH = "炳华集抄";
    }
}