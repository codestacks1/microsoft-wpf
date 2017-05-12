using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using xiaowen.codestacks.data.Models;
using xiaowen.codestacks.data.SenSingModels;
using xiaowen.codestacks.popwindow.Views;

namespace xiaowen.codestacks.popwindow.ViewModels
{
    public class CodeStacksAlarmWindowViewModel : BindableBase
    {
        public CodeStacksAlarmWindowViewModel()
        {
            CloseWindow.CmdClose = new DelegateCommand<object>(CloseWindowFunc);
        }

        public CodeStacksAlarmWindowViewModel(Compare obj)
        {
            if (obj != null)
            {
                DataObject = obj;
            }
            else
            {
                new CodeStacksMessageBox().Show();
            }
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

        Compare _dataObject;
        public Compare DataObject
        {
            get { return _dataObject; }
            set { SetProperty(ref _dataObject, value); }
        }

    }
}
