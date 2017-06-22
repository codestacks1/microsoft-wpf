using System.Windows;
using Xiaowen.CodeStacks.Data.SenSingModels;
using Xiaowen.CodeStacks.PopWindow.ViewModels;

namespace Xiaowen.CodeStacks.PopWindow.Views
{
    /// <summary>
    /// Interaction logic for CodeStacksAlarmWindow.xaml
    /// </summary>
    public partial class CodeStacksAlarmWindow : Window
    {
        public CodeStacksAlarmWindow()
        {
            InitializeComponent();
        }


        public CodeStacksAlarmWindow(Compare obj) : this()
        {
            this.DataContext = new CodeStacksAlarmWindowViewModel(obj);
            btnClose.CommandParameter = this;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch (System.Exception)
            {
            }
        }
    }
}
