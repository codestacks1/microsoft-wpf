using System.Windows.Controls;
using Xiaowen.CodeStacks.Data.Models.GMap;

namespace Xiaowen.CodeStacks.Wpf.Gmap.MyMarker
{
    /// <summary>
    /// Interaction logic for MyMarkerRedAnchorDepict.xaml
    /// </summary>
    public partial class MyMarkerRedAnchorDepict : UserControl
    {
        public MyMarkerRedAnchorDepict()
        {
            InitializeComponent();
        }

        public MyMarkerRedAnchorDepict(GeoTitle title) : this()
        {
            this.DataContext = title;
        }
    }
}
