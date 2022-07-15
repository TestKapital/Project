using ProjectK.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectKapital.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public string Birthday { get; set; }
        public Gender Gender { get; set; }
        public int CustomerCategoryId { get; set; }
        public string PhoneNumber { get; set; }
        public int Credit { get; set; }
        //public CustomerCategory CustomerCategory { get; set; }

    }

    public enum Gender
    {
        Male, Female
    }
}
