using System;
using System.Threading;
using System.Threading.Tasks;
using xiaowen.codestacks.data;
using xiaowen.codestacks.popwindow.Views;

namespace xiaowen.codestacks.popwindow
{
    public class CodeStacksWindow
    {
        static Func<bool, bool, int, string, bool> _messageBox;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isConfirm">弹出可操作窗口</param>
        /// <param name="isAnimation">是否启用动画窗口</param>
        /// <param name="delay"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public static Func<bool, bool, int, string, bool> MessageBox
        {
            get
            {
                CodeStacksDataHandler.UIThread.Invoke(() =>
                {
                    _messageBox = new Func<bool, bool, int, string, bool>(CodeStacksMessageBox.ShowMessageBox);
                });

                return _messageBox;
            }
        }


        static Func<bool, bool, int, string, bool> _messageBoxSta;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isConfirm">弹出可操作窗口</param>
        /// <param name="isAnimation">是否启用动画窗口</param>
        /// <param name="delay"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public static Func<bool, bool, int, string, bool> MessageBoxSta
        {
            get
            {
                //必须使用该方式
                //否则报告错误：Additional information: The calling thread must be STA, because many UI components require this.
                bool isComplete = ThreadPool.QueueUserWorkItem((obj) =>
                 {
                     CodeStacksDataHandler.UIThread.Invoke(() =>
                     {
                         _messageBoxSta = new Func<bool, bool, int, string, bool>(CodeStacksMessageBox.ShowMessageBox);
                     });
                 }, null);

                _messageBoxSta = AwaitComplete().Result;

                return _messageBoxSta;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static async Task<Func<bool, bool, int, string, bool>> AwaitComplete()
        {
            Func<bool, bool, int, string, bool> result = null;
            return await Task<Func<bool, bool, int, string, bool>>.Run(() =>
            {
                CodeStacksDataHandler.UIThread.Invoke(() =>
                {
                    result = new Func<bool, bool, int, string, bool>(CodeStacksMessageBox.ShowMessageBox);
                });
                return result;
            });
        }

    }
}
