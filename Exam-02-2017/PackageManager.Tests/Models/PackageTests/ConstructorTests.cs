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
    public class ConstructorTests
    {
        [Test]
        public void Constructor_SetDependenciesCorrectlyForOptionalParameters()
        {
            var versionMock = new Mock<IVersion>();
            var dependenciesMock = new Mock<ICollection<IPackage>>();
            var package = new Package("AnyPackage",versionMock.Object,dependenciesMock.Object);

            Assert.AreEqual(dependenciesMock.Object, package.Dependencies);
        }
        [Test]
        public void Constructor_SetDependenciesCorrectlyForPassedParameters()
        {
            var versionMock = new Mock<IVersion>();
            ICollection<IPackage> dependencies = new HashSet<IPackage>();
            var package = new Package("AnyPackage", versionMock.Object);

            Assert.AreEqual(dependencies, package.Dependencies);
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenNullNamePassed()
        {
            var versionMock = new Mock<IVersion>();

            Assert.Throws<ArgumentNullException>(() => new Package(null, versionMock.Object));
        }
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenNullVersionPassed()
        {
            Assert.Throws<ArgumentNullException>(() => new Package("AnyPackage",null));
        }
    }
}
