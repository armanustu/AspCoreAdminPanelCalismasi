using System.ComponentModel.DataAnnotations;

namespace BlogApi.EntityLayer
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string? EmployeeName { get; set; }

    }
}
