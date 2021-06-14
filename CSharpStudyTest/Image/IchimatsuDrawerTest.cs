using System;
using CSharpStudy.Image;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpStudyTest.Image
{
    [TestClass]
    public class IchimatsuDrawerTest
    {
        private const string BITMAP_PATH = @"C:\Users\NKOJIMA\source\repos\CSharpStudy\CSharpStudy\Image\ichimatsu.png";

        [TestMethod]
        public void TestMethod1()
        {
            IchimatsuDrawer drawer = new IchimatsuDrawer();
            drawer.Draw(BITMAP_PATH, Brushes.DarkGreen, Brushes.Black);
        }
    }
}
