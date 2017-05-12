using Prism.Mvvm;
using xiaowen.codestacks.gmap.demo.Models;
using xiaowen.codestacks.wpf.Views.UserControls;

namespace xiaowen.codestacks.wpf.ViewModels
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
