using SpamLib;
using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpamLib.Tests
{
    [TestClass]
    public class PasswordEncoderTests
    {
        /// <summary>
        /// Выполняется перед всей сессией тестирования
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
             Debug.WriteLine("Инициализация теста");
        }

        /// <summary>
        /// Выполняется перед каждым модульным тестом
        /// </summary>
        /// <param name="context">Контекст с информацией о текущем модульном тесте</param>
        [ClassInitialize]
        public static void TestInitialize(TestContext context)
        {

        }

        [ClassCleanup]
        public static void TestCleanup()
        {

        }

        [TestMethod]
        public void Encode_abc_bcd_key1()
        {
            // A A A
            // arrange
            var str = "abc";
            var expected = "bcd";
            var key = 1;

            //act
            var actual = PasswordEncoder.Encode(str, key);

            // assert 
            Assert.AreEqual(expected, actual);
            //StringAssert.Contains();
            //CollectionAssert.AreEqual();
        }

        [TestMethod]
        public void DecodeTest()
        {
            // A A A
            // arrange
            var str = "bcd";
            var expected = "abc";
            var key = 1;

            //act
            var actual = PasswordEncoder.Decode(str, key);

            // assert 
            Assert.AreEqual(expected, actual);
        }


    }
}
