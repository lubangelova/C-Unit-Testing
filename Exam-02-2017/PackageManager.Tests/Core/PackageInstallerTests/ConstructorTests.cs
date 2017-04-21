using Moq;
using NUnit.Framework;
using PackageManager.Core;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models.Contracts;
using PackageManager.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Core.PackageInstallerTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void Constructor_ShouldRestorePackages_WhenValidValuesPassed()
        {
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();
            var packageInstaller = new PackageInstaller(downloaderMock.Object,projectMock.Object);
            var packageMock = new Mock<IPackage>();
            packageInstaller.Operation= InstallerOperation.Install;

            var dependenciesMock = new Mock<IPackage>();
            var repositoriesMock = new Mock<IRepository<IPackage>>();
            repositoriesMock.Setup(x => x.Add(packageMock.Object));
            packageMock.Setup(x => x.Dependencies).Returns(new List<IPackage>() { dependenciesMock.Object });
            projectMock.Setup(x => x.PackageRepository.Add(packageMock.Object));
            projectMock.Setup(x => x.PackageRepository.GetAll());

            projectMock.Verify(x => x.PackageRepository.Add(packageMock.Object), Times.Once);
        }
    }
}
