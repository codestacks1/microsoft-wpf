using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Xiaowen.CodeStacks.Data.SenSingModels;
using Xiaowen.CodeStacks.UserControls.ViewModels;

namespace Xiaowen.CodeStacks.UserControls.Views
{
    /// <summary>
    /// Interaction logic for TreeViewX.xaml
    /// </summary>
    public partial class CodeStacksTreeView : UserControl
    {
        public CodeStacksTreeView()
        {
            InitializeComponent();
            this.DataContext = new CodeStacksTreeViewModel();
        }

        private void BarButtonItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CameraCategoryImageSelector : TreeListNodeImageSelector, IValueConverter
    {
        static CameraCategoryImageSelector()
        {
            ImageCache = new Dictionary<string, System.Windows.Media.ImageSource>();
        }
        static Dictionary<string, System.Windows.Media.ImageSource> ImageCache;
        public override System.Windows.Media.ImageSource Select(DevExpress.Xpf.Grid.TreeList.TreeListRowData rowData)
        {
            Camera empl = (rowData.Row as Camera);
            if (empl == null) return null;
            return GetImageByGroupName(empl.TypeValue);
        }

        public static ImageSource GetImageByGroupName(string groupName)
        {
            if (ImageCache.ContainsKey(groupName))
                return ImageCache[groupName];
            System.Windows.Media.ImageSource image = new BitmapImage(new Uri(GetImagePathByGroupName(groupName), UriKind.Relative));
            ImageCache.Add(groupName, image);
            return image;
        }

        public static List<string> images = new List<string> { "Normal", "White", "Black", "quality", "research", "sales" };
        public static string GetImagePathByGroupName(string groupName)
        {
            groupName = groupName.ToLower();
            foreach (string item in images)
            {
                if (groupName.Contains(item.ToLower()))
                {
                    return "/CodeStacks.UserControls;component/Categories/camera." + item.ToLower() + ".png";
                }
            }
            return groupName;
        }

        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return GetImagePathByGroupName((string)value);
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
