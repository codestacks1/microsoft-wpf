
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using xiaowen.codestacks.popwindow;
using xiaowen.codestacks.popwindow.Views;

namespace CodeStacks.Test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Thread.Sleep(1000);
            //CodeStacksMessageBox mb = new CodeStacksMessageBox(true);
            //mb.Show();

            var screenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height.ToString();
            var screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width.ToString();

            // CodeStacksDataHandler.ImageData.ConvertToBitmapImage;
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {

        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            //处理未处理的异常，e.Handled = true;

            e.Handled = true;
        }

        private void Application_SessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
            string msg = string.Format("{0}。结束回话？", e.ReasonSessionEnding);
            if (!CodeStacksWindow.MessageBox.Invoke(true, false, 0, msg))
            {
                e.Cancel = true;
            }
        }
    }
}
