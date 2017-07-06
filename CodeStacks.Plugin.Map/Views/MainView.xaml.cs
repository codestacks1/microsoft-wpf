using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using Xiaowen.CodeStacks.Data.Interfaces;
using System.Windows;
using Xiaowen.CodeStacks.Data.Models.GMap;
using System;
using System.Windows.Input;

namespace CodeStacks.Plugin.Map.Views
{
    [Export(typeof(IMainWindowContract))]
    [ExportMetadata("Title", "Plugin.Map")]
    [ExportMetadata("MenuText", "高德地图")]
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl, IMainWindowContract
    {
        public MainView()
        {
            InitializeComponent();
            this.Loaded += MainView_Loaded;
        }

        private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            //鼠标点击事件
            MainMap.MouseLeftBtnUp = MainMap_AnchorMouseLeftButtonUp;
            //MainMap.MouseLeftBtnUp_Args = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left)
            //{
            //    RoutedEvent = UIElement.MouseLeftButtonUpEvent,
            //    Source = mcc.TcChaneelID
            //};

            MainMap.Points = new ObservableCollection<GMap.NET.PointLatLng>();
            //MainMap.Route.IsRoute = true;
            //MainMap.Route.Delay = 0;

            //MainMap.Points.Add(new GMap.NET.PointLatLng(39.9719321233495, 116.337801218033, "Red", null, new GeoTitle() { IsVisible = Visibility.Collapsed, Content1 = "content1", Content1Visible = Visibility.Visible }, null));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        private void MainMap_AnchorMouseLeftButtonUp(object arg1, MouseButtonEventArgs arg2)
        {
            throw new NotImplementedException();
        }

        public string MenuItemText
        {
            get { return "AMap"; }
        }

        public string SubWindowTitle
        {
            get { return "Plugin.Map"; }
        }
    }
}
