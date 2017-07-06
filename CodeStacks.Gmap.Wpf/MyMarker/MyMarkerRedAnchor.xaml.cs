using GMap.NET.WindowsPresentation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Xiaowen.CodeStacks.Data.Models.GMap;
using Xiaowen.CodeStacks.Wpf.Gmap.ViewModels;
using Xiaowen.CodeStacks.Wpf.Gmap.Views;

namespace Xiaowen.CodeStacks.Wpf.Gmap.MyMarker
{
    /// <summary>
    /// Interaction logic for MyMarkerRedAnchor.xaml
    /// </summary>
    public partial class MyMarkerRedAnchor : UserControl
    {
        Popup Popup;
        //Label Label;
        GMapMarker Marker;
        MyMapControl MainWindow;
        public MyMarkerRedAnchor(MyMapControl window, GMapMarker marker, GeoTitle geTitle, string title, params object[] viewModels)
        {
            InitializeComponent();
            
            //Label = new Label();

            this.MouseLeftButtonUp += new MouseButtonEventHandler(CustomMarkerDemo_MouseLeftButtonUp);
            this.MouseLeftButtonDown += new MouseButtonEventHandler(CustomMarkerDemo_MouseLeftButtonDown);
            this.MouseMove += new MouseEventHandler(CustomMarkerDemo_MouseMove);
            this.MouseLeave += new MouseEventHandler(MarkerControl_MouseLeave);
            this.MouseEnter += new MouseEventHandler(MarkerControl_MouseEnter);

            this.MainWindow = window;
            this.Marker = marker;
            Popup = new Popup();
            Popup.Placement = PlacementMode.Mouse;
            //{
            //    Label.Background = Brushes.Blue;
            //    Label.Foreground = Brushes.White;
            //    Label.BorderBrush = Brushes.WhiteSmoke;
            //    Label.BorderThickness = new Thickness(2);
            //    Label.Padding = new Thickness(5);
            //    Label.FontSize = 16;
            //    Label.Content = title;
            //}
            Popup.Child = new MyMarkerRedAnchorDepict(geTitle);// Label;
        }

        private void MarkerControl_MouseEnter(object sender, MouseEventArgs e)
        {
            Marker.ZIndex += 10000;
            Popup.IsOpen = true;
        }

        private void MarkerControl_MouseLeave(object sender, MouseEventArgs e)
        {
            Marker.ZIndex -= 10000;
            Popup.IsOpen = false;
        }

        private void CustomMarkerDemo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && IsMouseCaptured)
            {
                Point p = e.GetPosition(MainWindow.MainMap);
                Marker.Position = MainWindow.MainMap.FromLocalToLatLng((int)p.X, (int)p.Y);
                MainWindowViewModel.SMainwindowViewModel.GeoData.Latitude = MainWindow.Latitude = Marker.Position.Lat;
                MainWindowViewModel.SMainwindowViewModel.GeoData.Langitude = MainWindow.Longtitude = Marker.Position.Lng;
                MainWindowViewModel.SMainwindowViewModel.RefreshGeoData();
            }
        }

        private void CustomMarkerDemo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsMouseCaptured)
            {
                Mouse.Capture(this);
                MainWindow.MainMap.CanDragMap = false;
            }
        }

        private void CustomMarkerDemo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (IsMouseCaptured)
            {
                MainWindow.Latitude = Marker.Position.Lat;
                MainWindow.Longtitude = Marker.Position.Lng;

                Mouse.Capture(null);
                MainWindow.MainMap.CanDragMap = true;
            }
        }
    }
}
