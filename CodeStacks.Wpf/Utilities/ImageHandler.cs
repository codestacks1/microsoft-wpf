using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Xiaowen.CodeStacks.Data;

namespace Xiaowen.CodeStacks.Wpf.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public class ImageHandler
    {
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

        public static BitmapImage GetDefault(string uri)
        {
            BitmapImage result = new BitmapImage();
            result.BeginInit();
            result.CreateOptions = BitmapCreateOptions.IgnoreColorProfile;
            //result.UriSource = new Uri(Xiaowen.CodeStacks.Data.CodeStacks.PackURI.);
            return result;
        }
    }
}
