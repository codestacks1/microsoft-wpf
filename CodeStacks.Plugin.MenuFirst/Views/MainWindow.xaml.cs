using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Windows;
using Xiaowen.CodeStacks.Data.Interfaces;
using Xiaowen.CodeStacks.Data.Models.GMap;

namespace codectacks.plugin.menufirst.Views
{
    [Export(typeof(IMainWindowContract))]
    [ExportMetadata("Title", "Plugin.GMap")]
    [ExportMetadata("MenuText", "地图")]
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindowContract
    {
        public MainWindow()
        {
            InitializeComponent();

            //MyMap.Points.Add(new GMap.NET.PointLatLng(39.9719321233495, 116.337801218033, string.Empty, null, new GeoTitle() { IsVisible = Visibility.Collapsed, Content1 = "content1", Content1Visible = Visibility.Visible }));

            MyMap.Points = new ObservableCollection<GMap.NET.PointLatLng>();

            MyMap.Points.Add(new GMap.NET.PointLatLng(39.9719321233495, 116.337801218033, "Red", null, new GeoTitle() { IsVisible = Visibility.Collapsed, Content1 = "content1", Content1Visible = Visibility.Visible }, null));

            //for (int i = 0; i < 10; i++)
            //{
            //    MyMap.Points.Add(new GMap.NET.PointLatLng(39.9719321233495, 116.337801218033 + i, "Camera", CodeStacksDataHandler.ImageData.ConvertToImageSourceDelegate1("pack://application:,,,/Images/camera-blue.png"), new GeoTitle() { Content1 = "content1", Content1Visible = Visibility.Visible }));
            //}

            //for (int i = 0; i < 10; i++)
            //{
            //    MyMap.Points.Add(new GMap.NET.PointLatLng(39.2719321233495 + i, 116.337801218033 + i, "Photo", CodeStacksDataHandler.ImageData.ConvertToImageSourceDelegate1("pack://application:,,,/Images/test1.png"), new GeoTitle() { Content1 = "content1", Content1Visible = Visibility.Visible }));
            //}

        }

        public string MenuItemText
        {
            get { return "地图"; }
        }

        public string SubWindowTitle
        {
            get { return "Plugin.GMap"; }
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
