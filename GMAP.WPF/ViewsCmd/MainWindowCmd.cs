using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XIAOWEN.GMAP.DEMO.Models;

namespace XIAOWEN.GMAP.ViewModels
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
