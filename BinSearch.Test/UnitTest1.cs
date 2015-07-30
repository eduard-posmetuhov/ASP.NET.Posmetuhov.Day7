using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinSearchLib;

namespace BinSearch.Test
{
    [TestClass]
    public class BinSearchTest
    {
        [TestMethod]
        public void IntExistValue()
        {
            int[] arr = { 0, 1, 2, 3, 4, 5 };
            int position = BinarySearch.Search(arr, 3);
            Assert.AreEqual(position, 3);
        }

        [TestMethod]
        public void IntNotExistValue()
        {
            int[] arr = { 0, 1, 2, 4, 5 };
            int position = BinarySearch.Search(arr, 3);
            Assert.AreEqual(position, -1);
        }

        [TestMethod]
        public void CustomClassExistValue()
        {
            Book[] arr = { new Book(100, 1990), new Book(110, 1990), new Book(120, 1990) };
            int position = BinarySearch.Search(arr, new Book(110, 1991));
            Assert.AreEqual(position, 1);
        }

        [TestMethod]
        public void CustomClassNotExistValue()
        {
            Book[] arr = { new Book(100, 1990), new Book(110, 1990), new Book(120, 1990) };
            int position = BinarySearch.Search(arr, new Book(111, 1991));
            Assert.AreEqual(position, -1);
        }

        [TestMethod]
        public void CustomClassExistValueDeligateComparer()
        {
            Book[] arr = { new Book(100, 1989), new Book(110, 1991), new Book(120, 1993) };
            int position = BinarySearch.Search(arr, new Book(111, 1991),(a, b) =>
            {
                if (ReferenceEquals(a, b))
                {
                    return 0;
                }
                if (ReferenceEquals(a, null))
                {
                    return -1;
                }
                if (ReferenceEquals(b, null))
                {
                    return 1;
                }
                if (a.Year > b.Year)
                {
                    return 1;
                }
                if (a.Year < b.Year)
                {
                    return -1;
                }
                return 0;
            });
            Assert.AreEqual(position, 1);
        }

        [TestMethod]
        public void EmptyArray()
        {
            int[] arr = new int[0];
            int position = BinarySearch.Search(arr, 5);
            Assert.AreEqual(position, -1);
        }

        [TestMethod]
        public void ArrayNullReferenceException()
        {
            try
            {            
                int[] arr = null;
                int position = BinarySearch.Search(arr, 5);
            }
            catch (ArgumentNullException e)
            {
                StringAssert.Contains(e.Message, "Bad array");
            }            
        }

        [TestMethod]
        public void TypeNotImplementIComparable()
        {
            try
            {
                byte[] arr = {1,2,3};
                int position = BinarySearch.Search(arr, (byte)5);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "Value not implement the interface IComparable");
            }
        }




    }
}
