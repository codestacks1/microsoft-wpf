using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Xiaowen.CodeStacks.UserControls.ViewModels
{
    public class CodeStacksListViewModel : BindableBase
    {
        #region Properties

        ObservableCollection<string> _demoDataItems;
        public ObservableCollection<string> DemoDataItems
        {
            get { return _demoDataItems; }
            set { SetProperty(ref _demoDataItems, value); }
        }

        string _demoDataItem;
        public string DemoDataItem
        {
            get { return _demoDataItem; }
            set { SetProperty(ref _demoDataItem, value); }
        }

        #endregion

        public CodeStacksListViewModel()
        {
            for (int i = 0; i < 1000; i++)
            {
                DemoDataItems.Add(i + " - CodeStacks.Wpf");
            }
        }

    }
}
