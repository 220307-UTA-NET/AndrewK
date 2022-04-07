using School.DataInfrastructure;
using School.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.App
{
    internal class School
    {
        // Fields
        IRepository repo;

        // Constructors
        public School(IRepository repo)
        {
            this.repo = repo;
        }

        // Methods
        public Student GetStudent(int ID, IRepository repo)
        {
            return new Student(ID, this.repo.GetStudentName(ID));
        }

        public string IntroduceAllTeachers()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("******** Introducing the Teachers of the School ********");
            IEnumerable<Teacher> teachers = repo.GetAllTeachers();
            foreach (Teacher teacher in teachers)
            {
                sb.AppendLine(teachers.Introduce());
            }
            return sb.ToString();
        }




    }
}
