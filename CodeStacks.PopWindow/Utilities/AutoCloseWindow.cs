using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace xiaowen.codestacks.popwindow.Utilities
{
    public class AutoCloseWindow
    {
        /// <summary>
        /// Close Current Window
        /// </summary>
        /// <param name="window"></param>
        /// <param name="delay"></param>
        internal static async void CloseWindow(Window window, double delay)
        {
            await Task.Delay(TimeSpan.FromSeconds(delay));
            try
            {
                window.Close();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="window"></param>
        /// <param name="grid"></param>
        /// <param name="linearGradientBrush"></param>
        /// <param name="storyboard"></param>
        /// <param name="delay"></param>
        internal static async void CloseWindow(Window window, Grid grid, string linearGradientBrush, string storyboard, double delay)
        {
            await Task.Delay(TimeSpan.FromSeconds(delay));
            try
            {
                window.IsEnabled = false;
                grid.OpacityMask = window.Resources[linearGradientBrush] as LinearGradientBrush;
                Storyboard stb = window.Resources[storyboard] as Storyboard;
                stb.Completed += delegate { window.Close(); };

                stb.Begin();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errMsg"></param>
        public static void ExceptionMsgFromSTAThread(string errMsg)
        {
            Thread msgThread = new Thread(() => {/* MyMessage.ShowAndAutoClose(errMsg);*/ });
            msgThread.SetApartmentState(ApartmentState.STA);
            msgThread.Start();
        }


    }
}
