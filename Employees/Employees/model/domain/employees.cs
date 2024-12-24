using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.model.domain
{
    public class employees
    {
        [Key]
        public int  empid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string hiredate { get; set; }
        public  string salary { get; set;}
        [Required]
        [ForeignKey("jobs")]
        public int  jobid { get; set; }
        public int  managerid { get; set; }

        [Required]
        [ForeignKey("departments")]
        public int  departmentid { get; set; }


        public Departments departments { get; set; }
        public jobs jobs { get; set; }
        


    }
}
