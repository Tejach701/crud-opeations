using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.model.domain
{
    public class countries
    {
        
        [Key]
        public int countryid { get; set; }
        public string countryname { get; set; }

        [Required]
        [ForeignKey("regions")]
        public int   regionid { get; set; }

        public regions regions { get; set; }
    }
}
