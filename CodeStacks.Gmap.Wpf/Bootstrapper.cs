using System.Windows;
using Prism.Unity;
using System;
using xiaowen.codestacks.wpf.Views;

namespace xiaowen.codestacks.wpf
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            //MainWindow mainWindow = new MainWindow();
            //Type t = mainWindow.GetType();
            //return Container.Resolve(t, "", null);
            return null; //MainWindow();

        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
    }
}
