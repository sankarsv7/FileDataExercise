using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileData;

namespace FileData_Test
{
    [TestClass]
    public class FileDataTest
    {
        [TestMethod]
        public void GetFileVersion_Positive_TestMethod()
        {
            string[] input = new string[2] { "-v", "d:/test.txt" };
            string result = Program.GetFileVersion(input[0], input[1]);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void GetFileVersion_VersionFormat_Positive_TestMethod()
        {
            string[] input = new string[2] { "--version", "d:/test.txt" };
            string result = Program.GetFileVersion(input[0], input[1]);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetFileSize_Positive_TestMethod()
        {
            string[] input = new string[2] { "-s", "d:/test.txt" };
            int result = Program.GetFileSize(input[0], input[1]);
            Assert.IsNotNull(result);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void GetFileSize_SizeFormat_Positive_TestMethod()
        {
            string[] input = new string[2] { "--size", "d:/test.txt" };
            int result = Program.GetFileSize(input[0], input[1]);
            Assert.IsNotNull(result);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void GetFileVersion_InvalidVersionFormat_TestMethod()
        {
            string[] input = new string[2] { "-vdfgd", "d:/test.txt" };
            string result = Program.GetFileVersion(input[0], input[1]);
            Assert.AreEqual("",result.Trim());
        }

        [TestMethod]
        public void GetFileVersion_FileNameArgIsNull_TestMethod()
        {
            string[] input = new string[2] { "-v", "" };
            string result = Program.GetFileVersion(input[0], input[1]);
            Assert.AreEqual("", result.Trim());
        }

        [TestMethod]
        public void GetFileSize_InvalidSizeFormat_TestMethod()
        {
            string[] input = new string[2] { "-sdf", "d:/test.txt" };
            int result = Program.GetFileSize(input[0], input[1]);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetFileSize_FileNameArgIsNull_TestMethod()
        {
            string[] input = new string[2] { "-sdf", "" };
            int result = Program.GetFileSize(input[0], input[1]);
            Assert.AreEqual(0, result);
        }       
    }
}
