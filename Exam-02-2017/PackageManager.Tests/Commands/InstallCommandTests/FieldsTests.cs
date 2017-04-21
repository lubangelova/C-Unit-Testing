using Moq;
using NUnit.Framework;
using PackageManager.Core.Contracts;
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
    public class FieldsTests
    {
        [Test]
        public void Should_CorrectlySetInstaller_WhenValidValuePassed()
        {
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();

            var command = new MockedInstallCommand(installerMock.Object, packageMock.Object);

            Assert.AreEqual(installerMock.Object, command.Installer);
        }
        [Test]
        public void Should_CorrectlySetPackage_WhenValidValuePassed()
        {
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();

            var command = new MockedInstallCommand(installerMock.Object, packageMock.Object);

            Assert.AreEqual(packageMock.Object, command.Package);
        }
    }
}
