using System.ComponentModel.DataAnnotations;

namespace WorkAccountingApp.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; } 
        public bool IsNightShift { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
