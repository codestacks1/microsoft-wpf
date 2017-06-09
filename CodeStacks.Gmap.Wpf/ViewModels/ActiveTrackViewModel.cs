using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using xiaowen.codestacks.data;
using xiaowen.codestacks.gmap.demo.Models;
using xiaowen.codestacks.wpf.MyMarker;

namespace xiaowen.codestacks.wpf.ViewModels
{
    public partial class MainWindowViewModel : BindableBase
    {
        PointLatLng start;//起点
        PointLatLng end;//终点
        private void AddMarkerCommandFunc(object obj)
        {
            start = new PointLatLng(36.7564903295052, 119.20166015625);
            end = new PointLatLng(34.6332079113796, 114.873046875);

            RoutingProvider rp = MyMapControl.MainMap.MapProvider as RoutingProvider;
            if (rp == null)
            {
                rp = GMapProviders.BingHybridMap; // use OpenStreetMap if provider does not implement routing
            }

            MapRoute route = rp.GetRoute(start, end, false, false, (int)MyMapControl.MainMap.Zoom);
            if (route != null)
            {
                GMapMarker m1 = new GMapMarker(start);
                m1.Shape = new MyMarkerRouteAnchor(MyMapControl, m1, "Start: " + route.Name);

                GMapMarker m2 = new GMapMarker(end);
                m2.Shape = new MyMarkerRouteAnchor(MyMapControl, m2, "End: " + start.ToString());

                GMapRoute mRoute = new GMapRoute(route.Points);
                {
                    mRoute.ZIndex = -1;
                }

                MyMapControl.MainMap.Markers.Add(m1);
                MyMapControl.MainMap.Markers.Add(m2);
                MyMapControl.MainMap.Markers.Add(mRoute);


                MyMapControl.MainMap.ZoomAndCenterMarkers(null);
            }
        }

        private void ActiveTrackCommandFunc(object obj)
        {
            for (int i = 0; i < 10; i++)
            {
                Points.Add(new GMap.NET.PointLatLng(39.2719321233495 + i, 116.337801218033 + i, "Photo", CodeStacksDataHandler.ImageData.ConvertToImageSourceDelegate1("pack://application:,,,/Images/test1.png"), new GeoTitle() { Content1 = "content1", Content1Visible = Visibility.Visible }));
            }
            ActiveTrack(null);

        }

        async void ActiveTrack(object stateInfo)
        {
            PointLatLng _start = Points[0];//起点
            GMapMarker m1 = new GMapMarker(_start);
            m1.Shape = new MyMarkerRouteAnchor(MyMapControl, m1, "Start: ");
            MyMapControl.MainMap.Markers.Add(m1);
            MyMapControl.MainMap.ZoomAndCenterMarkers(null);

            for (int i = 1; i < Points.Count; i++)
            {
                _start = Points[i - 1];
                await this.DelayTime(_start, Points[i]);
            }
        }

        async Task DelayTime(PointLatLng _start, PointLatLng _end)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));

            RoutingProvider rp = MyMapControl.MainMap.MapProvider as RoutingProvider;
            if (rp == null)
            {
                rp = GMapProviders.AMapHybridMap; // use OpenStreetMap if provider does not implement routing
            }

            MapRoute route = rp.GetRoute(_start, _end, false, false, (int)MyMapControl.MainMap.Zoom);
            if (route != null)
            {
                GMapMarker m2 = new GMapMarker(_end);
                m2.Shape = new MyMarkerRouteAnchor(MyMapControl, m2, "坐标: " + _end.ToString());

                GMapRoute mRoute = new GMapRoute(route.Points);
                {
                    mRoute.ZIndex = -1;
                }

                MyMapControl.MainMap.Markers.Add(m2);
                MyMapControl.MainMap.Markers.Add(mRoute);

                MyMapControl.MainMap.Position = _end;
                MyMapControl.MainMap.ZoomAndCenterMarkers(null);
            }
        }

    }
}
