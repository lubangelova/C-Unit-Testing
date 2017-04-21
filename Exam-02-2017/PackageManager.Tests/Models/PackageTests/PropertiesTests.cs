using Moq;
using NUnit.Framework;
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
    public class PropertiesTests
    {
        [Test]
        public void Should_SetNameCorrectly_WhenValidValuePassed()
        {
            var versionMock = new Mock<IVersion>();
            var package = new Package("AnyPackage", versionMock.Object);

            Assert.AreEqual("AnyPackage", package.Name);

        }
        [Test]
        public void Should_SetVersionCorrectly_WhenValidValuePassed()
        {
            var versionMock = new Mock<IVersion>();
            var package = new Package("AnyPackage", versionMock.Object);

            Assert.AreEqual(versionMock.Object, package.Version);

        }
        [Test]
        public void Should_SetUrlCorrectly_WhenValidValuePassed()
        {
            var versionMock = new Mock<IVersion>();
            var package = new Package("AnyPackage", versionMock.Object);
            var expectedUrl= string.Format("{0}.{1}.{2}-{3}", versionMock.Object.Major, versionMock.Object.Minor, versionMock.Object.Patch, versionMock.Object.VersionType);

            Assert.AreEqual(expectedUrl, package.Url);

        }
    }
}
