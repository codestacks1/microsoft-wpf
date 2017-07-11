﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Xiaowen.CodeStacks.Wpf.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public class CodeStacksImage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static BitmapImage GetDefault(byte[] buffer)
        {
            BitmapImage result = new BitmapImage();
            result.BeginInit();
            result.CreateOptions = BitmapCreateOptions.IgnoreColorProfile;
            result.StreamSource = new MemoryStream(buffer, true);
            result.EndInit();
            result.Freeze();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static BitmapImage GetDefault(string uri)
        {
            BitmapImage result = new BitmapImage();
            result.BeginInit();
            result.CreateOptions = BitmapCreateOptions.IgnoreColorProfile;
            //result.UriSource = new Uri(Xiaowen.CodeStacks.Data.CodeStacks.PackURI.);
            return result;
        }

        /// <summary>
        /// 压缩图片显示
        /// </summary>
        /// <param name="photoBuffer"></param>
        /// <returns></returns>
        public static BitmapImage ZipImage(byte[] photoBuffer, int zipSize)
        {
            BitmapImage result = new BitmapImage();
            byte[] _photoBuffer = { };
            try
            {
                Stream stream = new MemoryStream(photoBuffer);
                using (Image img = Image.FromStream(stream))
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
                            bitp.Save(ms, ImageFormat.Png);
                            _photoBuffer = ms.ToArray();

                            if (_photoBuffer.Length / 1024 > zipSize)
                            {
                                ZipImage(_photoBuffer, zipSize);
                            }
                        }
                    }
                }

                result.BeginInit();
                result.CreateOptions = BitmapCreateOptions.IgnoreColorProfile;
                result.StreamSource = new MemoryStream(_photoBuffer);
                result.EndInit();
                result.Freeze();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        /// <summary>
        /// 将路径下的图片转换为buffer
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static byte[] GetBuffer(params string[] uri)
        {
            byte[] result = { };
            if (!string.IsNullOrEmpty(uri[0]))
            {
                try
                {
                    BitmapImage myBitmapImage = new BitmapImage();
                    myBitmapImage.BeginInit();
                    myBitmapImage.CreateOptions = BitmapCreateOptions.IgnoreColorProfile;
                    myBitmapImage.UriSource = new Uri(uri[0]);
                    myBitmapImage.EndInit();

                    PngBitmapEncoder png = new PngBitmapEncoder();
                    png.Frames.Add(BitmapFrame.Create(myBitmapImage));
                    using (MemoryStream ms = new MemoryStream())
                    {
                        png.Save(ms);
                        result = ms.ToArray();
                    }

                    //using (FileStream fs = new FileStream(uri, FileMode.Open, FileAccess.Read))
                    //{
                    //    byte[] buffer = new byte[fs.Length];
                    //    fs.Read(buffer, 0, buffer.Length);
                    //    result = buffer;
                    //}
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
            return result;
        }
    }
}
