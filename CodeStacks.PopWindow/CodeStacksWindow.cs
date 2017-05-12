using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xiaowen.codestacks.data;
using xiaowen.codestacks.popwindow.Views;

namespace xiaowen.codestacks.popwindow
{
    public class CodeStacksWindow
    {
        static Func<bool, bool, int, string, bool> _messageBox;
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


    }
}
