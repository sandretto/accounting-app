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

        public string Team
        {
            get
            {
                return IsNightShift ? "Первая" : "Вторая";
            }
        }

        public string Shift
        {
            get
            {
                return IsNightShift ? "с 20:00 до 8:00" : "с 8 до 20:00";
            }
        }
    }
}
