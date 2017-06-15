
namespace xiaowen.codestacks.gmap.demo
{
    using GMap.NET.WindowsPresentation;
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    /// the custom map f GMapControl 
    /// </summary>
    public class Map : GMapControl
    {
        public long ElapsedMilliseconds;

        DateTime start;
        DateTime end;
        int delta;

        readonly Typeface tf = new Typeface("GenericSansSerif");
        readonly System.Windows.FlowDirection fd = new System.Windows.FlowDirection();

        /// <summary>
        /// any custom drawing here
        /// </summary>
        /// <param name="drawingContext"></param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            start = DateTime.Now;
            base.OnRender(drawingContext);
            end = DateTime.Now;
            delta = (int)(end - start).TotalMilliseconds;

            FormattedText text = new FormattedText(string.Format("xiaowen.codestacks.wpf.gmap"), CultureInfo.InvariantCulture, fd, tf, 12, Brushes.Gray);
            drawingContext.DrawText(text, new Point(text.Height, text.Height));
            text = null;
        }
    }
}
