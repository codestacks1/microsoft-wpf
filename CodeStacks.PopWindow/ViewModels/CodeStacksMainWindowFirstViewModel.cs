using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace xiaowen.codestacks.popwindow.ViewModels
{
    public class CodeStacksMainWindowFirstViewModel
    {
        public CodeStacksMainWindowFirstViewModel()
        {
            InitCommand();
        }


        #region Properties



        #endregion

        #region Commands

        public ICommand HomeBtnCommand { get; set; }

        private void InitCommand() {
            HomeBtnCommand = new DelegateCommand<object>(HomeBtnCommandFunc);
        }

        private void HomeBtnCommandFunc(object obj)
        {
            CodeStacksWindow.MessageBox.Invoke(false, false, 1, "success!!!");
        }

        #endregion

    }
}
