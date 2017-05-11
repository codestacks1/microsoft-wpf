using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using xiaowen.codestacks.data.Models;

namespace xiaowen.codestacks.popwindow.ViewModels
{
    public class CodeStacksMessageBoxViewModel : BindableBase
    {
        public CodeStacksMessageBoxViewModel()
        {
            CloseWindow = new CloseWindowModel();
            CloseWindow.CmdClose = new DelegateCommand<object>(CloseWindowFunc);
        }

        private void CloseWindowFunc(object obj)
        {
            if (obj is Window)
            {
                Window window = obj as Window;
                window.Close();
            }
        }

        CloseWindowModel _closeWindow;
        public CloseWindowModel CloseWindow
        {
            get { return _closeWindow; }
            set { SetProperty(ref _closeWindow, value); }
        }
    }
}
