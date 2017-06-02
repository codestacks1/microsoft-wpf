using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace xiaowen.codestacks.wpf.Utilities
{
    /// <summary>
    /// 反射跳转至其他标签或页面
    /// </summary>
    public class ReflactionView
    {
        ReflactionView() { }

        /// <summary>
        /// 跳转至某一标签
        /// </summary>
        /// <param name="obj">数据对象</param>
        /// <param name="index">标签索引 0-</param>
        /// <param name="viewName">view名称</param>
        /// <param name="methodName">要执行方法名</param>
        public static void GoTo1(object obj, int index, string viewName, string methodName)
        {
            if (obj != null)
            {
                try
                {
                    //var curWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(x => x.Name == viewName);

                    foreach (Window window in Application.Current.Windows)
                    {
                        TypeInfo objType = window.GetType() as TypeInfo;
                        if (viewName.Equals(objType.Name))
                        {
                            Grid grid = window.Content as Grid;
                            grid = grid.Children[1] as Grid;
                            StackPanel stackPanel = grid.Children[0] as StackPanel;
                            ToggleButton tBtn = stackPanel.Children[index] as ToggleButton;
                            object _data = window.DataContext;
                            IEnumerable<MethodInfo> imethods = objType.DeclaredMethods;
                            var exeMethod = imethods.FirstOrDefault(m => m.Name == methodName) ?? null;
                            if (exeMethod != null)
                            {
                                RoutedEventArgs e = new RoutedEventArgs(ToggleButton.ClickEvent);
                                e.Source = obj;
                                exeMethod.Invoke(window, new object[] { tBtn, e });
                                break;
                            }
                            else
                            {
                                throw new Exception(string.Format("未找到{0}方法", methodName));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="index"></param>
        /// <param name="viewName"></param>
        /// <param name="methodName"></param>
        static void GoTo2(object obj, int index, string viewName, string methodName)
        {

        }

    }
}
