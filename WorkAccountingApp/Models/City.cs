using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkAccountingApp.Models
{
    public class City
    {
        [Required]
        public int Id { get; set; } //лучше использовать Guid
        public string Name { get; set; }

        public virtual ICollection<Department> Departments { get; private set; } =
            new ObservableCollection<Department>();
    }
}
