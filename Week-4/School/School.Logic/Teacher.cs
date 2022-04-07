using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Logic
{
    public class Teacher
    {
        // Fields
        int employeeID;
        string name;

        // Constructors
        public Teacher() { }
        public Teacher(int ID, string name)
        { 
            this.employeeID = ID;
            this.name = name;
        }

        // Methods
        public int GetEmployeeID()
            { return this.employeeID; }
        public string GetName()
        { return this.name; }
        public void SetName(string name)
        { this.name = name; }

        public string Introduce()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Hello, my name is {this.name}, and I am teacher {this.employeeID}");
            return sb.ToString();
        }

    }
}
