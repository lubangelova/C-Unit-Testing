using System;
using NUnit.Framework;

namespace School.Tests
{
    [TestFixture]
    public class School_Tests
    {
        [Test]
        public void Student_TestConstructorAndProperties()
        {
            var name = "Ivan";
            var uniqueNumber = 12345;
            var student = new Student(name, uniqueNumber);
            var expectedName = "Ivan";
            var expectedUniqueNumber = 12345;
            Assert.AreEqual(expectedName, student.Name);
            Assert.AreEqual(expectedUniqueNumber, student.UniqueNumber);
        }
        [Test]
        public void Student_NameCanNotBeEmpty_ShouldThrowException()
        {
            var name = "Ivan";
            var uniqueNumber = 12345;
            var student = new Student(name, uniqueNumber);
            Assert.Throws<ArgumentException>(() => student.Name = string.Empty);

        }
        [Test]
        public void Student_UniqueNumberInRangeLargeThan10000_ShouldThrowException()
        {
            var name = "Ivan";
            var uniqueNumber = 12345;
            var student = new Student(name, uniqueNumber);
            Assert.Throws<IndexOutOfRangeException>(() => student.UniqueNumber = 9000);
        }
        [Test]
        public void Student_UniqueNumberInRangeSmallThan99999_ShouldThrowException()
        {
            var name = "Ivan";
            var uniqueNumber = 12345;
            var student = new Student(name, uniqueNumber);
            Assert.Throws<IndexOutOfRangeException>(() => student.UniqueNumber = 100000);
        }
 
       
    }
}
