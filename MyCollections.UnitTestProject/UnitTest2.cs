using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCollections.Lib;

namespace MyCollections.UnitTestProject
{
    /// <summary>
    /// Summary description for UnitTest2
    /// </summary>
    [TestClass]
    public class UnitTest2
    {
        SinglyLinkedList<int> list;
        int[] mas;

        [TestInitialize]
        public void TestInitialize()
        {
            mas = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            list = new SinglyLinkedList<int>(mas);
        }

        [TestMethod]
        public void MyListCtorValueTest()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            Assert.IsNotNull(list);
            Assert.AreEqual(0, list.Count);
            Assert.IsFalse(list.IsReadOnly);
        }

        [TestMethod]
        public void MyListCtorReferenceTest()
        {
            SinglyLinkedList<string> list = new SinglyLinkedList<string>();
            Assert.IsNotNull(list);
            Assert.AreEqual(0, list.Count);
            Assert.IsFalse(list.IsReadOnly);
        }

        [TestMethod]
        public void MyListAddTest()
        {
            list = new SinglyLinkedList<int>();
            Assert.AreEqual(0, list.Count);
            list.Add(100);
            Assert.AreEqual(1, list.Count);
            for (int i = 0; i < 10000; ++i)
            {
                list.Add(i);
            }
            Assert.AreEqual(10001, list.Count);
        }

        [TestMethod]
        public void MyListAppendFirstTest()
        {
            list = new SinglyLinkedList<int>();
            Assert.AreEqual(0, list.Count);
            list.Add(100);
            Assert.AreEqual(1, list.Count);
            for (int i = 0; i < 10000; ++i)
            {
                list.AppendFirst(i);
            }
            Assert.AreEqual(10001, list.Count);
        }

        [TestMethod]
        public void MyListItemTest_Get()
        {
            for (int i = 0; i < mas.Length; ++i)
            {
                Assert.AreEqual(mas[i], list[i]);
            }
        }

        [TestMethod]
        public void MyListItemTest_Set()
        {
            list[0] = 101;
            list[5] = 106;
            list[9] = 110;
            Assert.AreEqual(101, list[0]);
            Assert.AreEqual(106, list[5]);
            Assert.AreEqual(110, list[9]);
        }


        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void MyListItemTest_GetException_1()
        {
            list = new SinglyLinkedList<int>();
            Assert.AreEqual(10, list[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void MyListItemTest_GetException_2()
        {
            list = new SinglyLinkedList<int>();
            Assert.AreEqual(10, list[-1]);
        }


        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void MyListItemTest_SetException_1()
        {
            list[10] = 100;
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void MyListItemTest_SetException_2()
        {
            list = new SinglyLinkedList<int>();
            list[0] = 100;
        }

        [TestMethod]
        public void MyListClearTest()
        {
            Assert.AreEqual(10, list.Count);
            list.Clear();
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void MyListContainsTest()
        {
            Assert.IsTrue(list.Contains(1));
            Assert.IsTrue(list.Contains(6));
            Assert.IsTrue(list.Contains(10));

            Assert.IsFalse(list.Contains(-1));
            Assert.IsFalse(list.Contains(25));
            Assert.IsFalse(list.Contains(int.MaxValue));
            Assert.IsFalse(list.Contains(int.MinValue));
        }

        [TestMethod]
        public void MyListEnumeratorTest()
        {
            int index = 0;

            foreach (int x in list)
                Assert.AreEqual(mas[index++], x);
        }

        [TestMethod]
        public void MyListCopyToTest()
        {
            int[] arr = new int[list.Count];
            list.CopyTo(arr, 0);

            for (int i = 0; i < mas.Length; ++i)
                Assert.AreEqual(mas[i], arr[i]);
        }

        [TestMethod]
        public void MyListIndexOfTest()
        {
            Assert.AreEqual(0, list.IndexOf(1));
            Assert.AreEqual(9, list.IndexOf(10));
            Assert.AreEqual(4, list.IndexOf(5));
            Assert.AreEqual(-1, list.IndexOf(0));
            Assert.AreEqual(-1, list.IndexOf(100));
            Assert.AreEqual(-1, list.IndexOf(int.MaxValue));
            Assert.AreEqual(-1, list.IndexOf(int.MinValue));
        }

        [TestMethod]
        public void MyListRemoveAtTest()
        {
            list.RemoveAt(0);
            Assert.AreEqual(9, list.Count);
            Assert.AreEqual(2, list[0]);

            list.RemoveAt(8);
            Assert.AreEqual(8, list.Count);
            Assert.AreEqual(9, list[7]);
        }

        [TestMethod]
        public void MyListRemoveAtTest_2()
        {
            list = new SinglyLinkedList<int>();
            list.Add(10);
            list.RemoveAt(0);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void MyListRemoveTest()
        {
            list.Remove(1);
            Assert.AreEqual(9, list.Count);
            Assert.AreEqual(2, list[0]);

            list.Remove(10);
            Assert.AreEqual(8, list.Count);
            Assert.AreEqual(9, list[7]);
        }

        [TestMethod]
        public void MyListInsertTest()
        {
            list.Insert(0, 100);
            Assert.AreEqual(11, list.Count);
            Assert.AreEqual(100, list[0]);
            Assert.AreEqual(1, list[1]);

            list.Insert(10, 1000);
            Assert.AreEqual(12, list.Count);
            Assert.AreEqual(1000, list[10]);
            Assert.AreEqual(10, list[11]);
        }

      
    }
}
