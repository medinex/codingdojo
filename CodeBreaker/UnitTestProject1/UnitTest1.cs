using System;
using CodeBreaker;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow("hello world", "&£aad ldga(")]
        [DataRow("super lopes", "hje£g ade£h")]
        [DataRow("nexus ag", "c£mjh !%")]
        public void TestDecryption(string message, string encrypt)
        {
            // a b c d e f g h i j k l m n o p q r s t u v w x y z
            // ! ) " ( £ * % & > < @ a b c d e f g h i j k l m n o

            var encryptedMEssage = Enigma.Decrypt(encrypt);

            Assert.AreEqual(  message , encryptedMEssage);



        }
    }
}
