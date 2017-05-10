using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CodeStacks.PopWindow.MainWindow mw = new CodeStacks.PopWindow.MainWindow();
            mw.Show();
        }
    }
}
