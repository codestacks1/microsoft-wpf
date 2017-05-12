using System.Windows;
using xiaowen.codestacks.data;
using xiaowen.codestacks.popwindow;
using xiaowen.codestacks.popwindow.Views;

namespace CodeStacks.Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var s = CodeStacksWindow.MessageBox.Invoke(true, false, 2, "Welcome to codestacks!");

            CodeStacksWindow.MessageBox.Invoke(false, false, 2, s.ToString());

            string s1 = string.Empty;

            //CodeStacksDataHandler.UIThread.Invoke(() =>
            //{
            //    var sh = new CodeStacksMessageBox(isConfirm: true, err: "Welcome to codestacks!").ShowWindow();

            //    var sh1 = sh;
            //});

            //CodeStacksDataHandler.UIThread.Invoke(() =>
            //{
            //    var sh = new CodeStacksMessageBox(isConfirm: true, err: "Welcome to codestacks!").ShowWindow();

            //    var sh1 = sh;
            //});
        }
    }
}
