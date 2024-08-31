using System.ComponentModel.DataAnnotations;

namespace EmployeeProxyPortal.Models
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [StringLength(30)]
        public string ProjectName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Enter a valid Duration")]
        public int ProjectDuration { get; set; }


        //Navigation Property pointing to the dependent entity
        public ICollection<Event> Tasks { get; set; }


        //navigation property pointing to the depenedent entity
        public ICollection<Employee> Employees { get; set; }
    }
}
