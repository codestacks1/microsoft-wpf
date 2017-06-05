using System;
using System.Diagnostics;
using System.Windows;
using xiaowen.codestacks.popwindow;

namespace codestacks.mef.wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_SessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
            //Occurs when the user ends the windows session by logging off or shutting down the operating system
            string msg = string.Format("{0}.结束会话？", e.ReasonSessionEnding);
            bool result = CodeStacksWindow.MessageBox.Invoke(true, false, 0, msg);
            if (!result)
                e.Cancel = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            CodeStacksWindow.MessageBox.Invoke(false, false, 2, "存在未处理的数据异常...");
            //Prevent deault unhandled exception processing
            //remain app contiune running
            e.Handled = true;
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            try
            {
                Process.GetCurrentProcess().Kill();
                Environment.Exit(-1);
            }
            catch (Exception)
            {
            }
        }

    }
}
