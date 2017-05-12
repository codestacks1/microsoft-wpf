using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using XIAOWEN.GMAP.DEMO;
using XIAOWEN.GMAP.MyMarker;
using XIAOWEN.GMAP.ViewModels;

namespace XIAOWEN.GMAP.Views.UserControls
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

            // set cache mode only if no internet avaible
            //www.amap.com
            //pingtest.com
            if (!Stuff.PingNetwork("pingtest.com"))
            {
                MainMap.Manager.Mode = AccessMode.CacheOnly;
                MessageBox.Show("No internet connection available, going to CacheOnly mode.", "XIAOWEN.GMap", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            //// config map
            MainMap.MapProvider = GMapProviders.BingHybridMap;//OpenStreetMap
            MainMap.Position = new PointLatLng(32.064, 118.704);
            MainMap.ScaleMode = ScaleModes.Dynamic;
            currentMarker = new GMapMarker(MainMap.Position);
            {
                currentMarker.Shape = new MyMarkerRedAnchor(this, currentMarker, "Xiaowen");
                currentMarker.Offset = new System.Windows.Point(-15, -15);
                currentMarker.ZIndex = int.MaxValue;
                MainMap.Markers.Add(currentMarker);
            }

            #region InitialGeographic
            MainWindowViewModel.SMainwindowViewModel.GeoData.Langitude = 118.704;
            MainWindowViewModel.SMainwindowViewModel.GeoData.Latitude = 32.064;
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

            MainWindowViewModel.SMainwindowViewModel.MyMapControl = this;
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
