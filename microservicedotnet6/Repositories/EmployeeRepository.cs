using System;
using microservicedotnet6.Data;
using microservicedotnet6.Models;

namespace microservicedotnet6.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _db;

        public EmployeeRepository(EmployeeDbContext db)
        {
            _db = db;
        }

        public List<Employee> GetEmployees() => _db.Employee.ToList();

        public Employee GetEmployeeById(string Id)
        {
            return _db.Employee.Where(e => e.EmployeeId == Id).FirstOrDefault(); ;
        }

        public Employee PutEmployee(Employee employee)
        {
            _db.Employee.Update(employee);
            _db.SaveChanges();
            return _db.Employee.Where(e => e.EmployeeId == employee.EmployeeId).FirstOrDefault();
        }

        public List<Employee> AddEmployee(Employee employee)
        {
            _db.Employee.Add(employee);
            _db.SaveChanges();
            return _db.Employee.ToList();
        }
    }
}

