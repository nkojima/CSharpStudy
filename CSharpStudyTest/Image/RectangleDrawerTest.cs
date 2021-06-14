using System;
using CSharpStudy.Image;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpStudyTest.Image
{
    [TestClass]
    public class RectangleDrawerTest
    {
        private const string BITMAP_PATH = @"C:\Users\NKOJIMA\source\repos\CSharpStudy\CSharpStudy\Image\rectangle.png";

        /// <summary>
        /// 実行用のテストコード。
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            RectangleDrawer drawer = new RectangleDrawer();
            drawer.Draw(BITMAP_PATH);
        }
    }
}
