using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using System.Windows.Input;
using xiaowen.codestacks.data.SenSingModels;

namespace xiaowen.codestacks.popwindow.ViewModels
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
