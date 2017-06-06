using GMap.NET.Internals;
using GMap.NET.MapProviders;
using GMap.NET.Projections;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Xml;

namespace GMap.NET.GMap.NET.MapProviders.AMap
{
    public class AMapProviderBase : GMapProvider, RoutingProvider
    {
        public string Version = "170605";
        public AMapProviderBase()
        {
            MaxZoom = null;
            RefererUrl = "http://ditu.amap.com/";
            Copyright = string.Format("xiaowen.codestacks.wpf.amap @{0}", DateTime.Today.Year);
        }

        public string ClientKey = string.Empty;
        internal string SessionId = string.Empty;


        #region GMapProvider Members
        public override Guid Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        GMapProvider[] overlays;
        public override GMapProvider[] Overlays
        {
            get
            {
                if (overlays == null)
                {
                    overlays = new GMapProvider[] { this };
                }
                return overlays;
            }
        }

        public override PureProjection Projection
        {
            get
            {
                return MercatorProjection.Instance;
            }
        }

        public override PureImage GetTileImage(GPoint pos, int zoom)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region RouterProvider

        public MapRoute GetRoute(PointLatLng start, PointLatLng end, bool avoidHighways, bool walkingMode, int Zoom)
        {
            string tooltip;
            int numLevels;
            int zoomFactor;
            MapRoute ret = null;
            List<PointLatLng> points = GetRoutePoints(MakeRouteUrl(start, end, LanguageStr), Zoom, out tooltip, out numLevels, out zoomFactor);
            if (points != null)
            {
                ret = new MapRoute(points, tooltip);
            }
            return ret;
        }

        public MapRoute GetRoute(string start, string end, bool avoidHighways, bool walkingMode, int Zoom)
        {
            string tooltip;
            int numLevels;
            int zoomFactor;
            MapRoute ret = null;
            List<PointLatLng> points = GetRoutePoints(MakeRouteUrl(start, end, LanguageStr, avoidHighways, walkingMode), Zoom, out tooltip, out numLevels, out zoomFactor);
            if (points != null)
            {
                ret = new MapRoute(points, tooltip);
            }
            return ret;
        }

        static readonly string RouteUrlFormatPointLatLng1 = "http://ditu.amap.com/service/autoNavigat?usepoiquery=true&coor_need=true&rendertemplate=1&invoker=plan&engine_version=3&start_types=1&end_types=1&viapoint_types=1&policy2=1&fromX=116.33757&fromY=39.97177&start_poiid=dirmyloc&toX=118.797085&toY=31.970677&end_poiid=B00190YPLY&end_poitype=150200&key=bfe31f4e0fb231d29e1d3ce951e2c780&callback=jsonp_323619_&csid=4D99EB70-B119-486C-89CC-33816C58EB22";

        static readonly string RouteUrlFormatPointLatLng = "http://ditu.amap.com/service/autoNavigat?usepoiquery=true&coor_need=true&rendertemplate=1&invoker=plan&engine_version=3&start_types=1&end_types=1&viapoint_types=1&policy2=1&fromX={0}&fromY={1}&start_poiid=dirmyloc&toX={2}&toY={3}&end_poiid=B00190YPLY&end_poitype=150200&key=bfe31f4e0fb231d29e1d3ce951e2c780&callback=jsonp_323619_&csid=4D99EB70-B119-486C-89CC-33816C58EB22";

        static readonly string RouteUrlFormatPointQueries = string.Empty;

        string MakeRouteUrl(string start, string end, string language, bool avoidHighways, bool walkingMode)
        {
            string addition = avoidHighways ? "&avoid=highways" : string.Empty;
            string mode = walkingMode ? "Walking" : "Driving";

            return string.Format(CultureInfo.InvariantCulture, RouteUrlFormatPointQueries, mode, start, end, addition, SessionId);
        }

        string MakeRouteUrl(PointLatLng start, PointLatLng end, string language)
        {
            return string.Format(CultureInfo.InvariantCulture, RouteUrlFormatPointLatLng, start.Lng, start.Lat, end.Lng, end.Lat);
        }

        List<PointLatLng> GetRoutePoints(string url, int zoom, out string tooltipHtml, out int numLevel, out int zoomFactor)
        {
            List<PointLatLng> points = null;
            tooltipHtml = string.Empty;
            numLevel = -1;
            zoomFactor = -1;
            try
            {
                string route = GMaps.Instance.UseRouteCache ? Cache.Instance.GetContent(url, CacheType.RouteCache) : string.Empty;

                if (string.IsNullOrEmpty(route))
                {
                    route = GetContentUsingHttp(url);

                    if (!string.IsNullOrEmpty(route))
                    {
                        if (GMaps.Instance.UseRouteCache)
                        {
                            Cache.Instance.SaveContent(url, CacheType.RouteCache, route);
                        }
                    }
                }

                // parse values
                if (!string.IsNullOrEmpty(route))
                {
                    #region -- title --

                    #endregion

                    #region -- points --

                    object routeJson = JsonConvert.DeserializeObject(route.Replace("/**/ typeof jsonp_323619_ === 'function' && jsonp_323619_(", "").Replace(");", ""));
                    IEnumerator<object> s = routeJson as IEnumerator<object>;
                    var data = s;

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(route);
                    XmlNode xn = doc["Response"];
                    string statuscode = xn["StatusCode"].InnerText;
                    switch (statuscode)
                    {
                        case "200":
                            {
                                xn = xn["ResourceSets"]["ResourceSet"]["Resources"]["Route"]["RoutePath"]["Line"];
                                XmlNodeList xnl = xn.ChildNodes;
                                if (xnl.Count > 0)
                                {
                                    points = new List<PointLatLng>();
                                    foreach (XmlNode xno in xnl)
                                    {
                                        XmlNode latitude = xno["Latitude"];
                                        XmlNode longitude = xno["Longitude"];
                                        points.Add(new PointLatLng(double.Parse(latitude.InnerText, CultureInfo.InvariantCulture),
                                                                   double.Parse(longitude.InnerText, CultureInfo.InvariantCulture)));
                                    }
                                }
                                break;
                            }
                        // no status implementation on routes yet although when introduced these are the codes. Exception will be catched.
                        case "400":
                            throw new Exception("Bad Request, The request contained an error.");
                        case "401":
                            throw new Exception("Unauthorized, Access was denied. You may have entered your credentials incorrectly, or you might not have access to the requested resource or operation.");
                        case "403":
                            throw new Exception("Forbidden, The request is for something forbidden. Authorization will not help.");
                        case "404":
                            throw new Exception("Not Found, The requested resource was not found.");
                        case "500":
                            throw new Exception("Internal Server Error, Your request could not be completed because there was a problem with the service.");
                        case "501":
                            throw new Exception("Service Unavailable, There's a problem with the service right now. Please try again later.");
                        default:
                            points = null;
                            break; // unknown, for possible future error codes
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                points = null;
                Debug.WriteLine("GetRoutePoints: " + ex);
            }
            return points;
        }

        #endregion

    }

    public class AMapProvider : AMapProviderBase
    {
        public static readonly AMapProvider Instance;

        AMapProvider() { }
        static AMapProvider()
        {
            Instance = new AMapProvider();
        }

        #region GMapProvider Members

        readonly Guid id = new Guid("F7876202-FDD6-440B-9BEF-9B3FE0245838");
        public override Guid Id
        {
            get
            {
                return id;
            }
        }

        readonly string name = "AMap";
        public override string Name
        {
            get
            {
                return name;
            }
        }

        public string TileXYToQuadKey { get; private set; }

        public override PureImage GetTileImage(GPoint pos, int zoom)
        {

            string url = MakeTileImageUrl(pos, zoom, LanguageStr);
            return GetTileImageUsingHttp(url);
        }



        #endregion

        string UrlDynamicFormat = string.Empty;
        static readonly string UrlFormat = @"http://webrd01.is.autonavi.com/appmaptile?lang=zh_cn&size=1&scale=1&style=7&x={0}&y={1}&z={2}";
        string MakeTileImageUrl(GPoint pos, int zoom, string language)
        {
            return string.Format(UrlFormat, pos.X, pos.Y, zoom);
        }

    }
}
