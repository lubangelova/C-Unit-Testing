using Moq;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models.PackageTests
{
    [TestFixture]
    public class EqualsTests
    {
        [Test]
        public void Equals_ShouldThrowArgumentNullException_WhenNullObjPassed()
        {
            var versionMock = new Mock<IVersion>();
            var package = new Package("AnyPackage", versionMock.Object);

            Assert.Throws<ArgumentNullException>(() => package.Equals(null));
       
        }
        [Test]
        public void Equals_ShouldThrowArgumentException_WhenObjIsNotIPackage()
        {
            var versionMock = new Mock<IVersion>();
            var package = new Package("AnyPackage", versionMock.Object);
            object obj = new Object();

            Assert.Throws<ArgumentException>(() => package.Equals(obj));

        }

        [Test]
        public void Equals_ShouldReturnTrue_WhenAreEqual()
        {
            var versionMock = new Mock<IVersion>();
            var package = new Package("AnyPackage", versionMock.Object);
            var objMock = new Mock<IPackage>();

           
            versionMock.Setup(x => x.Major).Returns(10);
            versionMock.Setup(x => x.Minor).Returns(10);
            versionMock.Setup(x => x.Patch).Returns(10);
            versionMock.Setup(x => x.VersionType).Returns(VersionType.beta);

            objMock.Setup(x => x.Name).Returns("AnyPackage");
            objMock.Setup(x => x.Version.Major).Returns(10);
            objMock.Setup(x => x.Version.Minor).Returns(10);
            objMock.Setup(x => x.Version.Patch).Returns(10);
            objMock.Setup(x => x.Version.VersionType).Returns(VersionType.beta);

            var expected = true;
            var actual=package.Equals(objMock.Object);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Equals_ShouldReturnFalse_WhenNotEqual()
        {
            var versionMock = new Mock<IVersion>();
            var package = new Package("AnyPackage", versionMock.Object);
            var objMock = new Mock<IPackage>();


            versionMock.Setup(x => x.Major).Returns(10);
            versionMock.Setup(x => x.Minor).Returns(10);
            versionMock.Setup(x => x.Patch).Returns(10);
            versionMock.Setup(x => x.VersionType).Returns(VersionType.beta);

            objMock.Setup(x => x.Name).Returns("AnyOtherPackage");
            objMock.Setup(x => x.Version.Major).Returns(1);
            objMock.Setup(x => x.Version.Minor).Returns(10);
            objMock.Setup(x => x.Version.Patch).Returns(10);
            objMock.Setup(x => x.Version.VersionType).Returns(VersionType.alpha);

            var expected = false;
            var actual = package.Equals(objMock.Object);

            Assert.AreEqual(expected, actual);
        }
    }
}
