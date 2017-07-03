using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.CodeStacks.Wpf.Utilities
{
    /// <summary>
    /// 日志处理
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CodeStacksLogger<T> where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        public static ILog Log
        {
            get { return LogManager.GetLogger(typeof(T)); }
        }

        /// <summary>
        /// 
        /// </summary>
        private CodeStacksLogger() { }

        /// <summary>
        /// 初始化日志
        /// </summary>
        public static void InitLogger()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
