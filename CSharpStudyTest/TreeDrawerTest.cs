﻿using CSharpStudy.Image;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpStudyTest
{
    [TestClass]
    public class TreeDrawerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            TreeDrawer td = new TreeDrawer(400);
            td.Draw(@".\tree.png");
        }
    }
}
