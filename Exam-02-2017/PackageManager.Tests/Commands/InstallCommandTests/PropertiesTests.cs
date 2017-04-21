using Moq;
using NUnit.Framework;
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
    public class PropertiesTests
    {
        [Test]
        public void Should_SetCorrectValueToOperation_WhenValidValuesPassed()
        {
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();

            var command = new MockedInstallCommand(installerMock.Object, packageMock.Object);

            var expected = InstallerOperation.Install;
            var actual = command.Installer.Operation;

            Assert.AreEqual(expected, actual);

        }
    }
}
