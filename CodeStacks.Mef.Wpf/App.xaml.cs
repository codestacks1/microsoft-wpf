using System;
using System.Diagnostics;
using System.Windows;
using xiaowen.codestacks.popwindow;

namespace CodeStacks.Mef.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// app startup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {

        }

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
            //Prevent deault unhandled exception processing
            //remain app contiune running
            e.Handled = true;
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            //Process.GetCurrentProcess().Kill();
            Environment.Exit(0);
        }
    }
}
