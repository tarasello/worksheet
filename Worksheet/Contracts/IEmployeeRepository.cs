using System.Runtime.CompilerServices;
using Worksheet.Model;

namespace Worksheet.Contracts
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetEmployees();

        public Task<Employee?> GetEmployee(int employeeId);

        public void SaveEmployee(Employee employee);

        public void AddEmployee(Employee employee);

        public void DeleteEmployee(int employeeId);
    }
}
