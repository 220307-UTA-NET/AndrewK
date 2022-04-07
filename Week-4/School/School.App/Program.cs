using System;
using School.Logic;
using School.DataInfrastructure;

namespace School.App
{
    class Program
    {
        static void Main()
        {
            //Console.WriteLine("Hello Again!");

            //Student temp = new Student(123, "Jonathan");
            //Console.WriteLine(temp.Introduce());

            //Teacher temp2 = new Teacher(098, "Brian");
            //Console.WriteLine(temp.Introduce());

            string connectionString = File.ReadAllText(@"//Revature/AndrewK/connectionString.txt");

            IRepository repo = new SqlRepository(connectionString);

            School mySchool = new School(repo);

            Student tempStudent = mySchool.GetStudent(3);

            Console.WriteLine(tempStudent.Introduce());

            Console.WriteLine(mySchool.IntroduceAllTeachers());

            //Teacher newTeacher = repo.CreateNewTeacher("Jerome");
            //Console.WriteLine(newTeacher.Introduce());

            Console.WriteLine(repo.GetStudentName(3));
        }



        
    }
}