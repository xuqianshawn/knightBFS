using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Knight;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Program.SetBounary(3, 4);
            Node start = new Node(0,0,0);
            Node dist = new Node(1,1, 0);
            Assert.AreEqual(Knight.Program.BFS(start,dist),4);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Program.SetBounary(3, 3);
            Node start = new Node(0, 2, 0);
            Node dist = new Node(2, 0, 0);
            Assert.AreEqual(Knight.Program.BFS(start, dist), 4);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Program.SetBounary(3, 3);
            Node start = new Node(1, 1, 0);
            Node dist = new Node(2, 1, 0);
            Assert.AreEqual(Knight.Program.BFS(start, dist), -1);
        }
    }
}
