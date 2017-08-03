using System.Threading;
using System.Windows;
using Xiaowen.CodeStacks.PopWindow;
using Xiaowen.CodeStacks.Wpf.Utilities;

namespace CodeStacks.Test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //CodeStacksDynamic cd = new CodeStacksDynamic();
            //cd.TestMethod(1);
            //dynamic dynamic_cd = new CodeStacksDynamic();
            //string str = dynamic_cd.TestMethod(3);
            //dynamic_cd.TestMethod(3, 2, 1);






            //Thread.Sleep(1000);
            //CodeStacksMessageBox mb = new CodeStacksMessageBox(true);
            //mb.Show();

            //var screenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height.ToString();
            //var screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width.ToString();

            // CodeStacksDataHandler.ImageData.ConvertToBitmapImage;


            CodeStacksSecurity.VerifyMd5Hash("074626fc97e5388f84e1c651ae657be4", "074626fc97e5388f84e1c651ae657be4");
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
