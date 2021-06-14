using System;
using CSharpStudy.Image;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpStudyTest.Image
{
    [TestClass]
    public class ImageComparatorTest
    {
        private const string BITMAP1_PATH = @"C:\Users\NKOJIMA\source\repos\CSharpStudy\CSharpStudy\Image\cat1.png";
        private const string BITMAP2_PATH = @"C:\Users\NKOJIMA\source\repos\CSharpStudy\CSharpStudy\Image\cat2.png";
        private const string DIFF_IMG_PATH = @"C:\Users\NKOJIMA\source\repos\CSharpStudy\CSharpStudy\Image\diff_image.png";

        [TestMethod]
        public void TestMethod1()
        {
            bool isSame = ImageComparator.Compare(BITMAP1_PATH, BITMAP2_PATH, DIFF_IMG_PATH);

            if (isSame)
            {
                System.Console.WriteLine("2つの画像は同じです。");
            }
            else
            {
                System.Console.WriteLine("2つの画像は異なります。");
                System.Console.WriteLine("次の差分ファイルを確認してください。:" + DIFF_IMG_PATH);
            }
        }
    }
}
