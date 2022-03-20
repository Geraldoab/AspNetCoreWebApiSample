using System.Collections.Generic;
using Project.Domain.Model;

namespace Project.Tests
{
    public class BaseEmployeeTest
    {
        protected Employee Employee = new Employee()
        {
            Id = 1,
            Name = "Geraldo"
        };

        protected List<Employee> List = new List<Employee>()
        {
            new Employee ()
            {
                Id = 1,
                Name = "Geraldo"
            }
        };

        protected List<Employee> ExpectedEmployeeList = new List<Employee>()
        {
            new Employee ()
            {
                Id = 1,
                Name = "Geraldo"
            }
        };
    }
}