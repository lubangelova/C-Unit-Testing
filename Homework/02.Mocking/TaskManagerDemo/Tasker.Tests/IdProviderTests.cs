using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Models;

namespace Tasker.Tests
{
    [TestFixture]
    public class IdProviderTests
    {
        [Test]
        public void NextID_ShouldReturnIncrementID()
        {
            var idProvider = new IdProvider();
            var id1=idProvider.NextId();
            var id2 = idProvider.NextId();
            Assert.AreEqual(0, id1);
            Assert.AreEqual(1, id2);
            
        }
    }
}
