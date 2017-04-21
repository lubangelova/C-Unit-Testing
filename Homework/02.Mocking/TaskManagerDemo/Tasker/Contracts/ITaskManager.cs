using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker.Contracts
{
    public interface ITaskManager
    {
        void Add(ITask task);
        void Remove(int id);
    }
}
