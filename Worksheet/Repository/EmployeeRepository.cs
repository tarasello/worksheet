using Dapper;
using Worksheet.Components.Pages.Employees;
using Worksheet.Context;
using Worksheet.Contracts;
using Worksheet.Model;

namespace Worksheet.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _context;
        public EmployeeRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var query = "SELECT * FROM Employees";
            using (var connection = _context.CreateConnection())
            {
                var employees = await connection.QueryAsync<Employee>(query);
                return employees.ToList();
            }
        }

        public async Task<Employee?> GetEmployee(int employeeId)
        {
            var query = "SELECT * FROM Employees WHERE Id = " + employeeId;
            using (var connection = _context.CreateConnection())
            {
                var employee = await connection.QuerySingleOrDefaultAsync<Employee>(query);
                return employee;
            }
        }

        public async void SaveEmployee(Employee employee)
        {
            var query = "UPDATE Employees SET FirstName='"+employee.FirstName+"', LastName='"+employee.LastName+"' WHERE Id = " + employee.Id;
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<Employee>(query);     
            }
        }

        public async void AddEmployee(Employee employee)
        {
            var query = "INSERT INTO Employees VALUES ('" + employee.FirstName + "', '" + employee.LastName + "')";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<Employee>(query);
            }
        }

        public async void DeleteEmployee(int employeeId)
        {
            var query = "DELETE FROM Employees WHERE Id = " + employeeId;
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<Employee>(query);
            }
        }

    }
}
