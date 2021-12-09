using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ContactDAL.Model
{
    [Table(name:"Contact")]
    public partial class Contact
    {
        [Key,
         DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConstactId { get; set; }

        [Required, Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Required, Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string Phone { get; set; }

        [Required, Column(TypeName ="nvarchar(10)")]
        public string Genre { get; set; }

        public ICollection<ToDo> ToDos { get; set; }

    }
}
