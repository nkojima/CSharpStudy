using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpStudy.Image;

namespace CSharpStudyTest.Image
{
    /// <summary>
    /// GrayConverterクラスのテストコード
    /// </summary>
    [TestClass]
    public class PolygonDrawerTest
    {
        private const string BITMAP_PATH = @"C:\Users\NKOJIMA\source\repos\CSharpStudy\CSharpStudy\Image\polygon.png";

        [TestMethod]
        public void TestMethod1()
        {
            PolygonDrawer drawer = new PolygonDrawer();
            drawer.Draw(BITMAP_PATH);
        }
    }
}
