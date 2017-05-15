using System.Windows;
using xiaowen.codestacks.data.SenSingModels;
using xiaowen.codestacks.popwindow.ViewModels;

namespace xiaowen.codestacks.popwindow.Views
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
    }
}
