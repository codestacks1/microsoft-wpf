using System.Windows;
using Prism.Unity;
using System;
using XIAOWEN.GMAP.Views;

namespace XIAOWEN.GMAP
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            //MainWindow mainWindow = new MainWindow();
            //Type t = mainWindow.GetType();
            //return Container.Resolve(t, "", null);
            return new MainWindow();

        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
    }
}
