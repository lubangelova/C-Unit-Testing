using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Contracts;

namespace Tasker.Models
{
    public class TaskManager:ITaskManager
    {
       
        private IIdProvider idProvider;
        private ILogger logger;
        public TaskManager(IIdProvider idProvider, ILogger logger)
        {
            this.Tasks = new List<ITask>();
            this.idProvider = idProvider;
            this.logger = logger;
        }
        protected ICollection<ITask> Tasks { get; private set; }
    
        public void Add(ITask task)
        {
            if (task==null)
            {
                throw new ArgumentNullException();
            }
            task.Id = this.idProvider.NextId();
            this.Tasks.Add(task);
            this.logger.Log($"Task with ID {task.Id} was added!");
        }
        public void Remove(int id)
        {
            var task = Tasks.SingleOrDefault(x => x.Id == id);
            if (task==null)
            {
                this.logger.Log($"The task with ID {id} was not found!");
            }
            else
            {
                this.Tasks.Remove(task);
                this.logger.Log($"Task with ID {id} was removed!");
            }
        }


    }
}
