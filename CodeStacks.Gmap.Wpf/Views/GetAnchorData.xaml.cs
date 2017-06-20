using GMap.NET;
using GMap.NET.WindowsPresentation;
using System.Windows.Controls;
using xiaowen.codestacks.wpf.ViewModels;

namespace xiaowen.codestacks.wpf.Views
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
            MainWindowViewModel.SMainwindowViewModel.MyMapControl.ReSet();
        }

        private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
