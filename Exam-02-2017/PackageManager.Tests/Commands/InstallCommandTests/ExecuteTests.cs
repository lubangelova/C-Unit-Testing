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
    public class ExecuteTests
    {
        [Test]
        public void Execute_ShouldCallPerformOperation_WhenValidValuesPassed()
        {

            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();

            installerMock.Setup(x => x.PerformOperation(packageMock.Object)).Verifiable();

            var command = new MockedInstallCommand(installerMock.Object, packageMock.Object);

            command.Execute();

            installerMock.Verify(x => x.PerformOperation(packageMock.Object), Times.Once);
        }
    }
}
