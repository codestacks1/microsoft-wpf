using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using System.Windows.Media;
using Xiaowen.CodeStacks.Data;
using Xiaowen.CodeStacks.Data.Models;
using Xiaowen.CodeStacks.Data.SenSingModels;
using Xiaowen.CodeStacks.PopWindow.Views;

namespace Xiaowen.CodeStacks.PopWindow.ViewModels
{
    public class CodeStacksAlarmWindowViewModel : BindableBase
    {
        public CodeStacksAlarmWindowViewModel()
        {
            CloseWindow = new CloseWindowModel();
            CloseWindow.CmdClose = new DelegateCommand<object>(CloseWindowFunc);
        }

        public CodeStacksAlarmWindowViewModel(Compare obj) : this()
        {
            if (obj != null)
            {
                RootBackground = CodeStacksDataHandler.ImageData.ConvertToImageSourceDelegate1(obj.Template.TypePhotoPath);
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

        public ImageSource _rootBackground;
        public ImageSource RootBackground
        {
            get { return _rootBackground; }
            set { SetProperty(ref _rootBackground, value); }
        }


    }
}
