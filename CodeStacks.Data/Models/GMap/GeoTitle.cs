using System.Windows;

namespace Xiaowen.CodeStacks.Data.Models.GMap
{
    public class GeoTitle
    {
        string _header = "Anchor Info";
        Visibility _isVisible = Visibility.Collapsed;
        public Visibility IsVisible
        {
            get { return _isVisible; }
            set { _isVisible = value; }
        }
        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }

        public string Content1 { get; set; }
        public string Content2 { get; set; }
        public string Content3 { get; set; }
        public string Content4 { get; set; }
        public string Content5 { get; set; }
        public string Content6 { get; set; }
        public string Content7 { get; set; }
        public string Content8 { get; set; }
        public string Content9 { get; set; }
        public string Content10 { get; set; }


        public string Content1Value { get; set; }
        public string Content2Value { get; set; }
        public string Content3Value { get; set; }
        public string Content4Value { get; set; }
        public string Content5Value { get; set; }
        public string Content6Value { get; set; }
        public string Content7Value { get; set; }
        public string Content8Value { get; set; }
        public string Content9Value { get; set; }
        public string Content10Value { get; set; }


        Visibility _content1Visible = Visibility.Collapsed;
        Visibility _content2Visible = Visibility.Collapsed;
        Visibility _content3Visible = Visibility.Collapsed;
        Visibility _content4Visible = Visibility.Collapsed;
        Visibility _content5Visible = Visibility.Collapsed;
        Visibility _content6Visible = Visibility.Collapsed;
        Visibility _content7Visible = Visibility.Collapsed;
        Visibility _content8Visible = Visibility.Collapsed;
        Visibility _content9Visible = Visibility.Collapsed;
        Visibility _content10Visible = Visibility.Collapsed;

        public Visibility Content1Visible { get { return _content1Visible; } set { _content1Visible = value; } }
        public Visibility Content2Visible { get { return _content2Visible; } set { _content2Visible = value; } }
        public Visibility Content3Visible { get { return _content3Visible; } set { _content3Visible = value; } }
        public Visibility Content4Visible { get { return _content4Visible; } set { _content4Visible = value; } }
        public Visibility Content5Visible { get { return _content5Visible; } set { _content5Visible = value; } }
        public Visibility Content6Visible { get { return _content6Visible; } set { _content6Visible = value; } }
        public Visibility Content7Visible { get { return _content7Visible; } set { _content7Visible = value; } }
        public Visibility Content8Visible { get { return _content8Visible; } set { _content8Visible = value; } }
        public Visibility Content9Visible { get { return _content9Visible; } set { _content9Visible = value; } }
        public Visibility Content10Visible { get { return _content10Visible; } set { _content10Visible = value; } }

    }
}
