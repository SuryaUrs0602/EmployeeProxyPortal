using System.ComponentModel.DataAnnotations;

namespace EmployeeProxyPortal.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [StringLength(30)]
        public string DepartmentName { get; set; }


        //Navigation Property pointing to the dependent entity
        public ICollection<Employee> Employees { get; set; }
    }
}
