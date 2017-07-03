using System;
using System.Windows;
using System.Windows.Input;

namespace Xiaowen.CodeStacks.Wpf.Utilities
{
    /// <summary>
    /// wpf 功能性操作
    /// </summary>
    public class CodeStacksWiew
    {
        /// <summary>
        /// 退出应用程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void OnClose(object sender, KeyEventArgs e)
        {
            if (e.KeyboardDevice.Modifiers.CompareTo(ModifierKeys.Control) == 0 && e.Key == Key.Delete)
            {
                Application.Current.Shutdown();
                Environment.Exit(0);
            }
        }
    }
}
