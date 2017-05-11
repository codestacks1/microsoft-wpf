using CodeStacks.Data.DataHandler;
using CodeStacks.Data.UIHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CodeStacks.Data
{
    public class CodeStacksDataHandler
    {
        static PixelData _pixelData;
        public static PixelData PixelData
        {
            get { return _pixelData; }
            private set { _pixelData = new PixelData(); }
        }

        static ImageData _imageData;
        public static ImageData ImageData
        {
            get { return _imageData; }
            private set { _imageData = new ImageData(); }
        }

        static DateTimeData _dateTimeData;
        public static DateTimeData DateTimeData
        {
            get { return _dateTimeData; }
            private set { _dateTimeData = new DateTimeData(); }
        }

        public void CodeStacksFunc()
        {
            Func<byte[], BitmapImage> f = CodeStacksDataHandler.ImageData.ConvertToBitmapImage;
            var s = f.Invoke(null);
        }
    }
}
