using Castle.Core.Logging;
using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using PackageManager.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models.ProjectTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void Constructor_SetPackageRepositoryCorrectlyForOptionalParameters()
        {

            var packagesMock = new Mock<IRepository<IPackage>>();
            var project = new Project("AnyProject","Sofia", packagesMock.Object );

            Assert.AreEqual(packagesMock.Object, project.PackageRepository);
        }

        //[Test]
        //public void Constructor_SetPackageRepositoryCorrectlyForPassedParameters()
        //{

         
        //    var project = new Project("AnyProject", "Sofia");

        //    Assert.AreEqual(new PackageRepository(new ConsoleLogger()), project.PackageRepository);
        //}
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenNullNamePassed()
        {

            Assert.Throws<ArgumentNullException>(() => new Project(null, "Sofia"));
        }
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenNullLocationPassed()
        {

            Assert.Throws<ArgumentNullException>(() => new Project("AnyProject", null));
        }
    }
}
