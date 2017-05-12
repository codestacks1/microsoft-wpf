using Prism.Mvvm;
using xiaowen.codestacks.gmap.demo.Models;

namespace xiaowen.codestacks.wpf.ViewModels
{
    public partial class MainWindowViewModel : BindableBase
    {
        Cmd _cmd;
        public Cmd Cmd
        {
            get { return _cmd; }
            set { SetProperty(ref _cmd, value); }
        }
    }
}
