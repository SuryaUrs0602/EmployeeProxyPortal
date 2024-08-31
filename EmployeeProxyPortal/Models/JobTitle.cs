using System.ComponentModel.DataAnnotations;

namespace EmployeeProxyPortal.Models
{
    public class JobTitle
    {
        [Key]
        public int JobTitleID { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [StringLength(30)]
        public string JobName { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.Currency, ErrorMessage = "Enter correct amount")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Enter a valid amount")]
        public double JobSalary { get; set; }


        //Navigation Property pointing to the dependent entity
        public ICollection<Employee> Employees { get; set; }
    }
}
