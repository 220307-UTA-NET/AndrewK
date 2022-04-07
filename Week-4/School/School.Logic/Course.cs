using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Logic
{
    public class Course
    {
        // Fields
        string courseID;
        string courseName;
        int teacherID;
        DateTime startDate;
        DateTime endDate;
        // List<students>

        // Constructors
        public Course() { }
        public Course(string courseID, string courseName, int teacherID, DateTime startDate, DateTime endDate)
        {
            this.courseID = courseID;
            this.courseName = courseName;
            this.teacherID = teacherID;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        // Methods
        public string GetCourseID()
        { return this.courseID; }
        public string GetCourseName()
        { return this.courseName; }
        public int GetTeacherID()
        { return this.teacherID; }
        public DateTime GetStartDate()
        { return this.startDate; }
        public DateTime GetEndDate()
        { return this.endDate; }

        public void SetTeacherID(int teacherID)
        { this.teacherID = teacherID; }
        public void SetStartDate(DateTime startDate)
        { this.startDate = startDate; }
        public void SetEndDate(DateTime endDate)
        { this.endDate = endDate; }
    }
}
