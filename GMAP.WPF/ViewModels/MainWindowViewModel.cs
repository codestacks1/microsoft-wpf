using Prism.Mvvm;
using XIAOWEN.GMAP.DEMO;
using XIAOWEN.GMAP.DEMO.Models;
using XIAOWEN.GMAP.Views.UserControls;

namespace XIAOWEN.GMAP.ViewModels
{
    public partial class MainWindowViewModel : BindableBase
    {
        public static MainWindowViewModel SMainwindowViewModel { get; private set; }

        private string _title = "Prism Unity Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        MyMapControl _myMapControl;
        public MyMapControl MyMapControl
        {
            get { return _myMapControl; }
            set { SetProperty(ref _myMapControl, value); }
        }


        public MainWindowViewModel()
        {
            GeoData = new Geo();
            GeoTitle = new GeoTitle();
            this.InitCommand<Cmd>();
            SMainwindowViewModel = this;
        }
    }
}
