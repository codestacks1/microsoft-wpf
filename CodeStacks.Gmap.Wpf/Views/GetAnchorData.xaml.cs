using GMap.NET;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Xiaowen.CodeStacks.PopWindow.Views;
using Xiaowen.CodeStacks.Wpf.Gmap.ViewModels;

namespace Xiaowen.CodeStacks.Wpf.Gmap.Views
{
    /// <summary>
    /// Interaction logic for GetAnchorData.xaml
    /// </summary>
    public partial class GetAnchorData : UserControl
    {
        public GetAnchorData()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindowViewModel.SMainwindowViewModel.MyMapControl.ReSet(new PointLatLng());
        }

        private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        Popup popup = new Popup();
        private void TextBlock_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!popup.IsOpen)
            {
                popup.Child = new CodeStacksHintControlView(popup, "暂不支持无锚点重置");
                popup.IsOpen = true;
            }
        }

        private void TextBlock_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            popup.IsOpen = false;
        }        
    }
}
