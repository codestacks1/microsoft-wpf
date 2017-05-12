using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        List<PointLatLng> PointCollection;
        private void ActiveTrackCommandFunc(object obj)
        {
            PointCollection = new List<PointLatLng>();
            PointCollection.Add(new PointLatLng(36.7564903295052, 119.20166015625));
            PointCollection.Add(new PointLatLng(36.6155276313492, 118.41064453125));
            PointCollection.Add(new PointLatLng(35.9335406424931, 117.608642578125));
            PointCollection.Add(new PointLatLng(35.5411662799981, 116.56494140625));
            PointCollection.Add(new PointLatLng(35.1109218097047, 115.77392578125));
            PointCollection.Add(new PointLatLng(34.6332079113796, 114.873046875));
            //Timer timer = new Timer(ActiveTrack, null, 1000, 250);
            ActiveTrack(null);

        }

        async void ActiveTrack(object stateInfo)
        {
            PointLatLng _start = PointCollection[0];//起点
            GMapMarker m1 = new GMapMarker(_start);
            m1.Shape = new MyMarkerRouteAnchor(MyMapControl, m1, "Start: ");
            MyMapControl.MainMap.Markers.Add(m1);
            MyMapControl.MainMap.ZoomAndCenterMarkers(null);

            for (int i = 1; i < PointCollection.Count; i++)
            {
                _start = PointCollection[i - 1];
                await this.DelayTime(_start, PointCollection[i]);
            }
        }
        
        async Task DelayTime(PointLatLng _start, PointLatLng _end)
        {
            await Task.Delay(TimeSpan.FromSeconds(5));

            RoutingProvider rp = MyMapControl.MainMap.MapProvider as RoutingProvider;
            if (rp == null)
            {
                rp = GMapProviders.BingHybridMap; // use OpenStreetMap if provider does not implement routing
            }

            MapRoute route = rp.GetRoute(_start, _end, false, false, (int)MyMapControl.MainMap.Zoom);
            if (route != null)
            {
                GMapMarker m2 = new GMapMarker(_end);
                m2.Shape = new MyMarkerRouteAnchor(MyMapControl, m2, "End: " + start.ToString());

                GMapRoute mRoute = new GMapRoute(route.Points);
                {
                    mRoute.ZIndex = -1;
                }

                MyMapControl.MainMap.Markers.Add(m2);
                MyMapControl.MainMap.Markers.Add(mRoute);

                MyMapControl.MainMap.ZoomAndCenterMarkers(null);
            }
        }
        
    }
}
