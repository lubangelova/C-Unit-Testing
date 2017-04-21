using NUnit.Framework;
using System;

using System.Collections.Generic;

namespace School.Tests
{
    [TestFixture]
    public class CourseClassTesting
    {
        [Test]
        public void Course_NameCanNotBeEmpty()
        {
            var students = new List<Student>();
            var course = new Course("Mathematics", students);
            Assert.Throws<ArgumentException>(() => course.Name = string.Empty);
        }

        [Test]
        public void Course_JoinCourse_AddCorectly()
        {
            var students = new List<Student>();
            var course = new Course("Mathematics", students);
            var student = new Student("Ivan", 12345);
            course.JoinCourse(student);
            Assert.IsTrue(course.Students.Contains(student));

        }
        [Test]
        public void Course_JoinCourseMoreThan30Students_ShouldThrowException()
        {
            var students = new List<Student>();
            var course = new Course("Mathematics", students);
            var goshoStudent = new Student("Gosho", 12345);
            for (int i = 0; i <=30; i++)
            {
                var student = new Student("Ivan", 10000+i);
                course.JoinCourse(student);
            }
            Assert.Throws<IndexOutOfRangeException>(() => course.JoinCourse(goshoStudent));
        }
        [Test]
        public void Course_JoinCourseStudentsWithSameUniqueNumber_ShouldThrowException()
        {
            var students = new List<Student>();
            var goshoStudent = new Student("Gosho", 12345);
            var peshoStudent = new Student("Pesho", 12345);
            var course = new Course("Math", students);
            course.JoinCourse(peshoStudent);
            Assert.Throws<InvalidOperationException>(() => course.JoinCourse(goshoStudent));
        }
        [Test]
        public void Course_LeaveCourse_RemoveCorectly()
        {
            var students = new List<Student>();
            var student = new Student("Ivan", 12345);
            students.Add(student);
            var course = new Course("Mathematics", students);
            course.LeaveCourse(student);
            Assert.IsTrue(!course.Students.Contains(student));

        }
        [Test]
        public void Course_LeaveCourseWhenStudentIsNotRecorded_ShouldThrowException()
        {
            var students = new List<Student>();
            var course = new Course("Mathematics", students);
            var ivanStudent = new Student("Ivan", 12345);
            var goshoStudent = new Student("Gosho", 12356);
            students.Add(ivanStudent);
            Assert.Throws<ArgumentException>(() => course.LeaveCourse(goshoStudent));

        }
        [Test]
        public void Course_LeaveCourseFromEmptyCollection_ShouldThrowException()
        {
            var students = new List<Student>();
            var course = new Course("Mathematics", students);
            var ivanStudent = new Student("Ivan", 12345);
            Assert.Throws<IndexOutOfRangeException>(() => course.LeaveCourse(ivanStudent));

        }
       
    }
}
