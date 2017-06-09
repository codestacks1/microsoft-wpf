using GMap.NET.WindowsPresentation;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Windows;
using xiaowen.codestacks.data;
using xiaowen.codestacks.data.Interfaces;
using xiaowen.codestacks.gmap.demo.Models;

namespace codectacks.plugin.menufirst.Views
{
    [Export(typeof(IMainWindowContract))]
    [ExportMetadata("Title", "Plugin.First")]
    [ExportMetadata("MenuText", "FirstMenu")]
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
            MyMap.Route = new xiaowen.codestacks.wpf.Views.UserControls.Route() { IsRoute = true, delay = 3 };

            //for (int i = 0; i < 10; i++)
            //{
            //    MyMap.Points.Add(new GMap.NET.PointLatLng(39.9719321233495, 116.337801218033 + i, "Camera", CodeStacksDataHandler.ImageData.ConvertToImageSourceDelegate1("pack://application:,,,/Images/camera-blue.png"), new GeoTitle() { Content1 = "content1", Content1Visible = Visibility.Visible }));
            //}

            for (int i = 0; i < 10; i++)
            {
                MyMap.Points.Add(new GMap.NET.PointLatLng(39.2719321233495 + i, 116.337801218033 + i, "Photo", CodeStacksDataHandler.ImageData.ConvertToImageSourceDelegate1("pack://application:,,,/Images/test1.png"), new GeoTitle() { Content1 = "content1", Content1Visible = Visibility.Visible }));
            }



        }

        public string MenuItemText
        {
            get { return "FirstMenu"; }
        }

        public string SubWindowTitle
        {
            get { return "Plugin.First"; }
        }

    }
}
