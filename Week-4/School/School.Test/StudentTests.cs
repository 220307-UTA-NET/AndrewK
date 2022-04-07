using School.Logic;
using School.DataInfrastructure;
using Moq;
using Xunit;
using System.Collections.Generic;
using System.Collections;

namespace School.Test
{
    public class StudentTests
    {
        [Fact]
        public void Student_CreateStudentObject_ValidStudent()
        {
            // Arrange
            //Student expected = new Student(01, "Kevin");
            Student test = new Student(01, "Kevin");

            // Act
            //Student actual = new Student(01, "Kevin");
            string actual = test.GetName();

            // Assert
            string expected = "Kevin";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void School_GetStudent_ValidStudent()
        {
            // The test that I'm writing should NOT involve callinf the SqlRepository class.
            // A unit test should DEFINITELY not involde the database, and above all,
            // it should not involve the PRODUCTION database!

            // DON'T DO THIS!!!
            //IRepository repo = new SqlRepository(connectionString);



            // Arrange
            Mock<IRepository> mockRepo = new();

            // Lambda expression syntax: like an anonymous classless method (delegate)
            // The Mock class sets up its inner object using these method calls (Setup, Returns) **Reflection
            mockRepo.Setup(x => x.GetStudentName(3)).Returns("Kelly");
            var school = new App.School(mockRepo.Object);


            // Act
            Student test = school.GetStudent(3);
            string actual = test.GetName();

            // Assert
            string expected = "Kelly";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void School_IntroduceAllTeachers_FromattedString()
        {
            // Arrange
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.GetAllTeachers()).Returns(System.Array.Empty<Teacher>());
            var school = new App.School(mockRepo.Object);

            // Act
            string actual = school.IntroduceAllTeachers();

            // Assert
            string expected = "******** Introducing the Teachers of the School ********\n\r\n";
            Assert.Equal(expected, actual);

        }










    }
}