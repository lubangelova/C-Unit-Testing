using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class School
    {
        private string name;
        private IList<Course> courses;
        public School(string name, IList<Course> courses)
        {
            this.Courses = courses;
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name can not be empty");
                }
                this.name = value;
            }
        }
        public IList<Course> Courses
        {
            get
            {
                return this.courses;
            }
            set
            {
                this.courses = value;
            }
        }


        public void AddCourseToShool(Course course)
        {
            this.Courses.Add(course);
        }
        public void RemoveCourseFromShool(Course course)
        {
            if(this.Courses.Count==0)
            {
                throw new IndexOutOfRangeException("There is no courses!");
            }
            if (this.Courses.IndexOf(course)==-1)
            {
                throw new ArgumentException("There is no such course!");
            }
            this.Courses.Remove(course);
        }

    }
}
