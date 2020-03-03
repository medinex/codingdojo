using ExcuseGenerator;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace ExcuseGeneratorTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FilesDoNotExistTest()
        {
            const string notExistingFile = @"C:\FileNotExist.txt";
            const string existingFile = @"C:\Users\Mateusz.Musial\Desktop\firstTable.txt";

            Assert.Throws<FileNotFoundException>(() => new ExcuseGeneratorModel(notExistingFile, notExistingFile, notExistingFile));
            Assert.Throws<FileNotFoundException>(() => new ExcuseGeneratorModel(existingFile, notExistingFile, notExistingFile));
            Assert.Throws<FileNotFoundException>(() => new ExcuseGeneratorModel(existingFile, existingFile, notExistingFile));

        }

        [Test]
        public void EmptyFileTest()
        {
        }

        [Test]
        public void GenerateTest()
        {
        }

    }
}