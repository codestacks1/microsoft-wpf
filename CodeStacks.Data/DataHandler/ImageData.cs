using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Xiaowen.CodeStacks.Data.DataHandler
{
    /// <summary>
    /// 
    /// </summary>
    public class ImageData
    {
        internal ImageData()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="isVertify"></param>
        /// <param name="isCompress"></param>
        /// <param name="isBreak"></param>
        /// <returns></returns>
        public delegate BitmapImage CodeStacksDelegate(byte[] buffer, bool? isVertify, bool isCompress, ref bool? isBreak);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public delegate BitmapImage CodeStacksDelegate1(byte[] buffer);

        /// <summary>
        /// photo 转换成 buffer
        /// </summary>
        /// <param name="path">绝对路径 pack://application:,,,/Images/unkonw.png</param>
        /// <returns></returns>
        public Func<string, byte[]> ConvertToBufferDelegate
        {
            get { return this.ConvertToBufferFunc; }
        }

        /// <summary>
        /// photo 转换成 buffer
        /// </summary>
        /// <param name="path">绝对路径 pack://application:,,,/Images/unkonw.png</param>
        /// <returns></returns>
        public Func<string, byte[]> ConvertToBuffer1Delegate
        {
            get { return this.ConvertToBuffer1Func; }
        }

        /// <summary>
        /// photo 转换成 ImageSource
        /// </summary>
        /// <param name="path">绝对路径 pack://application:,,,/Images/unkonw.png</param>
        /// <returns></returns>
        public Func<string, ImageSource> ConvertToImageSourceDelegate
        {
            get { return this.ConvertToImageSourceFunc; }
        }

        /// <summary>
        /// photo 转换成 BitmapImage
        /// </summary>
        /// <param name="path">绝对路径 pack://application:,,,/Images/unkonw.png</param>
        /// <returns></returns>
        public Func<string, BitmapImage> ConvertToImageSourceDelegate1
        {
            get { return this.ConvertToBitmapImageFunc; }
        }

        /// <summary>
        /// image buffer 转换成 BitmapImage
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="isVertify"></param>
        /// <param name="isCompress"></param>
        /// <param name="isBreak"></param>
        /// <returns></returns>
        public CodeStacksDelegate ConvertToBitmapImageDelegate
        {
            get { return this.ConvertToBitmapImageFunc; }
        }

        /// <summary>
        /// image buffer 转换成 BitmapImage
        /// 默认使用验证，压缩
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public CodeStacksDelegate1 ConvertToBitmapImageDelegate1
        {
            get { return this.ConvertToBitmapImageFunc; }
        }

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
        /// <param name="path"></param>
        /// <returns></returns>
        private byte[] ConvertToBuffer1Func(string path)
        {
            byte[] result = { };
            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    Uri uri = new Uri(path, UriKind.Absolute);
                    string s = Uri.UriSchemeFile;
                    CodeStacksDataHandler.UIThread.Invoke(() =>
                    {
                        FileStyleUriParser f = new FileStyleUriParser();
                        UriParser up = f;

                        
                        

                        using (FileStream fs = new FileStream(uri.PathAndQuery, FileMode.Open, FileAccess.Read))
                        {
                            byte[] buffer = new byte[fs.Length];
                            fs.Read(buffer, 0, buffer.Length);
                            result = buffer;
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
            return result;
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
                BitmapImage myBitmapImage = new BitmapImage();
                myBitmapImage.BeginInit();
                myBitmapImage.CreateOptions = BitmapCreateOptions.IgnoreColorProfile;
                myBitmapImage.UriSource = new Uri(path, UriKind.Absolute);
                myBitmapImage.EndInit();
                result = myBitmapImage;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private BitmapImage ConvertToBitmapImageFunc(string path)
        {
            BitmapImage result = null;
            try
            {
                BitmapImage myBitmapImage = new BitmapImage();
                myBitmapImage.BeginInit();
                myBitmapImage.CreateOptions = BitmapCreateOptions.IgnoreColorProfile;
                myBitmapImage.UriSource = new Uri(path);
                myBitmapImage.EndInit();
                result = myBitmapImage;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
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
        private BitmapImage ConvertToBitmapImageFunc(byte[] buffer, bool? isVertify, bool isCompress, ref bool? isBreak)
        {
            BitmapImage result = new BitmapImage();
            BitmapImage compressResult = new BitmapImage();
            byte[] compressBuffer = { };
            long capacity = this.GetBufferLength(buffer);
            try
            {
                if (capacity > 0 && capacity > 500)// compress to 0 - 100 KByte
                {
                    Stream stream = new MemoryStream(buffer);

                    if (isVertify != null && isVertify == true)
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
                        result.CreateOptions = BitmapCreateOptions.IgnoreColorProfile;
                        result.StreamSource = new MemoryStream(compressBuffer);
                    }
                    else
                    {
                        result.BeginInit();
                        result.CreateOptions = BitmapCreateOptions.IgnoreColorProfile;
                        result.StreamSource = new MemoryStream(buffer);
                    }

                    result.EndInit();
                    result.Freeze();

                    isBreak = false;
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
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        private BitmapImage ConvertToBitmapImageFunc(byte[] buffer)
        {
            BitmapImage result = new BitmapImage();
            BitmapImage compressResult = new BitmapImage();
            byte[] compressBuffer = { };
            long capacity = this.GetBufferLength(buffer);
            try
            {
                if (capacity > 0 && capacity > 500)// compress to 0 - 100 KByte
                {
                    Stream stream = new MemoryStream(buffer);
                    using (Image img = Image.FromStream(stream))
                    {
                        compressBuffer = ImageCompress(stream);
                        result.BeginInit();
                        result.CreateOptions = BitmapCreateOptions.IgnoreColorProfile;
                        result.StreamSource = new MemoryStream(compressBuffer);
                        result.EndInit();
                        result.Freeze();
                    }
                }
                else
                {
                    //null
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
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
        private byte[] ImageCompress(Stream stream)
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

                            if (result.Length / 1024 > 500)
                            {
                                result = ImageCompress(ms);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }
    }
}
