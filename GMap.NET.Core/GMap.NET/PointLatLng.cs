﻿
namespace GMap.NET
{
    using System;
    using System.Globalization;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// the point of coordinates
    /// </summary>
    [Serializable]
    public struct PointLatLng
    {
        public static readonly PointLatLng Empty = new PointLatLng();
        private double lat;
        private double lng;
        private byte[] photoBuffer;
        private object geoTitle;
        private string anchorType;
        private string guid;

        bool NotEmpty;

        public PointLatLng(double lat, double lng)
        {
            this.lat = lat;
            this.lng = lng;
            this.photoBuffer = null;
            this.geoTitle = null;
            this.anchorType = null;
            this.guid = null;
            NotEmpty = true;
        }

        public PointLatLng(double lat, double lng, string cameraOrPhoto, byte[] photo, object geoTitle, params string[] guid)
        {
            this.lat = lat;
            this.lng = lng;
            this.photoBuffer = photo;
            this.geoTitle = geoTitle;
            this.anchorType = cameraOrPhoto;
            if (guid != null && guid.Length > 0)
                this.guid = guid[0];
            else
                this.guid = string.Empty;

            NotEmpty = true;
        }

        /// <summary>
        /// returns true if coordinates wasn't assigned
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return !NotEmpty;
            }
        }

        public double Lat
        {
            get
            {
                return this.lat;
            }
            set
            {
                this.lat = value;
                NotEmpty = true;
            }
        }

        public double Lng
        {
            get
            {
                return this.lng;
            }
            set
            {
                this.lng = value;
                NotEmpty = true;
            }
        }

        public byte[] PhotoBuffer
        {
            get { return this.photoBuffer; }
            set
            {
                this.photoBuffer = value;
                NotEmpty = true;
            }
        }

        public object GeoTitle
        {
            get { return this.geoTitle; }
            set
            {
                this.geoTitle = value;
                NotEmpty = true;
            }
        }

        public string AnchorType
        {
            get { return this.anchorType; }
            set
            {
                this.anchorType = value;
                NotEmpty = true;
            }
        }

        public string Guid
        {
            get { return this.guid; }
            set
            {
                this.guid = value;
                NotEmpty = true;
            }
        }

        public static PointLatLng operator +(PointLatLng pt, SizeLatLng sz)
        {
            return Add(pt, sz);
        }

        public static PointLatLng operator -(PointLatLng pt, SizeLatLng sz)
        {
            return Subtract(pt, sz);
        }

        public static bool operator ==(PointLatLng left, PointLatLng right)
        {
            return ((left.Lng == right.Lng) && (left.Lat == right.Lat));
        }

        public static bool operator !=(PointLatLng left, PointLatLng right)
        {
            return !(left == right);
        }

        public static PointLatLng Add(PointLatLng pt, SizeLatLng sz)
        {
            return new PointLatLng(pt.Lat - sz.HeightLat, pt.Lng + sz.WidthLng);
        }

        public static PointLatLng Subtract(PointLatLng pt, SizeLatLng sz)
        {
            return new PointLatLng(pt.Lat + sz.HeightLat, pt.Lng - sz.WidthLng);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PointLatLng))
            {
                return false;
            }
            PointLatLng tf = (PointLatLng)obj;
            return (((tf.Lng == this.Lng) && (tf.Lat == this.Lat)) && tf.GetType().Equals(base.GetType()));
        }

        public void Offset(PointLatLng pos)
        {
            this.Offset(pos.Lat, pos.Lng);
        }

        public void Offset(double lat, double lng)
        {
            this.Lng += lng;
            this.Lat -= lat;
        }

        public override int GetHashCode()
        {
            return (this.Lng.GetHashCode() ^ this.Lat.GetHashCode());
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{{Lat={0}, Lng={1}}}", this.Lat, this.Lng);
        }
    }
}