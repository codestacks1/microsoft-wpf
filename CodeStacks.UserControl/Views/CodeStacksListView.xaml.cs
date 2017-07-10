using System.Windows.Controls;
using Xiaowen.CodeStacks.UserControls.ViewModels;

namespace Xiaowen.CodeStacks.UserControls.Views
{
    /// <summary>
    /// Interaction logic for CodeStacksListView.xaml
    /// </summary>
    public partial class CodeStacksListView : UserControl
    {
        public CodeStacksListView()
        {
            InitializeComponent();
            this.DataContext = new CodeStacksListViewModel();
        }
    }
}
