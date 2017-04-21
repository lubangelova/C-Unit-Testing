using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Student
    {
        private string name;
        private int uniqueNumber;

        public Student(string name, int uniqueNumber)
        {
            this.Name = name;
            this.UniqueNumber = uniqueNumber;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name can not be empty!");
                }
                this.name = value;
            }
        }
        public int UniqueNumber
        {
            get
            {
                return this.uniqueNumber;
            }
            set
            {
                if (value< 10000 || value> 99999)
                {
                    throw new IndexOutOfRangeException("The unique number must be between 10000 and 99999!");
                }
                    this.uniqueNumber = value;
            }
        }

       
    }
}
