using System;
namespace microservicedotnet6.Models
{
    public class Employee
    {
        public string EmployeeId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Citizenship { get; set; } = string.Empty;
    }

    //public class EmployeeCollection
    //   {
    //	public List<Employee> Employees { get; set; }
    //	public List<Employee> GetEmployees()
    //       {
    //		return new List<Employee>()
    //		{
    //			new Employee()
    //			{
    //				Name = "Robinson",
    //				Citizenship = "Brazil",
    //				EmployeeId = "1"
    //			},
    //			new Employee()
    //			{
    //				Name = "Edilcirene",
    //				Citizenship = "Brazil",
    //				EmployeeId = "2"
    //			}
    //		};
    //       }
    //   }
}

