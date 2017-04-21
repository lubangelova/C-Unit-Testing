using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Contracts;
using Tasker.Models;

namespace Tasker.Tests.Fakes
{
    internal class TaskManagerFake : TaskManager
    {
        public TaskManagerFake(IIdProvider idProvider, ILogger logger) : base(idProvider, logger)
        {
        }
        public ICollection<ITask> ExposedTasks
        {
            get
            {
                return base.Tasks;
            }
        }
    }
}
