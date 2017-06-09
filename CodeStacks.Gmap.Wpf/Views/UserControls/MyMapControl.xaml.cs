using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using xiaowen.codestacks.gmap.demo;
using xiaowen.codestacks.gmap.demo.Models;
using xiaowen.codestacks.gmap.wpf.MyMarker;
using xiaowen.codestacks.popwindow;
using xiaowen.codestacks.wpf.MyMarker;
using xiaowen.codestacks.wpf.ViewModels;

namespace xiaowen.codestacks.wpf.Views.UserControls
{
    public class Route
    {
        bool _isRoute = false;
        public bool IsRoute { get { return _isRoute; } set { _isRoute = value; } }
                
        public int Delay { get; set; }
    }

    /// <summary>
    /// Interaction logic for MyMapControl.xaml
    /// </summary>
    public partial class MyMapControl : UserControl
    {
        #region Map Public Property
        /// <summary>
        /// 标记锚点的坐标集合
        /// </summary>
        public ObservableCollection<PointLatLng> Points { get; set; }

        /// <summary>
        /// 刷新地图，并加载锚点
        /// </summary>
        public Action<object, RoutedEventArgs> MapRefresh
        {
            get { return UserControl_Loaded; }
        }

        /// <summary>
        /// 定位锚点到地图可是范围中心
        /// </summary>
        public Action<PointLatLng> Position
        {
            get
            {
                return (point) =>
                {
                    MainMap.Position = point;
                };
            }
        }

        /// <summary>
        /// 设置锚点点击事件
        /// </summary>
        public Action<object, MouseButtonEventArgs> MouseLeftBtnUp { private get; set; }

        public MouseButtonEventArgs MouseLeftBtnUp_Args { private get; set; }

        /// <summary>
        /// Camera == "Camera" is CameraAnchor
        /// Photo == "Photo" is PhotoAnchor
        /// </summary>
        public string CameraOrPhoto { private get; set; }

        string _languageStr = "zh_CN";
        public string LanguageStr
        {
            get { return _languageStr; }
            set { _languageStr = value; }
        }

        Route _route = new Route();
        /// <summary>
        /// 是否显示线路
        /// </summary>
        public Route Route { get { return _route; } }
        #endregion

        private MainWindowViewModel viewModel = null;
        public MyMapControl()
        {
            InitializeComponent();
            this.DataContext = viewModel = new MainWindowViewModel();
            viewModel.MyMapControl = this;
            GMapProvider.LanguageStr = LanguageStr;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            MainMap.Markers.Clear();
            MainMap.CacheLocation = Path.Combine(Environment.CurrentDirectory, "GMap.NET");

            // set cache mode only if no internet avaible
            if (!Stuff.PingNetwork("ditu.amap.com"))
            {
                MainMap.Manager.Mode = AccessMode.ServerAndCache;
                CodeStacksWindow.MessageBox.Invoke(true, false, -1, "没有可用的网络连接，将切换至缓存模式");
            }

            MainMap.Manager.Mode = AccessMode.ServerAndCache;
            MainMap.DragButton = MouseButton.Left;
            MainMap.MapProvider = GMapProviders.AMapHybridMap;
            MainMap.Zoom = 12;
            MainMap.ScaleMode = ScaleModes.Dynamic;
            try
            {
                if (Route.IsRoute)
                {
                    viewModel.Points = Points;
                    viewModel.Route = Route;
                    viewModel.RouteAsync();
                }
                else
                {
                    //"pack://application:,,,/Images/test1.png" resource path
                    //"pack://siteoforigin:,,,/Images/test1.png" site path
                    foreach (var point in Points)
                    {
                        MainMap.Position = point;
                        GMapMarker currentMarker = new GMapMarker(point);
                        GMapMarkerShape(currentMarker, point);
                        currentMarker.Offset = new System.Windows.Point(-15, -15);
                        currentMarker.ZIndex = int.MaxValue;
                        MainMap.Markers.Add(currentMarker);
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            #region InitialGeographic
            //MainWindowViewModel.SMainwindowViewModel.GeoData.Langitude = 116.337801218033;
            //MainWindowViewModel.SMainwindowViewModel.GeoData.Latitude = 39.9719321233495;
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

            MainMap.LayoutUpdated += MainMap_LayoutUpdated;
            MainWindowViewModel.SMainwindowViewModel.MyMapControl = this;
        }

        private void CameraAnchorShape_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            e = MouseLeftBtnUp_Args;
            MouseLeftBtnUp.Invoke(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMap_LayoutUpdated(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void ReSet()
        {
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


        public void GMapMarkerShape(GMapMarker currentMarker, PointLatLng point)
        {
            if (string.IsNullOrEmpty(point.AnchorType))
                currentMarker.Shape = null;
            else if ("Camera".Equals(point.AnchorType))
            {
                currentMarker.Shape =
                    new CameraAnchor(this, currentMarker, point.Photo, (GeoTitle)point.GeoTitle, "Xiaowen");
                currentMarker.Shape.MouseLeftButtonUp += CameraAnchorShape_MouseLeftButtonUp;
            }
            else if ("Photo".Equals(point.AnchorType))
                currentMarker.Shape =
                    new PhotoAnchor(this, currentMarker, point.Photo, (GeoTitle)point.GeoTitle, "Xiaowen");
            else if ("Red".Equals(point.AnchorType))
                currentMarker.Shape = new MyMarkerRedAnchor(this, currentMarker, (GeoTitle)point.GeoTitle, "Xiaowen");
        }
    }
}
