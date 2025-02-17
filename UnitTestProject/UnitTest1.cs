using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;


namespace StringMaskingLibrary.Tests
{
    [TestClass]
    public class MaskerTests
    {
        //Random

        [TestMethod]
        public void TestMaskStringRandom()
        {
            string input = "Hello, world!";
            string masked1 = Masker.Mask(input, new RandomMaskingStrategy(new RandomStrategy()));
            string masked2 = Masker.Mask(input, new RandomMaskingStrategy(new RandomStrategy()));
            Assert.AreNotEqual(masked1, masked2); 
        }

        [TestMethod]
        public void TestMaskIntRandom()
        {
            int input = 123456789;
            object masked1 = Masker.Mask(input, new RandomMaskingStrategy(new RandomStrategy()));
            object masked2 = Masker.Mask(input, new RandomMaskingStrategy(new RandomStrategy()));
            Assert.AreNotEqual(masked1, masked2);
        }

        [TestMethod]
        public void TestMaskDateTimeRandom()
        {
            DateTime input = DateTime.Now;
            object masked1 = Masker.Mask(input, new RandomMaskingStrategy(new RandomStrategy()));
            object masked2 = Masker.Mask(input, new RandomMaskingStrategy(new RandomStrategy()));
            Assert.AreNotEqual(masked1, masked2); 
        }

        [TestMethod]
        public void TestMaskArrayRandom()
        {
            object[] input = { 123456789, "Hello, world!", new DateTime(1999, 12, 31) };
            object[] masked1 = Masker.Mask(input, new RandomMaskingStrategy(new RandomStrategy()));
            object[] masked2 = Masker.Mask(input, new RandomMaskingStrategy(new RandomStrategy()));
            for (int i = 0; i < input.Length; i++)
            {
                Assert.AreNotEqual(masked1[i], masked2[i]);
            }
        }

        //StaticRandom

        [TestMethod]
        public void TestMaskStringStaticRandom()
        {
            string input = "Hello, world!";
            string masked1 = Masker.Mask(input, new RandomMaskingStrategy(new StaticRandomStrategy()));
            Assert.AreEqual(masked1, "L&)o'N][&qsfQ");
        }

        [TestMethod]
        public void TestMaskIntStaticRandom()
        {
            int input = 123456789;
            object masked1 = Masker.Mask(input, new RandomMaskingStrategy(new StaticRandomStrategy()));
            Assert.AreEqual(masked1, 400704650); 
        }

        [TestMethod]
        public void TestMaskDateTimeStaticRandom()
        {
            DateTime input = new DateTime(1999, 12, 31);
            object masked1 = Masker.Mask(input, new RandomMaskingStrategy(new StaticRandomStrategy()));
            object masked2 = new DateTime(465, 7, 1);
            Assert.AreEqual(masked1, masked2); 
        }

        [TestMethod]
        public void TestMaskArrayStaticRandom()
        {
            object[] input = { 123456789, "Hello, world!", new DateTime(1999, 12, 31) };
            object[] masked1 = Masker.Mask(input, new RandomMaskingStrategy(new StaticRandomStrategy()));
            object[] masked2 = { 400704650, "L&)o'N][&qsfQ", new DateTime(465, 7, 1) };
            Assert.AreEqual(masked1[0], masked2[0]);
            Assert.AreEqual(masked1[1], masked2[1]);
            Assert.AreEqual(masked1[2], masked2[2]);
        }

        //Reverse

        [TestMethod]
        public void TestMaskStringReverse()
        {
            string input = "Hello, world!";
            string masked1 = Masker.Mask(input, new ReverseMaskingStrategy());
            Assert.AreEqual(masked1, "!dlrow ,olleH");
        }

        [TestMethod]
        public void TestMaskIntReverse()
        {
            int input = 123456789;
            object masked1 = Masker.Mask(input, new ReverseMaskingStrategy());
            Assert.AreEqual(masked1, 987654321);
        }

        [TestMethod]
        public void TestMaskDateTimeReverse()
        {
            DateTime input = new DateTime(1999, 12, 31);
            object masked1 = Masker.Mask(input, new ReverseMaskingStrategy());
            object masked2 = new DateTime(2113, 1, 1);
            Assert.AreEqual(masked1, masked2);
        }

        [TestMethod]
        public void TestMaskArrayReverse()
        {
            object[] input = { 123456789, "Hello, world!", new DateTime(1999, 12, 31) };
            object[] masked1 = Masker.Mask(input, new ReverseMaskingStrategy());
            object[] masked2 = { 987654321, "!dlrow ,olleH", new DateTime(2113, 1, 1) };
            Assert.AreEqual(masked1[0], masked2[0]);
            Assert.AreEqual(masked1[1], masked2[1]);
            Assert.AreEqual(masked1[2], masked2[2]);
        }

    }
}
