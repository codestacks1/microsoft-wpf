using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using xiaowen.codestacks.data.DataHandler;
using xiaowen.codestacks.data.UIHelper;

namespace xiaowen.codestacks.data
{
    public class CodeStacksDataHandler
    {
        static PixelData _pixelData;
        /// <summary>
        /// current screen handler
        /// </summary>
        public static PixelData PixelData
        {
            get { return _pixelData; }
            private set { _pixelData = new PixelData(); }
        }

        static ImageData _imageData;
        /// <summary>
        /// image handler
        /// </summary>
        public static ImageData ImageData
        {
            get { return _imageData; }
            private set { _imageData = new ImageData(); }
        }

        static DateTimeData _dateTimeData;
        /// <summary>
        /// datetime handler
        /// </summary>
        public static DateTimeData DateTimeData
        {
            get { return _dateTimeData; }
            private set { _dateTimeData = new DateTimeData(); }
        }

        static Action<Action> _uiThread;
        /// <summary>
        /// ui thread
        /// </summary>
        public static Action<Action> UIThread
        {
            get { return _uiThread; }
            set
            {
                DispatcherHelper.Initialize();
                _uiThread = DispatcherHelper.CheckBeginInvokeOnUI;
            }
        }

        public void CodeStacksFunc()
        {
            bool? is3 = false;
            CodeStacksDataHandler.ImageData.ConvertToBitmapImageDelegate.Invoke(null, false, false, ref is3);
        }
    }
}
