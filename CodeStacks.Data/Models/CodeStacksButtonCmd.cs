using System.Windows.Input;

namespace Xiaowen.CodeStacks.Data.Models
{
    public class CodeStacksButtonCmd
    {
        public CodeStacksButtonCmd()
        {

        }

        public ICommand CmdConfirm { get; set; }
        public ICommand CmdCancel { get; set; }
        public bool IsConfirm { get; set; }
    }
}
