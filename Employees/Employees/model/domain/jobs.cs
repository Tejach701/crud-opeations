using System.ComponentModel.DataAnnotations;

namespace Employees.model.domain
{
    public class jobs
    {
        
        [Key]
        public int  jobid { get; set; }
        public string jobtitle { get; set; }
        public string maxsalary { get; set; }
        public string minsalary { get; set; }
    }
}
