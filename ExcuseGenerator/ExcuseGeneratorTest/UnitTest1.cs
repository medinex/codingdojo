using ExcuseGenerator;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace ExcuseGeneratorTest
{
    public class Tests
    {
        private const string notExistingFile = @"C:\FileNotExist.txt";
        private const string file1 = @"C:\Users\Mateusz.Musial\Desktop\firstTable.txt";
        private const string file2 = @"C:\Users\Mateusz.Musial\Desktop\secondTable.txt";
        private const string file3 = @"C:\Users\Mateusz.Musial\Desktop\thirdTable.txt";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FilesDoNotExistTest()
        {
            

            //Assert.Throws<FileNotFoundException>(() => new ExcuseGeneratorModel(notExistingFile, notExistingFile, notExistingFile));
            //Assert.Throws<FileNotFoundException>(() => new ExcuseGeneratorModel(file1, notExistingFile, notExistingFile));
            //Assert.Throws<FileNotFoundException>(() => new ExcuseGeneratorModel(file1, file1, notExistingFile));
        }

        [Test]
        public void EmptyFileTest()
        {
        }

        [Test]
        public void GenerateTest()
        {
            var moq = new Mock<IDataService>();
            var moqRandom = new Mock<IRandomNumberProvider>();
            var generator = new ExcuseGeneratorModel(moq.Object);
            var result = generator.GenerateExcuse();
            Assert.That(true);
            Assert.IsNotEmpty(result);
        }

    }
}