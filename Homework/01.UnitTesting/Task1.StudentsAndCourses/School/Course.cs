using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Course
    {
        private string name;
        private IList<Student> students;
        public Course(string name, List<Student> students)
        {
            this.Students = students;
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name can not be empty");
                }
                this.name = value;
            }
        }

        public IList<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                if (value.Count>30)
                {
                    throw new IndexOutOfRangeException("Students in a course should be less than 30!");
                }
                this.students = value;
            }
        }

        public void JoinCourse(Student student)
        {
            if (Students.Count>30)
            {
                throw new IndexOutOfRangeException("Students in a course should be less than 30!");
            }
            CheckDuplicateUniqueNumber(student);
            Students.Add(student);
        }

        public void LeaveCourse(Student student)
        {
            if (Students.Count == 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (Students.IndexOf(student)==-1)
            {
                throw new ArgumentException("Can't find this student!");
            }
            Students.Remove(student);
        }

        public void CheckDuplicateUniqueNumber(Student student)
        {
            if (this.Students.Any(s => s.UniqueNumber == student.UniqueNumber))
            {
                throw new InvalidOperationException();
            }
        }
    }
}
