using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
        /// <param name="isVertify"></param>
        /// <param name="isCompress"></param>
        /// <param name="isBreak"></param>
        /// <returns></returns>
        private BitmapImage ConvertToBitmapImageFunc(byte[] buffer, bool isVertify, bool isCompress, ref bool isBreak)
        {
            BitmapImage result = new BitmapImage();
            BitmapImage compressResult = new BitmapImage();
            byte[] compressBuffer = { };
            long capacity = this.GetBufferLength(buffer);
            try
            {
                if (capacity > 0 && capacity > 100)// compress to 0 - 100 KByte
                {
                    Stream stream = new MemoryStream(buffer);

                    try
                    {
                        if (isVertify)
                        {
                            try
                            {
                                using (Image img = Image.FromStream(stream)) { }
                            }
                            catch (Exception)
                            {
                                isBreak = true;
                            }
                        }

                        if (isCompress)//compress image
                        {
                            compressBuffer = ImageCompress(stream);
                            result.BeginInit();
                            result.StreamSource = new MemoryStream(compressBuffer);
                        }
                        else
                        {
                            result.BeginInit();
                            result.StreamSource = new MemoryStream(buffer);
                        }

                        result.EndInit();
                        result.Freeze();

                        isBreak = false;
                    }
                    catch (Exception)
                    {
                    }
                }
                else
                {
                    //null
                }
            }
            catch (Exception)
            {

            }
            return result;
        }

        /// <summary>
        /// Get Buffer Length
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public long GetBufferLength(byte[] buffer)
        {
            if (buffer != null && buffer.Length > 0)
                return buffer.Length;
            else
            {
                if (buffer == null)
                    return -1;
                else
                    return 0;
            }
        }

        /// <summary>
        /// return KByte
        /// </summary>
        /// <param name="bufferLength"></param>
        /// <returns></returns>
        public long ConvertBufferToKByte(long bufferLength)
        {
            if (bufferLength > 0)
                return bufferLength / 1024;
            else
                return 0;
        }

        /// <summary>
        /// return MByte
        /// </summary>
        /// <param name="bufferLength"></param>
        /// <returns></returns>
        public long ConvertBufferToMByte(long bufferLength)
        {
            if (bufferLength > 0)
                return (bufferLength / 1024) / 1024;
            else
                return 0;
        }

        /// <summary>
        /// compress photo
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public byte[] ImageCompress(Stream stream)
        {
            byte[] result = { };
            try
            {
                using (System.Drawing.Image img = System.Drawing.Image.FromStream(stream))
                {
                    int newWidth = (int)Math.Round(img.Width * 0.5);
                    int newHeight = (int)Math.Round(img.Height * 0.5);
                    using (Bitmap bitp = new Bitmap(newWidth, newHeight))
                    {
                        Graphics g = Graphics.FromImage(bitp);
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
                        g.DrawImage(img, new Rectangle(0, 0, newWidth, newHeight), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
                        g.Dispose();

                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitp.Save(ms, ImageFormat.Jpeg);
                            result = ms.ToArray();

                            if (result.Length / 1024 > 100)
                            {
                                result = ImageCompress(ms);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return result;
        }
    }
}
