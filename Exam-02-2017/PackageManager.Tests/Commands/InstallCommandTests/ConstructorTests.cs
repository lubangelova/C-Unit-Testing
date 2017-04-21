using Moq;
using NUnit.Framework;
using PackageManager.Commands;
using PackageManager.Core;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models.Contracts;
using PackageManager.Tests.Commands.InstallCommandTests.Mocked;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Commands.InstallCommandTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenInstallerIsNull()
        { 
            var packageMock = new Mock<IPackage>();

            Assert.Throws<ArgumentNullException>(() => new InstallCommand(null, packageMock.Object));
            
        }
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenPackageIsNull()
        {
            var installerMock = new Mock<IInstaller<IPackage>>();
            installerMock.Setup(x => x.Operation).Returns(InstallerOperation.Install);

            Assert.Throws<ArgumentNullException>(() => new InstallCommand(installerMock.Object, null));

        }
        [Test]
        public void Constructor_ShouldSetCorrectlyInstaller_WhenValidValuePassed()
        {
            var installerMock = new Mock<IInstaller<IPackage>>();
           
            var packageMock = new Mock<IPackage>();

            var command=new MockedInstallCommand(installerMock.Object, packageMock.Object);

            Assert.AreEqual(installerMock.Object, command.Installer);

        }
        [Test]
        public void Constructor_ShouldSetCorrectlyPackage_WhenValidValuePassed()
        {
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();

            var command = new MockedInstallCommand(installerMock.Object, packageMock.Object);

            Assert.AreEqual(packageMock.Object, command.Package);

        }
    }
}
