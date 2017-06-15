using GMap.NET.WindowsPresentation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using xiaowen.codestacks.gmap.demo.Models;
using xiaowen.codestacks.wpf.MyMarker;
using xiaowen.codestacks.wpf.ViewModels;
using xiaowen.codestacks.wpf.Views;

namespace xiaowen.codestacks.gmap.wpf.MyMarker
{
    /// <summary>
    /// Interaction logic for CameraAnchor.xaml
    /// </summary>
    public partial class CameraAnchor : UserControl
    {
        public ImageSource Photo { get; set; }

        Popup Popup;
        GMapMarker Marker;
        MyMapControl MainWindow;
        public CameraAnchor()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public CameraAnchor(MyMapControl window, GMapMarker marker, ImageSource photo, GeoTitle geoTitle, string title, params object[] viewModels) : this()
        {
            this.Photo = photo;
            this.MainWindow = window;
            this.Marker = marker;
            Popup = new Popup();

            this.MouseLeftButtonUp += new MouseButtonEventHandler(CustomMarkerDemo_MouseLeftButtonUp);
            this.MouseLeave += new MouseEventHandler(MarkerControl_MouseLeave);
            this.MouseEnter += new MouseEventHandler(MarkerControl_MouseEnter);

            Popup.Placement = PlacementMode.Mouse;
            Popup.Child = new MyMarkerRedAnchorDepict(geoTitle);// Label;
        }

        private void MarkerControl_MouseEnter(object sender, MouseEventArgs e)
        {
            Marker.ZIndex += 10000;
            Popup.IsOpen = true;

            Point p = e.GetPosition(MainWindow.MainMap);
            var point = MainWindow.MainMap.FromLocalToLatLng((int)p.X, (int)p.Y);
            MainWindowViewModel.SMainwindowViewModel.GeoData.Latitude = point.Lat;
            MainWindowViewModel.SMainwindowViewModel.GeoData.Langitude = point.Lng;
            MainWindowViewModel.SMainwindowViewModel.RefreshGeoData();
        }

        private void MarkerControl_MouseLeave(object sender, MouseEventArgs e)
        {
            Marker.ZIndex -= 10000;
            Popup.IsOpen = false;
        }

        private void CustomMarkerDemo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
           
        }
    }
}
