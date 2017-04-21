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
    public class ConstructorTests
    {
        [Test]
        public void Constructor_SetMajor_whenValidValuePassed()
        {
            var major = 5;
            var minor = 1;
            var patch = 2;
            var versionType = VersionType.alpha;
            var packageVersion = new PackageVersion(major,minor,patch,versionType);

            Assert.AreEqual(major, packageVersion.Major);

        }

        [Test]
        public void Constructor_SetMinor_whenValidValuePassed()
        {
            var major = 5;
            var minor = 1;
            var patch = 2;
            var versionType = VersionType.alpha;
            var packageVersion = new PackageVersion(major, minor, patch, versionType);

            Assert.AreEqual(minor, packageVersion.Minor);

        }
        [Test]
        public void Constructor_SetPatch_whenValidValuePassed()
        {
            var major = 5;
            var minor = 1;
            var patch = 2;
            var versionType = VersionType.alpha;
            var packageVersion = new PackageVersion(major, minor, patch, versionType);

            Assert.AreEqual(patch, packageVersion.Patch);

        }
        [Test]
        public void Constructor_SetVersionType_whenValidValuePassed()
        {
            var major = 5;
            var minor = 1;
            var patch = 2;
            var versionType = VersionType.alpha;
            var packageVersion = new PackageVersion(major, minor, patch, versionType);

            Assert.AreEqual(versionType, packageVersion.VersionType);

        }
    }
}
