using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace xiaowen.codestacks.wpf.Utilities
{
    /// <summary>
    /// 并发处理
    /// </summary>
    public class ConcurrencyHandler
    {
        /// <summary>
        /// 执行单线程函数
        /// </summary>
        /// <param name="startFunc"></param>
        public static Action<ParameterizedThreadStart> SetSTAThread { get { return _SetSTAThread; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startFunc"></param>
        static void _SetSTAThread(ParameterizedThreadStart startFunc)
        {
            try
            {
                Thread thread = new Thread(startFunc);
                thread.SetApartmentState(ApartmentState.STA);
                thread.IsBackground = true;
                thread.Start();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
