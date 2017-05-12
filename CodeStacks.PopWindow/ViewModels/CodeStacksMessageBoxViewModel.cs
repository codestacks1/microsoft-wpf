using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using xiaowen.codestacks.data.Models;
using System;

namespace xiaowen.codestacks.popwindow.ViewModels
{
    public class CodeStacksMessageBoxViewModel : BindableBase
    {
        public CodeStacksMessageBoxViewModel()
        {
            CloseWindow = new CloseWindowModel();
            ButtonCmdModel = new ButtonCmdModel();
            CloseWindow.CmdClose = new DelegateCommand<Window>(CloseWindowFunc);
            ButtonCmdModel.CmdConfirm = new DelegateCommand<Window>(ConfirmFunc);
            ButtonCmdModel.CmdCancel = new DelegateCommand<Window>(CancelFunc);
        }

        private void CancelFunc(Window window)
        {
            ButtonCmdModel.IsConfirm = false;
            this.CloseWindowFunc(window);
        }

        private void ConfirmFunc(Window window)
        {
            ButtonCmdModel.IsConfirm = true;
            RaisePropertyChanged("ButtonCmdModel");
            this.CloseWindowFunc(window);
        }

        private void CloseWindowFunc(Window window)
        {
            window.Close();
        }

        CloseWindowModel _closeWindow;
        public CloseWindowModel CloseWindow
        {
            get { return _closeWindow; }
            set { SetProperty(ref _closeWindow, value); }
        }

        public ButtonCmdModel _buttonCmdModel;
        public ButtonCmdModel ButtonCmdModel
        {
            get { return _buttonCmdModel; }
            set { SetProperty(ref _buttonCmdModel, value); }
        }
    }
}
