using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using System.Windows.Input;
using Xiaowen.CodeStacks.Data.SenSingModels;

namespace Xiaowen.CodeStacks.PopWindow.ViewModels
{
    public class CodeStacksComparePopInfoViewModel : BindableBase
    {
        #region Properties

        Person _person;
        public Person Person
        {
            get { return _person; }
            set { SetProperty(ref _person, value); }
        }

        Camera _camera;
        public Camera Camera
        {
            get { return _camera; }
            set { SetProperty(ref _camera, value); }
        }

        Compare _compare;
        public Compare Compare
        {
            get { return _compare; }
            set { SetProperty(ref _compare, value); }
        }

        #endregion

        #region Command

        public ICommand CopyCommand { get; set; }

        #endregion

        public CodeStacksComparePopInfoViewModel()
        {
            CopyCommand = new DelegateCommand<object>(CopyCommandFunc);
        }

        private void CopyCommandFunc(object obj)
        {
            Clipboard.SetDataObject(obj);
        }
    }
}
