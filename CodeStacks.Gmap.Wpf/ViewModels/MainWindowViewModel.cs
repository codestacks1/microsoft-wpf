using Prism.Mvvm;
using System.Windows;
using Xiaowen.CodeStacks.Data.Models.GMap;
using Xiaowen.CodeStacks.Wpf.Gmap.Views;

namespace Xiaowen.CodeStacks.Wpf.Gmap.ViewModels
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
