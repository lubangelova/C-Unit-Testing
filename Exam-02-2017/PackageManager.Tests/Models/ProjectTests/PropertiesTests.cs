using NUnit.Framework;
using PackageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models.ProjectTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [Test]
        public void Should_SetName_WhenValidValuePassed()
        {


            var project = new Project("AnyProject", "Sofia");

            Assert.AreEqual("AnyProject", project.Name);
        }
        [Test]
        public void Should_SetLocation_WhenValidValuePassed()
        {


            var project = new Project("AnyProject", "Sofia");

            Assert.AreEqual("Sofia", project.Location);
        }
    }
}
