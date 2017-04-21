using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker;
using Tasker.Contracts;

namespace Tasker.Models
{
    public class Task : ITask
    {
        private string description;

        public Task(string description)
        {
            this.Description = description;
            
        }
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                this.description = value;
            }
        }
        

        public int Id { get; set; }
        
    }
}
