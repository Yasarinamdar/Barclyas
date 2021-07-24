using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileData;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestVersion()
        {
            string fileArg = "-v";
            string filePath = @"C:/test.txt";
            Assert.IsTrue(Program.ProcessTask(fileArg, filePath));
        }

        [TestMethod]
        public void TestSize()
        {
            string fileArg = "-s";
            string filePath = @"C:/test.txt";
            Assert.IsTrue(Program.ProcessTask(fileArg, filePath));
        }
    }
}

