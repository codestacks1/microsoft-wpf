using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Xiaowen.CodeStacks.Data;
using Xiaowen.CodeStacks.Data.Models.GMap;
using Xiaowen.CodeStacks.Wpf.Gmap.MyMarker;
using Xiaowen.CodeStacks.Wpf.Gmap.Views;
using Xiaowen.CodeStacks.Wpf.Utilities;

namespace Xiaowen.CodeStacks.Wpf.Gmap.Source
{
    public class CodeStacksGMapRoute
    {
        #region -- Offline --

        /// <summary>
        /// Stop Current Thread
        /// </summary>
        public static void StopRouteTask()
        {
            try
            {
                tokenSource.Cancel();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="map"></param>
        /// <param name="delay"></param>
        public static async void SetRouteOffline(ObservableCollection<PointLatLng> points, MyMapControl map, Route route, Visibility isPlayVisibility, Visibility isStopVisibility)
        {
            if (points.Count == 0)
            {
                map.viewModel.IsPlayVisibility = Visibility.Visible;
                map.viewModel.IsStopVisibility = Visibility.Collapsed;
                map.viewModel.RefreshPlayBtn();
                return;
            }
            else if (points.Count == 1)
            {
                PointLatLng start = points[0];//起点
                BitmapImage photo = CodeStacksImage.ZipImage(start.PhotoBuffer, 10);
                GMapMarker m1 = new GMapMarker(start);
                PhotoAnchor pa = new PhotoAnchor(map, m1, photo, (GeoTitle)start.GeoTitle, "Xiaowen");
                //pa.Margin = new Thickness(-30, -30, 0, -30);
                m1.Shape = pa;

                map.MainMap.Markers.Add(m1);
                map.MainMap.ZoomAndCenterMarkers(null);

                map.viewModel.IsPlayVisibility = Visibility.Visible;
                map.viewModel.IsStopVisibility = Visibility.Collapsed;
                map.viewModel.RefreshPlayBtn();

                return;
            };

            //CodeStacksDataHandler.InitUIThread();
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;

            try
            {
                PointLatLng start = points[0];//起点
                GMapMarker m1 = new GMapMarker(start);
                BitmapImage photo = CodeStacksImage.ZipImage(start.PhotoBuffer, 10);
                PhotoAnchor pa = new PhotoAnchor(map, m1, photo, (GeoTitle)start.GeoTitle, "Xiaowen");
                //pa.Margin = new Thickness(-30, -30, 0, -30);
                m1.Shape = pa;

                map.MainMap.Markers.Add(m1);
                map.MainMap.ZoomAndCenterMarkers(null);

                await AsyncSetSpeedUpNew(points, photo, route.Delay, map, token);
                map.viewModel.IsPlayVisibility = Visibility.Visible;
                map.viewModel.IsStopVisibility = Visibility.Collapsed;
                map.viewModel.RefreshPlayBtn();
            }
            catch (Exception)
            {
            }
            finally
            {
                tokenSource.Dispose();
            }

            //PointLatLng _start = points[0];
            //TaskFactory facotry = new TaskFactory(token);
            //AsyncSetSpeedUp(points, _start, route.Delay, map, token);
        }


        #endregion

        #region -- Online --

        public static void SetRouteOnline(ObservableCollection<PointLatLng> points, MyMapControl map, int delay)
        {
            if (points.Count == 0) return;
            PointLatLng _start = points[0];//起点
            BitmapImage photo = CodeStacksImage.ZipImage(_start.PhotoBuffer, 10);
            GMapMarker m1 = new GMapMarker(_start);
            PhotoAnchor pa = new PhotoAnchor(map, m1, photo, (GeoTitle)_start.GeoTitle, "Xiaowen");
            pa.Margin = new Thickness(-30, -30, 0, -30);
            m1.Shape = pa;

            map.MainMap.Markers.Add(m1);
            map.MainMap.ZoomAndCenterMarkers(null);

            //   for (int i = 1; i < points.Count; i++)
            //{
            //    _start = points[i - 1];
            //   SpeedUpRouteAsync(_start, points[i], delay, map, points);
            // }
            SpeedUpRouteAsyncNew(delay, map, points, photo);
        }

        private async static void SpeedUpRouteAsync(PointLatLng _start, PointLatLng _end, int delay, MyMapControl map, ObservableCollection<PointLatLng> points, BitmapImage photo)
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
                m2.Shape = new PhotoAnchor(map, m2, photo, (GeoTitle)_end.GeoTitle, "Xiaowen");

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
        private async static void SpeedUpRouteAsyncNew(int delay, MyMapControl map, ObservableCollection<PointLatLng> points, BitmapImage photo)
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
                    m2.Shape = new PhotoAnchor(map, m2, photo, (GeoTitle)_end.GeoTitle, "Xiaowen");

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

        #endregion

        #region Set Offline Map

        static CancellationTokenSource tokenSource;
        static CancellationToken token;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="delay"></param>
        /// <param name="map"></param>
        /// <param name="Token"></param>
        /// <returns></returns>
        private static async Task AsyncSetSpeedUpNew(ObservableCollection<PointLatLng> points, BitmapImage photo, int delay, MyMapControl map, CancellationToken Token)
        {
            PointLatLng _start = points[0];
            PointLatLng _end = points[0];

            for (int i = 1; i < points.Count; i++)
            {
                await Task.Delay(TimeSpan.FromSeconds(delay), token);

                token.ThrowIfCancellationRequested();

                _start = points[i - 1];
                _end = points[i];
                ObservableCollection<PointLatLng> doublePoint = new ObservableCollection<PointLatLng>();
                doublePoint.Add(_start);
                doublePoint.Add(_end);

                GMapMarker m2 = new GMapMarker(_end);
                m2.Shape = new PhotoAnchor(map, m2, photo, (GeoTitle)_end.GeoTitle, "Xiaowen");

                GMapRoute mRoute = new GMapRoute(doublePoint, map.MainMap);
                {
                    mRoute.ZIndex = -1;
                }

                map.MainMap.Markers.Add(m2);
                map.MainMap.Markers.Add(mRoute);
                map.MainMap.ZoomAndCenterMarkers(null);
                map.MainMap.Position = _end;

                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_start"></param>
        /// <param name="_end"></param>
        /// <param name="delay"></param>
        /// <param name="map"></param>
        /// <param name="points"></param>
        private static async Task AsyncSetSpeedUp(ObservableCollection<PointLatLng> points, PointLatLng _start, int delay, MyMapControl map, CancellationToken token, BitmapImage photo)
        {
            TaskFactory facotry = new TaskFactory(token);

            await facotry.StartNew(() =>
            {
                for (int i = 1; i < points.Count; i++)
                {
                    _start = points[i - 1];
                    PointLatLng _end = points[i];
                    ObservableCollection<PointLatLng> doublePoint = new ObservableCollection<PointLatLng>();
                    doublePoint.Add(_start);
                    doublePoint.Add(_end);

                    SetAsyncSetSpeedUp(map, doublePoint, _start, _end, delay, photo);
                }
            }, token).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="map"></param>
        /// <param name="doublePoint"></param>
        /// <param name="_start"></param>
        /// <param name="_end"></param>
        /// <param name="delay"></param>
        private static async void SetAsyncSetSpeedUp(MyMapControl map, ObservableCollection<PointLatLng> doublePoint, PointLatLng _start, PointLatLng _end, int delay, BitmapImage photo)
        {
            await Task.Delay(TimeSpan.FromSeconds(delay));

            CodeStacksDataHandler.UIThread.Invoke(() =>
            {
                GMapMarker m2 = new GMapMarker(_end);
                m2.Shape = new PhotoAnchor(map, null, photo, (GeoTitle)_end.GeoTitle, "Xiaowen");

                GMapRoute mRoute = new GMapRoute(doublePoint, map.MainMap);
                mRoute.ZIndex = -1;

                map.MainMap.Markers.Add(m2);
                map.MainMap.Markers.Add(mRoute);
                map.MainMap.ZoomAndCenterMarkers(null);
                map.MainMap.Position = _end;
            });
        }

        #endregion
    }
}
