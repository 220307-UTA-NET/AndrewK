using System;
using System.Text;

namespace School.Logic
{
    public class Student
    {
        // Fields
        int ID;
        string name;
        //List<course>

        // Constructors
        public Student() { }
        public Student(int ID, string name)
        {
            this.ID = ID;
            this.name = name;
        }

        // Methods
        public int GetID()
        { return this.ID; }
        public string GetName()
        { return this.name; }
        public void SetName(string name)
        { this.name = name; }
        public string Introduce()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Hello, my name is {this.name}, and I am teacher {this.ID}");
            return sb.ToString();
        }
    }
}