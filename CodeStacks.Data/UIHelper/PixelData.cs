using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xiaowen.codestacks.data.UIHelper
{
    /// <summary>
    /// pixel handler
    /// </summary>
    public class PixelData
    {
        /// <summary>
        /// 
        /// </summary>
        internal PixelData()
        {
            this.ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
            this.ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
        }

        /// <summary>
        /// screen height of current run envirenment
        /// </summary>
        public int ScreenHeight { get; private set; }

        /// <summary>
        /// screen width of current run envirenment
        /// </summary>
        public int ScreenWidth { get; private set; }




    }
}
