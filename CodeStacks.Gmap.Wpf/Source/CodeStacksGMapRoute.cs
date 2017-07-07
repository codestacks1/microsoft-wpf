using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using Xiaowen.CodeStacks.Data.Models.GMap;
using Xiaowen.CodeStacks.Wpf.Gmap.MyMarker;
using Xiaowen.CodeStacks.Wpf.Gmap.Views;

namespace Xiaowen.CodeStacks.Wpf.Gmap.Source
{
    public class CodeStacksGMapRoute : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="map"></param>
        private static void Get(ObservableCollection<PointLatLng> points, GMapControl map)
        {
            GMapRoute mRoute = new GMapRoute(points, map);
            {
                mRoute.ZIndex = -1;
            }
        }


        #region -- Offline --


        public static Task RouteTask { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static void StopRouteTask(MyMapControl map)
        {
            TaskStatus tStatus = RouteTask.Status;
            tStatus = TaskStatus.RanToCompletion;

            GC.SuppressFinalize(RouteTask);
            //RouteTask.Dispose();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="map"></param>
        /// <param name="delay"></param>
        public static async void SetRouteOffline(ObservableCollection<PointLatLng> points, MyMapControl map, int delay)
        {
            if (points.Count == 0) return;
            else if (points.Count == 1)
            {
                PointLatLng _start = points[0];//起点
                GMapMarker m1 = new GMapMarker(_start);
                PhotoAnchor pa = new PhotoAnchor(map, m1, _start.Photo, (GeoTitle)_start.GeoTitle, "Xiaowen");
                pa.Margin = new Thickness(-30, -30, 0, -30);
                m1.Shape = pa;

                map.MainMap.Markers.Add(m1);
                map.MainMap.ZoomAndCenterMarkers(null);
                return;
            };
            RouteTask = AsyncSetSpeedUpNew(points, delay, map);
            await RouteTask;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_start"></param>
        /// <param name="_end"></param>
        /// <param name="delay"></param>
        /// <param name="map"></param>
        /// <param name="points"></param>
        private static async Task AsyncSetSpeedUp(ObservableCollection<PointLatLng> points, PointLatLng _start, PointLatLng _end, int delay, MyMapControl map)
        {
            if (delay != 0)
                await Task.Delay(TimeSpan.FromSeconds(delay));

            ObservableCollection<PointLatLng> doublePoint = new ObservableCollection<PointLatLng>();
            doublePoint.Add(_start);
            doublePoint.Add(_end);

            GMapMarker m2 = new GMapMarker(_end);
            m2.Shape = new PhotoAnchor(map, m2, _end.Photo, (GeoTitle)_end.GeoTitle, "Xiaowen");

            GMapRoute mRoute = new GMapRoute(doublePoint, map.MainMap);
            {
                mRoute.ZIndex = -1;
            }

            map.MainMap.Markers.Add(m2);
            map.MainMap.Markers.Add(mRoute);
            map.MainMap.ZoomAndCenterMarkers(null);
            map.MainMap.Position = _end;
        }


        private static async Task AsyncSetSpeedUpNew(ObservableCollection<PointLatLng> points, int delay, MyMapControl map)
        {
            PointLatLng _start = points[0];
            PointLatLng _end = points[0];

            for (int i = 1; i < points.Count; i++)
            {
                await Task.Delay(TimeSpan.FromSeconds(delay));
                _start = points[i - 1];
                _end = points[i];
                ObservableCollection<PointLatLng> doublePoint = new ObservableCollection<PointLatLng>();
                doublePoint.Add(_start);
                doublePoint.Add(_end);

                GMapMarker m2 = new GMapMarker(_end);
                m2.Shape = new PhotoAnchor(map, m2, _end.Photo, (GeoTitle)_end.GeoTitle, "Xiaowen");

                GMapRoute mRoute = new GMapRoute(doublePoint, map.MainMap);
                {
                    mRoute.ZIndex = -1;
                }

                map.MainMap.Markers.Add(m2);
                map.MainMap.Markers.Add(mRoute);
                map.MainMap.ZoomAndCenterMarkers(null);
                map.MainMap.Position = _end;
            }

        }

        #endregion

        #region -- Online --

        public static void SetRouteOnline(ObservableCollection<PointLatLng> points, MyMapControl map, int delay)
        {
            if (points.Count == 0) return;
            PointLatLng _start = points[0];//起点
            GMapMarker m1 = new GMapMarker(_start);
            PhotoAnchor pa = new PhotoAnchor(map, m1, _start.Photo, (GeoTitle)_start.GeoTitle, "Xiaowen");
            pa.Margin = new Thickness(-30, -30, 0, -30);
            m1.Shape = pa;

            map.MainMap.Markers.Add(m1);
            map.MainMap.ZoomAndCenterMarkers(null);

            //   for (int i = 1; i < points.Count; i++)
            //{
            //    _start = points[i - 1];
            //   SpeedUpRouteAsync(_start, points[i], delay, map, points);
            // }
            SpeedUpRouteAsyncNew(delay, map, points);
        }

        private async static void SpeedUpRouteAsync(PointLatLng _start, PointLatLng _end, int delay, MyMapControl map, ObservableCollection<PointLatLng> points)
        {
            await Task.Delay(TimeSpan.FromSeconds(delay));

            RoutingProvider rp = map.MainMap.MapProvider as RoutingProvider;
            if (rp == null)
            {
                rp = GMapProviders.AMapHybridMap;// use OpenStreetMap if provider does not implement routing
            }

            MapRoute route = rp.GetRoute(_start, _end, false, false, (int)map.MainMap.Zoom);
            if (route != null)
            {
                GMapMarker m2 = new GMapMarker(_end);
                m2.Shape = new PhotoAnchor(map, m2, _end.Photo, (GeoTitle)_end.GeoTitle, "Xiaowen");

                GMapRoute mRoute = new GMapRoute(route.Points);
                {
                    mRoute.ZIndex = -1;
                }

                map.MainMap.Markers.Add(m2);
                map.MainMap.Markers.Add(mRoute);

                map.MainMap.ZoomAndCenterMarkers(null);
                map.MainMap.Position = _end;
            }
        }
        private async static void SpeedUpRouteAsyncNew(int delay, MyMapControl map, ObservableCollection<PointLatLng> points)
        {
            PointLatLng _start = points[0];//起点
            PointLatLng _end = points[0];//起点
            for (int i = 1; i < points.Count; i++)
            {
                _start = points[i - 1];
                _end = points[i];
                await Task.Delay(TimeSpan.FromSeconds(delay));
                RoutingProvider rp = map.MainMap.MapProvider as RoutingProvider;
                if (rp == null)
                {
                    rp = GMapProviders.AMapHybridMap;// use OpenStreetMap if provider does not implement routing
                }

                MapRoute route = rp.GetRoute(_start, _end, false, false, (int)map.MainMap.Zoom);
                if (route != null)
                {
                    GMapMarker m2 = new GMapMarker(_end);
                    m2.Shape = new PhotoAnchor(map, m2, _end.Photo, (GeoTitle)_end.GeoTitle, "Xiaowen");

                    GMapRoute mRoute = new GMapRoute(route.Points);
                    {
                        mRoute.ZIndex = -1;
                    }

                    map.MainMap.Markers.Add(m2);
                    map.MainMap.Markers.Add(mRoute);

                    map.MainMap.ZoomAndCenterMarkers(null);
                    map.MainMap.Position = _end;
                }
            }
        }

        public void Dispose()
        {

        }
        #endregion
    }
}
