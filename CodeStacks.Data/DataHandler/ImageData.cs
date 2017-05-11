using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace CodeStacks.Data.DataHandler
{
    public class ImageData
    {
        internal ImageData()
        {

        }

        public Func<string, byte[]> ConvertToBuffer { get; private set; }
        public Func<string, ImageSource> ConvertToImageSource { get; private set; }
        public Func<byte[], BitmapImage> ConvertToBitmapImage { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">绝对路径 pack://application:,,,/Images/unkonw.png</param>
        /// <returns></returns>
        private byte[] ConvertToBufferFunc(string path)
        {
            return File.ReadAllBytes(path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">绝对路径 pack://application:,,,/Images/unkonw.png</param>
        /// <returns></returns>
        private ImageSource ConvertToImageSourceFunc(string path)
        {
            ImageSource result = null;
            try
            {
                ImageSourceConverter imgConvert = new ImageSourceConverter();
                result = (ImageSource)imgConvert.ConvertFrom(Application.GetResourceStream(new Uri(path)));
            }
            catch (Exception)
            {
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        private BitmapImage ConvertToBitmapImageFunc(byte[] buffer, bool isVertify)
        {
            BitmapImage result = new BitmapImage();
            try
            {

            }
            catch (Exception)
            {

            }

            return result;
        }




    }
}
