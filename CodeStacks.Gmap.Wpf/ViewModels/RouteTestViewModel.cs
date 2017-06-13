using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using Prism.Mvvm;
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
            end = new PointLatLng(35.6332079113796, 116.873046875);

            RoutingProvider rp = MyMapControl.MainMap.MapProvider as RoutingProvider;
            if (rp == null)
            {
                rp = GMapProviders.AMapHybridMap; // use OpenStreetMap if provider does not implement routing
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
    }
}
