using NUnit.Framework;
using System;
using Tasker.Models;

namespace Tasker.Tests
{
    [TestFixture]
    public class TaskTests
    {
        [Test]
        public void Description_EmptyValue_ShouldThrowException()
        {
            var task = new Task("Task1");
            Assert.Throws<ArgumentNullException>(() => task.Description = string.Empty);
        }
    }
}
