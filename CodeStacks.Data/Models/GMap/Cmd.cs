using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Xiaowen.CodeStacks.Data.Models.GMap
{
    public class Cmd
    {
        public ICommand AddMarkerCommand { get; set; }
        public ICommand ClearAllCommand { get; set; }
        public ICommand PlayActiveRouteCommand { get; set; }
        public ICommand SpeedUpCommand { get; set; }
        public ICommand TakeAnchorCommand { get; set; }

        public ICommand CopyLngCmd { get; set; }
        public ICommand CopyLatCmd { get; set; }

    }
}
