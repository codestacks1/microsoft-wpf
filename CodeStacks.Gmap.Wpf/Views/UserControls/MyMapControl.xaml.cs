using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using xiaowen.codestacks.gmap.demo;
using xiaowen.codestacks.wpf.MyMarker;
using xiaowen.codestacks.wpf.ViewModels;

namespace xiaowen.codestacks.wpf.Views.UserControls
{
    /// <summary>
    /// Interaction logic for MyMapControl.xaml
    /// </summary>
    public partial class MyMapControl : UserControl
    {
        GMapMarker currentMarker;

        public MyMapControl()
        {
            InitializeComponent();

            this.DataContext = new MainWindowViewModel();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            MainMap.Markers.Clear();
            // set cache mode only if no internet avaible
            //www.amap.com
            //pingtest.com
            if (!Stuff.PingNetwork("ditu.amap.com"))
            {
                MainMap.Manager.Mode = AccessMode.ServerAndCache;
                MessageBox.Show("No internet connection available, going to CacheOnly mode.", "xiaowen.codestacks.wpf", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            MainMap.Manager.Mode = AccessMode.ServerAndCache;
            MainMap.DragButton = MouseButton.Left;

            //// config map
            MainMap.MapProvider = GMapProviders.AMapHybridMap;//OpenStreetMap
            MainMap.Position = new PointLatLng(39.9719321233495, 116.337801218033);
            MainMap.ScaleMode = ScaleModes.Dynamic;
            currentMarker = new GMapMarker(MainMap.Position);
            {
                currentMarker.Shape = new MyMarkerRedAnchor(this, currentMarker, "Xiaowen");
                currentMarker.Offset = new System.Windows.Point(-15, -15);
                currentMarker.ZIndex = int.MaxValue;
            }

            #region InitialGeographic
            MainWindowViewModel.SMainwindowViewModel.GeoData.Langitude = 116.337801218033;
            MainWindowViewModel.SMainwindowViewModel.GeoData.Latitude = 39.9719321233495;
            #endregion

            //// map events
            //MainMap.OnPositionChanged += new PositionChanged(MainMap_OnCurrentPositionChanged);
            //MainMap.OnTileLoadComplete += new TileLoadComplete(MainMap_OnTileLoadComplete);
            //MainMap.OnTileLoadStart += new TileLoadStart(MainMap_OnTileLoadStart);
            //MainMap.OnMapTypeChanged += new MapTypeChanged(MainMap_OnMapTypeChanged);
            //MainMap.MouseMove += new System.Windows.Input.MouseEventHandler(MainMap_MouseMove);
            //MainMap.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(MainMap_MouseLeftButtonDown);
            //MainMap.MouseEnter += new MouseEventHandler(MainMap_MouseEnter);

            //if (MainMap.Markers.Count > 1)
            //{
            //    MainMap.ZoomAndCenterMarkers(null);
            //}

            MainMap.Markers.Add(currentMarker);
            MainMap.Zoom = 13;
            MainWindowViewModel.SMainwindowViewModel.MyMapControl = this;
        }


        public void ReSet()
        {
            currentMarker = null;
            UserControl_Loaded(null, null);
        }

        private void MainMap_MouseEnter(object sender, MouseEventArgs e)
        {
        }

        private void MainMap_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void MainMap_OnMapTypeChanged(GMapProvider type)
        {
        }

        private void MainMap_OnTileLoadStart()
        {
        }

        private void MainMap_OnTileLoadComplete(long ElapsedMilliseconds)
        {
        }

        private void MainMap_OnCurrentPositionChanged(PointLatLng point)
        {
        }


    }
}
