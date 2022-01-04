using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebContactManager.Models
{
    public class ToDo
    {
        [Key, Display(Name = "ID")]
        public int ToDoId { get; set; }
        
        [Required]
        public int ContactId { get; set; }

        [Required]
        public string Task { get; set; }

        [Required]
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
