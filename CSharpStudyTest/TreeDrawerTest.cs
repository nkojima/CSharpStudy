using System;
using CSharpStudy.Image;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpStudyTest
{
    [TestClass]
    public class TreeDrawerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            TreeDrawer td = new TreeDrawer();
            td.DrawTree(500);
        }
    }
}
