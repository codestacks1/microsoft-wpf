using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using xiaowen.codestacks.gmap.demo.Models;
using xiaowen.codestacks.gmap.wpf.MyMarker;
using xiaowen.codestacks.popwindow;
using xiaowen.codestacks.wpf.MyMarker;
using xiaowen.codestacks.wpf.Views;

namespace xiaowen.codestacks.wpf.ViewModels
{
    public partial class MainWindowViewModel : BindableBase
    {
        Geo _geoData;
        public Geo GeoData
        {
            get { return _geoData; }
            set { SetProperty(ref _geoData, value); }
        }

        GeoTitle _geoTitle;
        public GeoTitle GeoTitle
        {
            get { return _geoTitle; }
            set { SetProperty(ref _geoTitle, value); }
        }

        #region Refres Properties
        public void RefreshGeoData()
        {
            RaisePropertyChanged("GeoData");
        }

        public void RefreshGeoTitle()
        {
            RaisePropertyChanged("GeoTitle");
        }

        public Route Route { private get; set; }

        public ObservableCollection<PointLatLng> Points { get; set; }

        #endregion

        #region Command

        void InitCommand<T>() where T : class, new()
        {
            T t = new T();
            Cmd = t as Cmd;

            Cmd.AddMarkerCommand = new DelegateCommand<object>(AddMarkerCommandFunc);
            Cmd.ClearAllCommand = new DelegateCommand<object>(ClearAllCommandFunc);
            Cmd.PlayActiveRouteCommand = new DelegateCommand<object>(PlayActiveRouteFunc);
            Cmd.SpeedUpCommand = new DelegateCommand<object>(SpeedUpCommandFunc);
            Cmd.CopyLngCmd = new DelegateCommand<object>(CopyLngCmdFunc);
            Cmd.CopyLatCmd = new DelegateCommand<object>(CopyLatCmdFunc);
            Cmd.TakeAnchorCommand = new DelegateCommand<object>(TakeAnchorCommandFunc);
        }

        private void TakeAnchorCommandFunc(object obj)
        {
            CodeStacksWindow.MessageBox(false, false, 1, "该版本暂不支持该功能");
        }

        private void CopyLatCmdFunc(object obj)
        {
            Clipboard.SetDataObject(obj);
        }

        private void CopyLngCmdFunc(object obj)
        {
            Clipboard.SetDataObject(obj);
        }

        private void AddMarkerCommandFunc(object obj)
        {
            PointLatLng start = new PointLatLng(36.7564903295052, 119.20166015625);
            PointLatLng start1 = new PointLatLng(36.6564903295052, 118.90166015625);
            PointLatLng end = new PointLatLng(35.6332079113796, 116.873046875);

            RoutingProvider rp = MyMapControl.MainMap.MapProvider as RoutingProvider;
            if (rp == null)
            {
                rp = GMapProviders.AMapHybridMap; // use OpenStreetMap if provider does not implement routing
            }

            MapRoute route = rp.GetRoute(start, start1, false, false, (int)MyMapControl.MainMap.Zoom);
            MapRoute route1 = rp.GetRoute(start1, end, false, false, (int)MyMapControl.MainMap.Zoom);
            if (route != null)
            {
                GMapMarker m1 = new GMapMarker(start);
                m1.Shape = new MyMarkerRouteAnchor(MyMapControl, m1, "起点: " + start.ToString());

                GMapMarker m11 = new GMapMarker(start1);
                m11.Shape = new MyMarkerRouteAnchor(MyMapControl, m11, "中心: " + start.ToString());

                GMapMarker m2 = new GMapMarker(end);
                m2.Shape = new MyMarkerRouteAnchor(MyMapControl, m2, "终点: " + end.ToString());

                GMapRoute mRoute = new GMapRoute(route.Points);
                {
                    mRoute.ZIndex = -1;
                }

                GMapRoute mRoute1 = new GMapRoute(route1.Points);
                {
                    mRoute.ZIndex = -1;
                }

                MyMapControl.MainMap.Markers.Add(m1);
                MyMapControl.MainMap.Markers.Add(m11);
                MyMapControl.MainMap.Markers.Add(m2);
                MyMapControl.MainMap.Markers.Add(mRoute);
                MyMapControl.MainMap.Markers.Add(mRoute1);

                MyMapControl.MainMap.Zoom = 8;
                MyMapControl.MainMap.ZoomAndCenterMarkers(null);

                MyMapControl.MainMap.Position = end;
            }
        }

        private void SpeedUpCommandFunc(object obj)
        {
            try
            {
                Route.Delay = Route.Delay == 0 ? 0 : Route.Delay - 1;
            }
            catch (Exception)
            {
            }

        }

        public async void RouteAsync()
        {
            if (Points.Count == 0) return;
            PointLatLng _start = Points[0];//起点
            GMapMarker m1 = new GMapMarker(_start);
            PhotoAnchor pa = new PhotoAnchor(MyMapControl, m1, _start.Photo, (GeoTitle)_start.GeoTitle, "Xiaowen");
            pa.Margin = new Thickness(-30, -30, 0, -30);
            m1.Shape = pa;
            MyMapControl.MainMap.Markers.Add(m1);
            MyMapControl.MainMap.ZoomAndCenterMarkers(null);

            for (int i = 1; i < Points.Count; i++)
            {
                _start = Points[i - 1];
                await this.SpeedUpRouteAsync(_start, Points[i], Route.Delay);
            }
        }

        private async Task SpeedUpRouteAsync(PointLatLng _start, PointLatLng _end, int delay)
        {
            await Task.Delay(TimeSpan.FromSeconds(delay));

            RoutingProvider rp = MyMapControl.MainMap.MapProvider as RoutingProvider;
            if (rp == null)
            {
                rp = GMapProviders.AMapHybridMap;// use OpenStreetMap if provider does not implement routing
            }

            MapRoute route = rp.GetRoute(_start, _end, false, false, (int)MyMapControl.MainMap.Zoom);
            if (route != null)
            {
                GMapMarker m2 = new GMapMarker(_end);
                m2.Shape = new PhotoAnchor(MyMapControl, m2, _end.Photo, (GeoTitle)_end.GeoTitle, "Xiaowen");

                GMapRoute mRoute = new GMapRoute(route.Points);
                {
                    mRoute.ZIndex = -1;
                }

                MyMapControl.MainMap.Markers.Add(m2);
                MyMapControl.MainMap.Markers.Add(mRoute);

                MyMapControl.MainMap.ZoomAndCenterMarkers(null);
                MyMapControl.MainMap.Position = _end;
            }
        }

        /// <summary>
        /// 播放活动线路
        /// </summary>
        /// <param name="obj"></param>
        private void PlayActiveRouteFunc(object obj)
        {
            if (Route != null)
            {
                MyMapControl.MainMap.Markers.Clear();
                Route.Delay = 2;
                RouteAsync();
            }
        }

        private void ClearAllCommandFunc(object obj)
        {
            if (CodeStacksWindow.MessageBox.Invoke(true, false, -1, "您确定要清理地图图层？"))
            {
                MyMapControl.MainMap.Markers.Clear();
                MyMapControl.MainMap.Manager.PrimaryCache.DeleteOlderThan(DateTime.Now, null);
            }
        }

        #endregion

    }
}
