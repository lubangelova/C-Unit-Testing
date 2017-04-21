using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Contracts;

namespace Tasker.Models
{
    public class IdProvider:IIdProvider
    {
        private static int currentId = 0;
        public int NextId()
        {
            return currentId++;
        }
    }
}
