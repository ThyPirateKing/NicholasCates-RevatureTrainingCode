using System.ComponentModel.DataAnnotations;

namespace migrationDemo.Models
{
    public class Employees
    {
        [Key] //It indicates that the variable EmployeeID is the primary key
        public int EmployeesID { get; set; }
        
        [Required(ErrorMessage = "First Name Is Required")]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
    }
}