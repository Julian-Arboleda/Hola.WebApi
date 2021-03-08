﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hola.Data
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Required]
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }

        [ForeignKey("User")]
        public string Id { get; set; }
        public virtual ApplicationUser  User {get;set;} 
        
    }
}
