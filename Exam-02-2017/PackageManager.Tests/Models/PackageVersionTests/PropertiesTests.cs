using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models.PackageVersionTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [Test]
        public void Major_ShouldThrowArgumentException_WhenInvalidValuePassed()
        {
            var major = -1;
            var minor = 1;
            var patch = 2;
            var versionType = VersionType.alpha;

            Assert.Throws<ArgumentException>(() => new PackageVersion(major, minor, patch, versionType));


        }
        [Test]
        public void Major_DoesNotThrows_WhenValidValuePassed()
        {
            var major = 5;
            var minor = 1;
            var patch = 2;
            var versionType = VersionType.alpha;

            Assert.DoesNotThrow(() => new PackageVersion(major, minor, patch, versionType));
        }
        [Test]
        public void Minor_ShouldThrowArgumentException_WhenInvalidValuePassed()
        {
            var major = 5;
            var minor = -1;
            var patch = 2;
            var versionType = VersionType.alpha;

            Assert.Throws<ArgumentException>(() => new PackageVersion(major, minor, patch, versionType));
        }
        [Test]
        public void Minor_DoesNotThrow_WhenValidValuePassed()
        {

            var major = 5;
            var minor = 1;
            var patch = 2;
            var versionType = VersionType.alpha;

            Assert.DoesNotThrow(() => new PackageVersion(major, minor, patch, versionType));
        }
        [Test]
        public void Patch_ShouldThrowArgumentException_WhenInvalidValuePassed()
        {
            var major = 5;
            var minor = 1;
            var patch = -2;
            var versionType = VersionType.alpha;

            Assert.Throws<ArgumentException>(() => new PackageVersion(major, minor, patch, versionType));
        }
        [Test]
        public void Patch_DoesNotThrow_WhenValidValuePassed()
        {

            var major = 5;
            var minor = 1;
            var patch = 2;
            var versionType = VersionType.alpha;

            Assert.DoesNotThrow(() => new PackageVersion(major, minor, patch, versionType));
        }
   
        //TODO VersionType
    }
}
