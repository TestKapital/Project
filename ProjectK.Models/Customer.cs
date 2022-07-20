using ProjectKapital.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectKapital.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public string Birthday { get; set; }
        public Gender Gender { get; set; }
        [Display(Name = "Category")]
        public int CustomerCategoryId { get; set; }
        public string PhoneNumber { get; set; }
        public int Credit { get; set; }
        public virtual CustomerCategory? CustomerCategory { get; set; }
    }

    public enum Gender
    {
        Male, Female
    }
}
