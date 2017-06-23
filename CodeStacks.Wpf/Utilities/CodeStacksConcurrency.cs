using System;
using System.Threading;

namespace Xiaowen.CodeStacks.Wpf.Utilities
{
    /// <summary>
    /// 并发处理
    /// </summary>
    public class CodeStacksConcurrency
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
