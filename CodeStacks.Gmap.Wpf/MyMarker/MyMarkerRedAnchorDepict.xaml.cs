using System.Windows.Controls;
using xiaowen.codestacks.gmap.demo.Models;
using xiaowen.codestacks.wpf.ViewModels;

namespace xiaowen.codestacks.wpf.MyMarker
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
