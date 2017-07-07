using System.Windows.Media;

namespace Xiaowen.CodeStacks.Wpf.Utilities
{
    public class CodeStacksBrush
    {
        /// <summary>
        /// 
        /// </summary>
        public SolidColorBrush SetRgbColor(byte r, byte g, byte b)
        {
            return new SolidColorBrush(Color.FromRgb(r, g, b));
        }
    }
}
