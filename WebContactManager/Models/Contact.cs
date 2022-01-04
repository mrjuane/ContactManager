using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebContactManager.Models
{
    public class Contact
    {
        [Key, Display(Name ="ID")]
        public int ConstactId { get; set; }

        [Required, Display(Name = "First Name"), MaxLength(50)]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name"), MaxLength(50)]
        public string LastName { get; set; }
       
        [MaxLength(250)]
        public string Address { get; set; }

        [MaxLength(100),DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MaxLength(10), DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        public string Genre { get; set; }
    }
}
