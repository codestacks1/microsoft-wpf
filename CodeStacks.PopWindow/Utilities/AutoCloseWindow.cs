using System;
using System.Threading.Tasks;
using System.Windows;

namespace xiaowen.codestacks.popwindow.Utilities
{
    public class AutoCloseWindow
    {
        /// <summary>
        /// Close Current Window
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="delay"></param>
        internal static async void CloseWindow(Window obj, double delay)
        {
            await Task.Delay(TimeSpan.FromSeconds(delay));
            try
            {
                obj.Close();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }
    }
}
