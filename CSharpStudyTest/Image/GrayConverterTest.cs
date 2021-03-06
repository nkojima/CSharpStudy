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
    public class GrayConverterTest
    {
        private const string BITMAP1_PATH = @"C:\Users\NKOJIMA\source\repos\CSharpStudy\CSharpStudy\Image\cat1.png";
        private const string GRAY_IMG_PATH = @"C:\Users\NKOJIMA\source\repos\CSharpStudy\CSharpStudy\Image\gray_image.png";

        [TestMethod]
        public void TestMethod1()
        {
            GrayConverter gConverter = new GrayConverter();
            gConverter.ToGrayScale(BITMAP1_PATH, GRAY_IMG_PATH);
        }
    }
}
