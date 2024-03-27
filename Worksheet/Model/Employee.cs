using Worksheet.Contracts;

namespace Worksheet.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool IsDeleted { get; set; }
    }
}
