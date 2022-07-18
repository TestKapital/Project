using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectKapital.Models
{
    public class CustomerCategory
    {
        [Key]
        public int Category { get; set; }
        public string CategoryName { get; set; }

    }

}
