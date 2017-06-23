using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using Xiaowen.CodeStacks.Data.Models;
using System;

namespace Xiaowen.CodeStacks.PopWindow.ViewModels
{
    public class CodeStacksMessageBoxViewModel : BindableBase
    {
        public CodeStacksMessageBoxViewModel()
        {
            CloseWindow = new CodeStacksCloseWindow();
            ButtonCmdModel = new CodeStacksButtonCmd();
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

        CodeStacksCloseWindow _closeWindow;
        public CodeStacksCloseWindow CloseWindow
        {
            get { return _closeWindow; }
            set { SetProperty(ref _closeWindow, value); }
        }

        public CodeStacksButtonCmd _buttonCmdModel;
        public CodeStacksButtonCmd ButtonCmdModel
        {
            get { return _buttonCmdModel; }
            set { SetProperty(ref _buttonCmdModel, value); }
        }
    }
}
