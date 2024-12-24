using System.ComponentModel.DataAnnotations;

namespace Employees.model.domain
{
    public class regions
    {
        [Key]
        public int regionid { get; set; }
        public string regionname { get; set; }
        
    }
}
