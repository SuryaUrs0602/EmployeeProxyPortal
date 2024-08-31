using System.ComponentModel.DataAnnotations;

namespace EmployeeProxyPortal.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [StringLength(50)]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        [StringLength(50)]
        public string EmployeeEmail { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [StringLength(10)]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone Number is not valid")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong Input")]
        public string EmployeePhoneNumber { get; set; }


        //Foreign Key Property
        public int DepartmentID { get; set; }
        //Navigation Property: points back to principal entity
        public Department Department { get; set; }



        //Foreign Key Property
        public int JobTitleID { get; set; }
        //Navigation Property: points back to principal entity
        public JobTitle JobTitle { get; set; }



        //Foreign key property
        public int ProjectID { get; set; }
        //Navigation Property: points back to principal entity
        public Project Project { get; set; }
    }
}
