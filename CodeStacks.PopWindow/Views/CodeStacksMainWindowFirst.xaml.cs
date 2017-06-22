using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Xiaowen.CodeStacks.PopWindow.ViewModels;

namespace Xiaowen.CodeStacks.PopWindow.Views
{
    /// <summary>
    /// Interaction logic for CodeStacksMainWindowFirst.xaml
    /// </summary>
    public partial class CodeStacksMainWindowFirst : Window
    {
        public CodeStacksMainWindowFirst()
        {
            InitializeComponent();
            this.DataContext = new CodeStacksMainWindowFirstViewModel();
        }
    }
}
