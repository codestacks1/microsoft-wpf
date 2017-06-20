using System;
using System.Windows;

namespace xiaowen.codestacks.popwindow.Views
{
    /// <summary>
    /// Interaction logic for CodeStacksSigninWindow.xaml
    /// </summary>
    public partial class CodeStacksSigninWindow : Window
    {
        public CodeStacksSigninWindow()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();           
        }
    }
}
