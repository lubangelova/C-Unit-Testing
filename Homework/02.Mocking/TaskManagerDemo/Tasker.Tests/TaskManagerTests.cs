using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using Tasker.Contracts;
using Tasker.Models;
using Tasker.Tests.Fakes;

namespace Tasker.Tests
{
    [TestFixture]
    public class TaskManagerTests
    {
        [Test]
        public void Add_ShouldLogSuccesfulMessage_WhenValidTaskPassed()
        {
            //Arange
            var idProviderMock = new Mock<IIdProvider>();
            var loggerMock = new Mock<ILogger>();
            var taskMock = new Mock<ITask>();
            var taskManager = new TaskManager(idProviderMock.Object, loggerMock.Object);

            //Act
            taskManager.Add(taskMock.Object);

            //Assert
            loggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(1));
        }

        [Test]
        public void Add_ShouldLogSuccesfulMessageTwoTimes_WhenValidTaskPassed()
        {
            //Arange
            var idProviderMock = new Mock<IIdProvider>();
            var loggerMock = new Mock<ILogger>();
            var taskMock1 = new Mock<ITask>();
            var taskMock2 = new Mock<ITask>();
            var taskManager = new TaskManager(idProviderMock.Object, loggerMock.Object);

            //Act
            taskManager.Add(taskMock1.Object);
            taskManager.Add(taskMock2.Object);

            //Assert
            loggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(2));
        }
        [Test]
        public void Add_ShouldCorectlyAssignTaskIds_WhenValidTaskPassed()
        {
            //Arange
            var idProviderMock = new Mock<IIdProvider>();
            var loggerMock = new Mock<ILogger>();
            var taskMock = new Mock<ITask>();

            var taskManager = new TaskManager(idProviderMock.Object, loggerMock.Object);

            idProviderMock.Setup(x => x.NextId()).Returns(0);
            //Act
            taskManager.Add(taskMock.Object);


            //Assert
            taskMock.VerifySet(t => t.Id = 0);
            //Assert.AreEqual(0, taskMock.Object.Id);
        }
        [Test]
        public void Add_ShouldAddCorrectly_WhenValidTaskPassed()
        {
            //Arange
            var idProviderMock = new Mock<IIdProvider>();
            var loggerMock = new Mock<ILogger>();
            var taskMock = new Mock<ITask>();

            var taskManager = new TaskManagerFake(idProviderMock.Object, loggerMock.Object);

           
            //Act
            taskManager.Add(taskMock.Object);


            //Assert
            Assert.That(taskManager.ExposedTasks.Contains(taskMock.Object));
        }
        [Test]
        public void Add_WhenNullTaskAddes_ShouldThrowException()
        {
            //Arange
            var idProviderMock = new Mock<IIdProvider>();
            var loggerMock = new Mock<ILogger>();
            ITask task = null;

            var taskManager = new TaskManager(idProviderMock.Object, loggerMock.Object);

            //Assert
            Assert.Throws<ArgumentNullException>(() => taskManager.Add(task));
        }

        [Test]
        public void Remove_ShouldLogSuccesfulMessage_WhenValidTaskPassed()
        {
            //Arange
            var idProviderMock = new Mock<IIdProvider>();
            var loggerMock = new Mock<ILogger>();
            var taskMock = new Mock<ITask>();
            var taskManager = new TaskManager(idProviderMock.Object, loggerMock.Object);

            taskMock.Setup(x => x.Id).Returns(0);

            //Act
            taskManager.Add(taskMock.Object);
            taskManager.Remove(0);

            //assert
            loggerMock.Verify(x => x.Log(It.Is<string>(m=>m.Contains("was removed"))), Times.Exactly(1));
        }
        [Test]
        public void Remove_ShouldRemoveTaskSucsesfuly()
        {
            //Arange
            var idProviderMock = new Mock<IIdProvider>();
            var loggerMock = new Mock<ILogger>();
            var taskMock = new Mock<ITask>();
            var taskManager = new TaskManagerFake(idProviderMock.Object, loggerMock.Object);
            //var tasks = new List<Models.Task>();

            taskMock.Setup(x => x.Id).Returns(0);

            //Act
            taskManager.Add(taskMock.Object);
            taskManager.Remove(0);

            //assert
            Assert.AreEqual(0,taskManager.ExposedTasks.Count);
        }

        [Test]
        public void Remove_WhenNullTaskIsRemoved_ShouldLogMessage()
        {
            //Arange
            var idProviderMock = new Mock<IIdProvider>();
            var loggerMock = new Mock<ILogger>();
            var taskMock = new Mock<ITask>();
            var taskManager = new TaskManager(idProviderMock.Object, loggerMock.Object);

            taskMock.Setup(x => x.Id).Returns(0);

            //Act
            taskManager.Add(taskMock.Object);
            taskManager.Remove(1);

            //assert
            loggerMock.Verify(x => x.Log(It.Is<string>(m=>m.Contains("was not found"))), Times.Exactly(1));
        }
    }
}
