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
    public class CompareToTests
    {
        [Test]
        public void CompareTo_ShouldThrowArgumentNullException_WhenNullOtherPassed()
        {
            var versionMock = new Mock<IVersion>();
            var package = new Package("AnyPackage", versionMock.Object);

            Assert.Throws<ArgumentNullException>(() => package.CompareTo(null));
        }

        [Test]
        public void CompareTo_ShouldNotThrow_WhenValidOtherPassed()
        {
            var versionMock = new Mock<IVersion>();
            var package = new Package("AnyPackage", versionMock.Object);
            var otherMock = new Mock<IPackage>();
            var versionOtherMock = new Mock<IVersion>();
            otherMock.Setup(x => x.Name).Returns("AnyPackage");
            otherMock.Setup(x => x.Version).Returns(versionOtherMock.Object);


            Assert.DoesNotThrow(() => package.CompareTo(otherMock.Object));
        }
        [Test]
        public void CompareTo_ShouldThrowArgumentException_WhenOtherNameIsDifferentThanPackageName()
        {
            var versionMock = new Mock<IVersion>();
            var package = new Package("AnyPackage", versionMock.Object);
            var otherMock = new Mock<IPackage>();
            otherMock.Setup(x => x.Name).Returns("OtherName");

            Assert.Throws<ArgumentException>(() => package.CompareTo(otherMock.Object));
        }

        [Test]
        public void CompareTo_ShouldReturn1_WhenThisVersionIsHighestThanOther()
        {
            var versionMock = new Mock<IVersion>();
            var package = new Package("AnyPackage", versionMock.Object);
            var otherMock = new Mock<IPackage>();
            var versionOtherMock = new Mock<IVersion>();

            versionMock.Setup(x => x.Major).Returns(10);
            versionMock.Setup(x => x.Minor).Returns(10);
            versionMock.Setup(x => x.Patch).Returns(10);
            versionMock.Setup(x => x.VersionType).Returns(VersionType.beta);

            otherMock.Setup(x => x.Name).Returns("AnyPackage");
            otherMock.Setup(x => x.Version).Returns(versionOtherMock.Object);

            versionOtherMock.Setup(x => x.Major).Returns(1);
            versionOtherMock.Setup(x => x.Minor).Returns(1);
            versionOtherMock.Setup(x => x.Patch).Returns(1);
            versionOtherMock.Setup(x => x.VersionType).Returns(VersionType.alpha);

            var expected = 1;
            var actual = package.CompareTo(otherMock.Object);
            Assert.AreEqual(expected,actual);
        }
        [Test]
        public void CompareTo_ShouldReturnMinus1_WhenThisVersionIsLowestThanOther()
        {
            var versionMock = new Mock<IVersion>();
            var package = new Package("AnyPackage", versionMock.Object);
            var otherMock = new Mock<IPackage>();
            var versionOtherMock = new Mock<IVersion>();

            versionMock.Setup(x => x.Major).Returns(1);
            versionMock.Setup(x => x.Minor).Returns(1);
            versionMock.Setup(x => x.Patch).Returns(1);
            versionMock.Setup(x => x.VersionType).Returns(VersionType.alpha);

            otherMock.Setup(x => x.Name).Returns("AnyPackage");
            otherMock.Setup(x => x.Version).Returns(versionOtherMock.Object);

            versionOtherMock.Setup(x => x.Major).Returns(10);
            versionOtherMock.Setup(x => x.Minor).Returns(10);
            versionOtherMock.Setup(x => x.Patch).Returns(10);
            versionOtherMock.Setup(x => x.VersionType).Returns(VersionType.beta);

            var expected = -1;
            var actual = package.CompareTo(otherMock.Object);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CompareTo_ShouldReturn0_WhenThisVersionIsEqualOther()
        {
            var versionMock = new Mock<IVersion>();
            var package = new Package("AnyPackage", versionMock.Object);
            var otherMock = new Mock<IPackage>();
            var versionOtherMock = new Mock<IVersion>();

            versionMock.Setup(x => x.Major).Returns(10);
            versionMock.Setup(x => x.Minor).Returns(10);
            versionMock.Setup(x => x.Patch).Returns(10);
            versionMock.Setup(x => x.VersionType).Returns(VersionType.alpha);

            otherMock.Setup(x => x.Name).Returns("AnyPackage");
            otherMock.Setup(x => x.Version).Returns(versionOtherMock.Object);

            versionOtherMock.Setup(x => x.Major).Returns(10);
            versionOtherMock.Setup(x => x.Minor).Returns(10);
            versionOtherMock.Setup(x => x.Patch).Returns(10);
            versionOtherMock.Setup(x => x.VersionType).Returns(VersionType.alpha);

            var expected = 0;
            var actual = package.CompareTo(otherMock.Object);
            Assert.AreEqual(expected, actual);
        }
    }
}
