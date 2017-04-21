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

namespace PackageManager.Tests.Repositories.PackageRepositoryTests
{
    [TestFixture]
    public class AddTests
    {
        [Test]
        public void Add_ShouldThrowArgumentNullException_WhenNullPackagePassed()
        {
            var loggerMock = new Mock<ILogger>();
            var repository = new PackageRepository(loggerMock.Object);

            Assert.Throws<ArgumentNullException>(()=> repository.Add(null));
        }

        [Test]
        public void Add_ShouldLogMessage1Time_WhenValidPackagePassed()
        {
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            var packages = new List<IPackage>() { packageMock.Object };
            var repository = new PackageRepository(loggerMock.Object, packages);
            var packageToAddMock = new Mock<IPackage>();

            packageMock.Setup(x => x.Name).Returns("ValidPackage");
            loggerMock.Setup(x => x.Log(It.IsAny<string>()));
            packageToAddMock.Setup(x => x.Name).Returns("AnyOtherPackage");

            repository.Add(packageToAddMock.Object);

            loggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Once);

        }

        [Test]
        public void Add_ShouldLogMessage3Times_WhenPackageIsAlreadyInstalled()
        {
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            var packages = new List<IPackage>() { packageMock.Object };
            var repository = new PackageRepository(loggerMock.Object, packages);
            var packageToAddMock = new Mock<IPackage>();

            packageMock.Setup(x => x.Name).Returns("ValidPackage");
            packageMock.Setup(x => x.Version.Minor).Returns(1);
            packageMock.Setup(x => x.Version.Major).Returns(1);
            packageMock.Setup(x => x.Version.Patch).Returns(1);
            packageMock.Setup(x => x.Version.VersionType).Returns(VersionType.alpha);

            loggerMock.Setup(x => x.Log(It.IsAny<string>()));

            packageToAddMock.Setup(x => x.Name).Returns("ValidPackage");
            packageToAddMock.Setup(x => x.Version.Minor).Returns(1);
            packageToAddMock.Setup(x => x.Version.Major).Returns(1);
            packageToAddMock.Setup(x => x.Version.Patch).Returns(1);
            packageToAddMock.Setup(x => x.Version.VersionType).Returns(VersionType.alpha);

     

            repository.Add(packageToAddMock.Object);

            loggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(3));

        }

        [Test]
        public void Add_ShouldLogMessage2Times_WhenTheIsANewVersion()
        {
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            var packages = new List<IPackage>() { packageMock.Object };
            var repository = new PackageRepository(loggerMock.Object, packages);
            var packageToAddMock = new Mock<IPackage>();

            packageMock.Setup(x => x.Name).Returns("ValidPackage");
            packageMock.Setup(x => x.Version.Minor).Returns(1);
            packageMock.Setup(x => x.Version.Major).Returns(1);
            packageMock.Setup(x => x.Version.Patch).Returns(1);
            packageMock.Setup(x => x.Version.VersionType).Returns(VersionType.alpha);

            loggerMock.Setup(x => x.Log(It.IsAny<string>()));

            packageToAddMock.Setup(x => x.Name).Returns("ValidPackage");
            packageToAddMock.Setup(x => x.Version.Minor).Returns(10);
            packageToAddMock.Setup(x => x.Version.Major).Returns(10);
            packageToAddMock.Setup(x => x.Version.Patch).Returns(10);
            packageToAddMock.Setup(x => x.Version.VersionType).Returns(VersionType.beta);

            repository.Add(packageToAddMock.Object);

            loggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(2));

        }
    }
}
