using GMap.NET.Internals;
using GMap.NET.MapProviders;
using GMap.NET.Projections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace GMap.NET.GMap.NET.MapProviders.AMap
{
    /// <summary>
    /// author:zhangxiaowen
    /// date: 20170605
    /// </summary>
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

        //static readonly string RouteUrlFormatPointLatLng1 = "http://ditu.amap.com/service/autoNavigat?usepoiquery=true&coor_need=true&rendertemplate=1&invoker=plan&engine_version=3&start_types=1&end_types=1&viapoint_types=1&policy2=1&fromX=116.33757&fromY=39.97177&start_poiid=dirmyloc&toX=118.797085&toY=31.970677&end_poiid=B00190YPLY&end_poitype=150200&key=bfe31f4e0fb231d29e1d3ce951e2c780&callback=jsonp_323619_&csid=4D99EB70-B119-486C-89CC-33816C58EB22";

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

                    try
                    {
                        points = new List<PointLatLng>();
                        IEnumerable root = JsonConvert.DeserializeObject(route.Replace("/**/ typeof jsonp_323619_ === 'function' && jsonp_323619_(", "").Replace(");", "")) as IEnumerable;
                        foreach (JProperty item in root)
                        {
                            if (item.Name.Equals("data"))
                            {
                                var paths = item.Value["path_list"];
                                JToken path = paths.Value<JToken>()[0];
                                foreach (JProperty _path in path)
                                {
                                    if (_path.Name.Equals("path"))
                                    {
                                        IEnumerable<JToken> path1 = _path.Value<JToken>().Children<JToken>();
                                        foreach (var _path1 in path1)
                                        {
                                            foreach (JToken segment in _path1)
                                            {
                                                JToken segments = segment["segments"];
                                                foreach (JToken _segment in segments)
                                                {
                                                    JToken coors = _segment["coor"];
                                                    string[] coorStr = coors.Value<string>().Replace("[", "").Replace("]", "").Split(',');

                                                    for (int i = 0; i < coorStr.Length; i += 2)
                                                    {
                                                        points.Add(new PointLatLng(lng: Convert.ToDouble(coorStr[i]), lat: Convert.ToDouble(coorStr[i + 1])));

                                                    }

                                                }

                                                //points.Add(new PointLatLng);
                                            }
                                            break;
                                        }

                                        break;//found segements
                                    }
                                }

                                break;//found data
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message, ex);
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
