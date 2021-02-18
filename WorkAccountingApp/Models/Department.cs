using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkAccountingApp.Models
{
    public class Department
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public int CityId { get; set; }

    }
}
