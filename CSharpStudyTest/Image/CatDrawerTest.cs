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
    public class CatDrawerTest
    {
        private const string BITMAP_PATH = @"C:\Users\NKOJIMA\source\repos\CSharpStudy\CSharpStudy\Image\generated_cat.png";

        [TestMethod]
        public void TestMethod1()
        {
            CatDrawer drawer = new CatDrawer();
            drawer.Draw(BITMAP_PATH);
        }
    }
}
