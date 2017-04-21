using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Models;

namespace Tasker.Tests.Models
{
    [TestFixture]
    public class ConsoleLoggerTests
    {
        [Test]
        public void Log_ShouldLogMessage_WhenInvoked()
        {
            var logger = new ConsoleLogger();
            var message = "Pesho";
            

            var outputStream = new StringWriter();
            var defaultStream = Console.Out;
            Console.SetOut(outputStream);

            logger.Log(message);

            Assert.AreEqual(message+Environment.NewLine, outputStream.ToString());
            Console.SetOut(defaultStream);
        }
    }
}
