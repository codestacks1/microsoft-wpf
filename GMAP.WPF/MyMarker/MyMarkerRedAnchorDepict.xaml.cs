using System.Windows.Controls;
using XIAOWEN.GMAP.ViewModels;

namespace XIAOWEN.GMAP.MyMarker
{
    /// <summary>
    /// Interaction logic for MyMarkerRedAnchorDepict.xaml
    /// </summary>
    public partial class MyMarkerRedAnchorDepict : UserControl
    {
        public MyMarkerRedAnchorDepict()
        {
            InitializeComponent();
            this.DataContext = MainWindowViewModel.SMainwindowViewModel.GeoTitle;
        }
    }
}
