using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactDAL.Model
{
    [Table("ToDo")]
    public partial class ToDo
    {
        [Key,  DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ToDoId { get; set; }
        [Required]
        public int ContactId { get; set; }
         
        [Required, Column("Task" ,TypeName ="nvarchar(150)")]
        public string Task { get; set; }

        [Required, Column("Description", TypeName = "nvarchar(250)")]
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

    }
}
