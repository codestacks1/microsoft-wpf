﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Xiaowen.CodeStacks.Data;
using Xiaowen.CodeStacks.PopWindow.Views;

namespace Xiaowen.CodeStacks.PopWindow
{
    public class CodeStacksWindow
    {
        static Func<bool, bool, double, string, bool> _messageBox;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isConfirm">弹出可操作窗口</param>
        /// <param name="isAnimation">是否启用动画窗口</param>
        /// <param name="delay"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public static Func<bool, bool, double, string, bool> MessageBox
        {
            get
            {
                CodeStacksDataHandler.UIThread.Invoke(() =>
                {
                    _messageBox = new Func<bool, bool, double, string, bool>(CodeStacksMessageBox.ShowMessageBox);
                });

                return _messageBox;
            }
        }


        static Func<bool, bool, double, string, bool> _messageBoxSta;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isConfirm">弹出可操作窗口</param>
        /// <param name="isAnimation">是否启用动画窗口</param>
        /// <param name="delay"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public static Func<bool, bool, double, string, bool> MessageBoxSta
        {
            get
            {
                //必须使用该方式
                //否则报告错误：Additional information: The calling thread must be STA, because many UI components require this.
                bool isComplete = ThreadPool.QueueUserWorkItem((obj) =>
                 {
                     CodeStacksDataHandler.UIThread.Invoke(() =>
                     {
                         _messageBoxSta = new Func<bool, bool, double, string, bool>(CodeStacksMessageBox.ShowMessageBox);
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
        static async Task<Func<bool, bool, double, string, bool>> AwaitComplete()
        {
            Func<bool, bool, double, string, bool> result = null;
            return await Task<Func<bool, bool, double, string, bool>>.Run(() =>
            {
                CodeStacksDataHandler.UIThread.Invoke(() =>
                {
                    result = new Func<bool, bool, double, string, bool>(CodeStacksMessageBox.ShowMessageBox);
                });
                return result;
            });
        }

    }
}
