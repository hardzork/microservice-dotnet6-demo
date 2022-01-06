using microservicedotnet6.Models;

namespace microservicedotnet6.Repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> AddEmployee(Employee employee);
        Employee GetEmployeeById(string id);
        List<Employee> GetEmployees();
        Employee PutEmployee(Employee employee);
    }
}