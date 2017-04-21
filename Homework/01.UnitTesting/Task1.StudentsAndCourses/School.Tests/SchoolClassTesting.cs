using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace School.Tests
{
    [TestFixture]
    public class SchoolClassTesting
    {
        [Test]
        public void School_NameCanNotBeEmpty()
        {
            var courses = new List<Course>();
            var school = new School("88 SU",courses);
            Assert.Throws<ArgumentException>(() => school.Name = string.Empty);
        }
        [Test]
        public void School_AddCourseToShool_AddCorectly()
        {
            var courses = new List<Course>();
            var school = new School("88 SU", courses);
            var students = new List<Student>();
            var course = new Course("Mathematics",students);
            school.AddCourseToShool(course);
            Assert.IsTrue(school.Courses.Contains(course));

        }
        [Test]
        public void School_RemoveCourseFromShool_RemoveCorectly()
        {
            var courses = new List<Course>();
            var school = new School("88 SU", courses);
            var students = new List<Student>();
            var course = new Course("Mathematics", students);
            courses.Add(course);
            school.RemoveCourseFromShool(course);
            Assert.IsTrue(!school.Courses.Contains(course));

        }
        [Test]
        public void School_RemoveCourseFromShoolFromEmptyCollection_ShouldThrowException()
        {
            var courses = new List<Course>();
            var school = new School("88 SU", courses);
            var students = new List<Student>();
            var course = new Course("Mathematics", students);
            Assert.Throws<IndexOutOfRangeException>(() => school.RemoveCourseFromShool(course));

        }
        [Test]
        public void School_RemoveCourseFromShoolWhenCourseISNotRecorded_ShouldThrowException()
        {
            var courses = new List<Course>();
            var school = new School("88 SU", courses);
            var students = new List<Student>();
            var math = new Course("Mathematics", students);
            var bio = new Course("Biologic", students);
            courses.Add(math);
            Assert.Throws<ArgumentException>(() => school.RemoveCourseFromShool(bio));

        }

    }
}
