using Prism.Mvvm;
using System.Windows;
using xiaowen.codestacks.gmap.demo.Models;
using xiaowen.codestacks.wpf.Views;

namespace xiaowen.codestacks.wpf.ViewModels
{
    public partial class MainWindowViewModel : BindableBase
    {
        public static MainWindowViewModel SMainwindowViewModel { get; set; }
        
        MyMapControl _myMapControl;
        public MyMapControl MyMapControl
        {
            get { return _myMapControl; }
            set { SetProperty(ref _myMapControl, value); }
        }

        Visibility _isMapCtrlVisible;
        public Visibility IsMapCtrlVisible
        {
            get { return _isMapCtrlVisible; }
            set { SetProperty(ref _isMapCtrlVisible, value); }
        }

        public MainWindowViewModel()
        {
            this.InitGeoTitle();
            this.InitCommand<Cmd>();
            SMainwindowViewModel = this;
        }

        public void InitGeoTitle()
        {
            GeoData = new Geo();
            GeoTitle = new GeoTitle();
        }
    }
}
