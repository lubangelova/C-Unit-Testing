using Moq;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Repositories
{
    [TestFixture]
    public class DeleteTests
    {
        [Test]
        public void Delete_ShouldThrowArgumentNullException_WhenNullPackagePassed()
        {
            var loggerMock = new Mock<ILogger>();
            var repository = new PackageRepository(loggerMock.Object);

            Assert.Throws<ArgumentNullException>(() => repository.Delete(null));
        }


        [Test]
        public void Delete_ShouldThrowArgumentNullException_WhenPackedNotExist()
        {
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            var packages = new List<IPackage>() { packageMock.Object };
            var repository = new PackageRepository(loggerMock.Object, packages);
            var packageToDeleteMock = new Mock<IPackage>();

            packageMock.Setup(x => x.Name).Returns("ValidPackage");
            packageMock.Setup(x => x.Version.Major).Returns(10);
            packageMock.Setup(x => x.Version.Minor).Returns(10);
            packageMock.Setup(x => x.Version.Patch).Returns(10);
            packageMock.Setup(x => x.Version.VersionType).Returns(VersionType.alpha);
            loggerMock.Setup(x => x.Log(It.IsAny<string>()));

            packageToDeleteMock.Setup(x => x.Name).Returns("AnyOtherPackage");
            packageToDeleteMock.Setup(x => x.Version.Major).Returns(10);
            packageToDeleteMock.Setup(x => x.Version.Minor).Returns(10);
            packageToDeleteMock.Setup(x => x.Version.Patch).Returns(10);
            packageToDeleteMock.Setup(x => x.Version.VersionType).Returns(VersionType.alpha);


            Assert.Throws<ArgumentNullException>(() => repository.Delete(packageToDeleteMock.Object));

        }
    }
}
