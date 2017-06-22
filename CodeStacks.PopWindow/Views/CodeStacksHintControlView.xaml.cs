using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Xiaowen.CodeStacks.PopWindow.Views
{
    /// <summary>
    /// Interaction logic for CodeStacksHintControlView.xaml
    /// </summary>
    public partial class CodeStacksHintControlView : UserControl
    {
        public CodeStacksHintControlView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 内容提示
        /// </summary>
        /// <param name="wrapText">需要显示的文本内容</param>
        public CodeStacksHintControlView(string wrapText) : this()
        {
            TxtContent.Text = wrapText;
        }

        /// <summary>
        /// 内容提示
        /// </summary>
        /// <param name="popup"></param>
        /// <param name="wrapText">需要显示的文本内容</param>
        public CodeStacksHintControlView(Popup popup, string wrapText) : this()
        {
            popup.Placement = PlacementMode.Mouse;
            TxtContent.Text = wrapText;
        }
    }
}
