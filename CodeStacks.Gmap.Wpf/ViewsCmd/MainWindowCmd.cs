using Prism.Mvvm;
using Xiaowen.CodeStacks.Data.Models.GMap;

namespace Xiaowen.CodeStacks.Wpf.Gmap.ViewModels
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
