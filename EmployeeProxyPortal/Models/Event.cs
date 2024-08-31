using System.ComponentModel.DataAnnotations;

namespace EmployeeProxyPortal.Models
{
    public class Event
    {
        [Key]
        public int TaskID { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [StringLength(30)]
        public string TaskName { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [StringLength(15)]
        public string TaskStatus { get; set; }


        //Foreign key naviagtion property
        public int ProjectID { get; set; }
        //Navigation Property: points back to principal entity
        public Project Project { get; set; }
    }
}
