using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.model.domain
{
    public class location
    {
        [Required]
        [Key]
        public int locationid { get; set; }
        public string street { get; set; }
        public string pcode { get; set; }
        public string city { get; set; }
        public string stateprovience { get; set; }

        [ForeignKey("countries")]
        public  int  countryid  { get; set; }

        public countries countries { get; set; }


        
    }

   
}
