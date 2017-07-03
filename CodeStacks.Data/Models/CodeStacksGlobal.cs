using System;
using System.Collections;
using System.Collections.Generic;

namespace Xiaowen.CodeStacks.Data.Models
{
    /// <summary>
    /// 全局变量类
    /// </summary>
    public class CodeStacksGlobalCache : IDisposable
    {
        public static string Company { get; set; }
        public static int SocketTimeout { get; set; }
        public static string Host { get; set; }
        public static int Port { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static bool IsVerify { get; set; }
        public static bool IsCompress { get; set; }
        /// <summary>
        /// ALL allfunc
        /// DEMO wishfunc
        /// DEBUG testfunc
        /// </summary>
        public static string AppMode { get; set; }
        /// <summary>
        /// 软件抬头
        /// </summary>
        public static string AppTitle { get; set; }
        /// <summary>
        /// 软件版本
        /// </summary>
        public static string AppVersion { get; set; }
        /// <summary>
        /// 1 接收端
        /// 0 筛选端
        /// </summary>
        public static UInt16 AppType { get; set; }
        /// <summary>
        /// 区域类型
        /// </summary>
        public static UInt16 AppRegion { get; set; }
        /// <summary>
        /// 所属区域名称
        /// </summary>
        public static string AppLocation { get; set; }
        /// <summary>
        /// 字窗体状态
        /// </summary>
        public static int ChildWindowStatus { get; set; }
        /// <summary>
        /// 通道列表
        /// </summary>
        /// <return>List<MyChannelCfg></return>
        public static IEnumerable ChannelList { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public static IEnumerable SexList { get; set; }
        /// <summary>
        /// 通道类型
        /// </summary>
        public static IEnumerable ChannePropertiesList { get; set; }

        /// <summary>
        /// 告警数据是否显示大窗口
        /// </summary>
        public static bool Func_AlarmDoubleClick { get; set; }
        /// <summary>
        /// 自动登录
        /// </summary>
        public static bool Func_AutoSignin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static string NetworkMode { get; set; }
        /// <summary>
        /// 告警数据显示上限
        /// </summary>
        public static int AppearLimited { get; set; }
        /// <summary>
        /// 区域配置列表
        /// </summary>
        public static IEnumerable AreaInfoCollection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static double Longitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static double Latitude { get; set; }
        public static string AudioName { get; set; }
        public static int TSocketTimeout { get; set; }
        /// <summary>
        /// 工作人员离开电脑时长
        /// </summary>
        public static int LeaveTime { get; set; }
        /// <summary>
        /// 20170608 PK功能
        /// </summary>
        public static string AppFunction { get; set; }

        #region 临时解决方案

        //处理告警后摄像头能够长期变红
        public static IList<string> AlarmCamera { get; set; }

        public static Action GetTemplatePopWindow;

        //解决动态ip的问题
        public static object ChannelMgrObj { get; set; }

        /// <summary>
        /// 抓拍
        /// </summary>
        public static byte[] SnapStream { get; set; }
        /// <summary>
        /// 比对
        /// </summary>
        public static byte[] SnapCompareStream { get; set; }
        public static Object IdentifyResult { get; set; }

        public static long SelectedTimeout { get; set; }
        public static long SelectTimeout { get; set; }

        public static object MySnapFaceLogWithImgObj { get; set; }

        //
        public static IEnumerable FaceTypeList { get; set; }
        #endregion

        public void Dispose()
        {
        }
    }
}
