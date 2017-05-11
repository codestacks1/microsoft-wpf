using System.Windows;
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
            new CodeStacksMessageBox(isCommon: true, err: "Welcome to codestacks!").Show();
        }
    }
}
