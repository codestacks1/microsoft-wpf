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
    /// Interaction logic for PhotoAnchor.xaml
    /// </summary>
    public partial class PhotoAnchor : UserControl
    {
        public ImageSource Photo { get; set; }

        Popup Popup;
        //Label Label;
        GMapMarker Marker;
        MyMapControl MainWindow;
        public PhotoAnchor()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public PhotoAnchor(MyMapControl window, GMapMarker marker, ImageSource photo, GeoTitle geoTitle, string title, params object[] viewModels) : this()
        {
            Photo = photo;

            this.MainWindow = window;
            this.Marker = marker;
            this.Marker.ZIndex = 11000;

            Popup = new Popup();
            //Label = new Label();

            this.MouseLeftButtonUp += new MouseButtonEventHandler(CustomMarkerDemo_MouseLeftButtonUp);
            this.MouseLeftButtonDown += new MouseButtonEventHandler(CustomMarkerDemo_MouseLeftButtonDown);
            this.MouseLeave += new MouseEventHandler(MarkerControl_MouseLeave);
            this.MouseEnter += new MouseEventHandler(MarkerControl_MouseEnter);

            Popup.Placement = PlacementMode.Mouse;
            Popup.Child = new MyMarkerRedAnchorDepict(geoTitle);// Label;
        }

        private void CustomMarkerDemo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (IsMouseCaptured)
            {
                Mouse.Capture(null);
            }
        }

        private void CustomMarkerDemo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsMouseCaptured)
            {
                Mouse.Capture(this);
            }
        }

        private void CustomMarkerDemo_MouseMove(object sender, MouseEventArgs e)
        {
            //if (e.LeftButton == MouseButtonState.Pressed && IsMouseCaptured)
            //{
            //    Point p = e.GetPosition(MainWindow.MainMap);
            //    Marker.Position = MainWindow.MainMap.FromLocalToLatLng((int)p.X, (int)p.Y);
            //    MainWindowViewModel.SMainwindowViewModel.GeoData.Latitude = Marker.Position.Lat;
            //    MainWindowViewModel.SMainwindowViewModel.GeoData.Langitude = Marker.Position.Lng;
            //    MainWindowViewModel.SMainwindowViewModel.RefreshGeoData();
            //}
        }

        private void MarkerControl_MouseLeave(object sender, MouseEventArgs e)
        {

            Marker.ZIndex -= 11000;
            Popup.IsOpen = false;
        }

        private void MarkerControl_MouseEnter(object sender, MouseEventArgs e)
        {
            Marker.ZIndex += 11000;
            Popup.IsOpen = true;

            Point p = e.GetPosition(MainWindow.MainMap);
            var point = MainWindow.MainMap.FromLocalToLatLng((int)p.X, (int)p.Y);
            MainWindowViewModel.SMainwindowViewModel.GeoData.Latitude = point.Lat;
            MainWindowViewModel.SMainwindowViewModel.GeoData.Langitude = point.Lng;
            MainWindowViewModel.SMainwindowViewModel.RefreshGeoData();
        }
    }
}
