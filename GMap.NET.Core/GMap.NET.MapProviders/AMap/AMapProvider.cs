using GMap.NET.MapProviders;
using GMap.NET.Projections;
using System;

namespace GMap.NET.GMap.NET.MapProviders.AMap
{
    public class AMapProviderBase : GMapProvider
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
