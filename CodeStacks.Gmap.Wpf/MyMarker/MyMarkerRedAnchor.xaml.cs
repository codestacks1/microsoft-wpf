using GMap.NET.WindowsPresentation;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using xiaowen.codestacks.wpf.Views.UserControls;
using xiaowen.codestacks.wpf.ViewModels;
using System;

namespace xiaowen.codestacks.wpf.MyMarker
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
        public MyMarkerRedAnchor(MyMapControl window, GMapMarker marker, string title, params object[] viewModels)
        {
            InitializeComponent();

            this.MainWindow = window;
            this.Marker = marker;

            Popup = new Popup();
            //Label = new Label();

            this.MouseLeftButtonUp += new MouseButtonEventHandler(CustomMarkerDemo_MouseLeftButtonUp);
            this.MouseLeftButtonDown += new MouseButtonEventHandler(CustomMarkerDemo_MouseLeftButtonDown);
            this.MouseMove += new MouseEventHandler(CustomMarkerDemo_MouseMove);
            this.MouseLeave += new MouseEventHandler(MarkerControl_MouseLeave);
            this.MouseEnter += new MouseEventHandler(MarkerControl_MouseEnter);

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
            Popup.Child = new MyMarkerRedAnchorDepict();// Label;
            
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
                MainWindowViewModel.SMainwindowViewModel.GeoData.Latitude = Marker.Position.Lat;
                MainWindowViewModel.SMainwindowViewModel.GeoData.Langitude = Marker.Position.Lng;
                MainWindowViewModel.SMainwindowViewModel.RefreshGeoData();
            }
        }

        private void CustomMarkerDemo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsMouseCaptured)
            {
                Mouse.Capture(this);
            }
        }

        private void CustomMarkerDemo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (IsMouseCaptured)
            {
                Mouse.Capture(null);
            }
        }
    }
}
