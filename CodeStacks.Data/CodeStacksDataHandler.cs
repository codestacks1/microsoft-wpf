using GalaSoft.MvvmLight.Threading;
using System;
using Xiaowen.CodeStacks.Data.DataHandler;
using Xiaowen.CodeStacks.Data.UIHelper;

namespace Xiaowen.CodeStacks.Data
{
    public class CodeStacksDataHandler
    {
        static long i = 0;
        static PixelData _pixelData;
        /// <summary>
        /// current screen handler
        /// </summary>
        public static PixelData PixelData
        {
            get { return _pixelData = new PixelData(); }
        }

        static ImageData _imageData;
        /// <summary>
        /// image handler
        /// </summary>
        public static ImageData ImageData
        {
            get { return _imageData = new ImageData(); }
        }

        static DateTimeData _dateTimeData;
        /// <summary>
        /// datetime handler
        /// </summary>
        public static DateTimeData DateTimeData
        {
            get { return _dateTimeData = new DateTimeData(); }
        }

        static Action<Action> _uiThread;
        /// <summary>
        /// ui thread
        /// </summary>
        public static Action<Action> UIThread
        {
            get
            {
                if (i == 0)
                {
                    DispatcherHelper.Initialize();
                    i = 1;
                }
                return _uiThread = DispatcherHelper.CheckBeginInvokeOnUI;
            }
        }

        public static void InitUIThread()
        {
            DispatcherHelper.Initialize();
        }

        public void CodeStacksFunc()
        {
            bool? is3 = false;
            CodeStacksDataHandler.ImageData.ConvertToBitmapImageDelegate.Invoke(null, false, false, ref is3);
        }
    }
}
