using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Xiaowen.CodeStacks.Data.Interfaces;
using Xiaowen.CodeStacks.PopWindow.Views;

namespace CodeStacks.Mef.Wpf.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [ImportMany]
        public Lazy<IMainWindowContract, IDictionary<string, object>>[] ImportedMainFormContracts { get; set; }

        private CompositionContainer _container;
        string _extensionDir = AppDomain.CurrentDomain.BaseDirectory + @"Plugins\";

        private CompositionContainer GetContainerFromDirectory()
        {
            var catalog = new AggregateCatalog();
            var thisAssembly = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());
            catalog.Catalogs.Add(thisAssembly);
            catalog.Catalogs.Add(new DirectoryCatalog(_extensionDir));
            var container = new CompositionContainer(catalog);
            return container;
        }

        private bool Compose()
        {
            _container = GetContainerFromDirectory();
            try
            {
                _container.ComposeParts(this);
            }
            catch (CompositionException ex)
            {
                string err = ex.Message;
            }
            return true;
        }

        public MainWindow()
        {
            InitializeComponent();

            this.WindowState = WindowState.Maximized;

            bool successfulCompose = Compose();
            if (!successfulCompose)
                this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var _default = string.Empty;
            foreach (var export in this.ImportedMainFormContracts)
            {
                var exportedMenuText = _default = export.Metadata["MenuText"] as string;

                if (string.IsNullOrEmpty(exportedMenuText)) return;

                HomeComboBox0.Items.Add(exportedMenuText);
            }
            HomeComboBox0.SelectionChanged += HomeComboBox0_SelectionChanged;
        }

        private void HomeComboBox0_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cbox = sender as ComboBox;
            if (cbox == null) return;
            var item = cbox.SelectedItem as string;

            foreach (var export in this.ImportedMainFormContracts)
            {
                string menuItem = export.Metadata["MenuText"] as string;
                string title = export.Metadata["Title"] as string;
                if (string.IsNullOrEmpty(menuItem)) return;

                if (menuItem == item)
                {
                    if (export.Value is UserControl)
                    {
                        //TypeInfo objectType = export.Value.GetType() as TypeInfo;
                        //ConstructorInfo obj = objectType.GetConstructor(new Type[] { });
                        //var main = obj.Invoke(null) as UserControl;
                        UserControl ctrl = export.Value as UserControl;
                        Docker.Children.Clear();
                        Docker.Children.Add(ctrl);
                    }
                    else
                    {
                        TypeInfo objectType = export.Value.GetType() as TypeInfo;
                        ConstructorInfo obj = objectType.GetConstructor(new Type[] { });
                        Window window = obj.Invoke(null) as Window;
                        window.Show();
                    }
                    break;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //CodeStacksComparePopInfo modle = new CodeStacksComparePopInfo();
            //modle.ShowDialog();

            //CodeStacksSigninWindow signin = new CodeStacksSigninWindow();
            //signin.ShowDialog();

            //CodeStacksMainWindowFirst first = new CodeStacksMainWindowFirst();
            //first.ShowDialog();

            CodeStacksTestWindow test = new CodeStacksTestWindow();
            test.ShowDialog();


        }
    }
}
