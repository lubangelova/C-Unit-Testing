using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Models;

namespace Tasker.Run
{
    public class StartUp
    {
        static void Main()
        {
            var logger = new ConsoleLogger();
            var idProvider = new IdProvider();
            var task1 = new Models.Task("Task1");
            var task2 = new Models.Task("Task2");
            var taskManager = new TaskManager(idProvider, logger);
            taskManager.Add(task1);
            taskManager.Add(task2);
            
        }
    }
}
