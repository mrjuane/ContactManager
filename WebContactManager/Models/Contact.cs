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

        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }
       
        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        [Required]
        public string Genre { get; set; }
    }
}
