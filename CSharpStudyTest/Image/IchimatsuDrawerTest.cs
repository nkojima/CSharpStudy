using System;
using CSharpStudy.Image;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpStudyTest.Image
{
    [TestClass]
    public class IchimatsuDrawerTest
    {
        private const string BITMAP_PATH1 = @"C:\Users\NKOJIMA\source\repos\CSharpStudy\CSharpStudy\Image\ichimatsu1.png";

        private const string BITMAP_PATH2 = @"C:\Users\NKOJIMA\source\repos\CSharpStudy\CSharpStudy\Image\ichimatsu2.png";

        /// <summary>
        /// キャンバスサイズが格子サイズで割り切れるパターン。
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            IchimatsuDrawer drawer = new IchimatsuDrawer();
            drawer.Draw(BITMAP_PATH1, Brushes.DarkGreen, Brushes.Black);
        }

        /// <summary>
        /// キャンバスサイズが格子サイズで割り切れないパターン。
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            IchimatsuDrawer drawer = new IchimatsuDrawer(310, 210);
            drawer.Draw(BITMAP_PATH2, Brushes.DarkGreen, Brushes.Black);
        }
    }
}
