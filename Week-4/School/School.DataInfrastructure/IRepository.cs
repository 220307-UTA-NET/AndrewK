using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Logic;

namespace School.DataInfrastructure
{
    // Repository design pattern: implement basic CRUD operations
    // CRUD - Create, Read, Update, Delete
    // Operations that the rest of app may need, but we can abstract the implementation detail
    // Advantage: It makes the rest of the program more unit-testable

    // Often repositories don't "save" immediately, instead using a special save method
    // to wrap all the changes into one transaction.

    // Sometimes one repository per "entity", per type of things we want to track in the DB
    // Transactions across multiple repositories/entities requires the "unit of work" design pattern
    // Which manages multiple repositories, and saves the changes of all of them at once.

    public interface IRepository
    {
        // An interface is a contrac, that defines a set of conditions.
        // It can contain methods, properties, or events
        // But is does not fully deine them, only provides the signature
        // Access-Modifier Return-Type Method-Name (Parameter types/names)

        // In C#, we can use multiple Interfaces to simulate multiple-inheritance

        IEnumerable<Teacher> GetAllTeachers();
        Teacher CreateNewTeacher(string name);
        string GetStudentName(int studentId);
    
    }
}
