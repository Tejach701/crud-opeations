using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.model.domain
{
    public class Departments
    {
        [Key]
        public int  departmentid { get; set; }
        public string departmentname { get; set; }

        [Required]
        [ForeignKey("location")]
        public int  locationid { get; set; }

        public location location { get; set; }
    }
}
