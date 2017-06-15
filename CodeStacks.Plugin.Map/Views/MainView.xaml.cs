using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using xiaowen.codestacks.data.Interfaces;
using xiaowen.codestacks.gmap.demo.Models;
using System.Windows;

namespace CodeStacks.Plugin.Map.Views
{
    [Export(typeof(IMainWindowContract))]
    [ExportMetadata("Title", "Plugin.Map")]
    [ExportMetadata("MenuText", "AMap")]
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl, IMainWindowContract
    {
        public MainView()
        {
            InitializeComponent();
            this.Loaded += MainView_Loaded;
        }

        private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            MainMap.Points = new ObservableCollection<GMap.NET.PointLatLng>();

            MainMap.Points.Add(new GMap.NET.PointLatLng(39.9719321233495, 116.337801218033, "Red", null, new GeoTitle() { IsVisible = Visibility.Collapsed, Content1 = "content1", Content1Visible = Visibility.Visible }));
        }

        public string MenuItemText
        {
            get { return "AMap"; }
        }

        public string SubWindowTitle
        {
            get { return "Plugin.Map"; }
        }
    }
}
