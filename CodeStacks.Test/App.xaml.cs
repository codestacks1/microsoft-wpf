using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using xiaowen.codestacks.popwindow.Views;

namespace CodeStacks.Test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //CodeStacksMessageBox mb = new CodeStacksMessageBox(true);
            //mb.Show();

            var screenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height.ToString();
            var screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width.ToString();
        }
    }
}
