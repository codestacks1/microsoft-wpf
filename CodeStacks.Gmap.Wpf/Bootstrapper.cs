using System.Windows;
using Prism.Unity;
using System;
using Xiaowen.CodeStacks.Wpf.Gmap.Views;

namespace Xiaowen.CodeStacks.Wpf.Gmap
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
