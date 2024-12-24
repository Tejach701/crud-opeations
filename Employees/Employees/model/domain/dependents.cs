using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.model.domain
{
    public class dependents
    {
        [Key]
        public int dependentid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string relationship { get; set; }
        [Required]
        [ForeignKey("employees")]
        public int empid { get; set; }

        public employees employees{get;set;}
    }
}
