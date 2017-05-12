using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace xiaowen.codestacks.data.Models
{
    public class ButtonCmdModel
    {
        public ButtonCmdModel()
        {

        }

        public ICommand CmdConfirm { get; set; }
        public ICommand CmdCancel { get; set; }
        public bool IsConfirm { get; set; }
    }
}
