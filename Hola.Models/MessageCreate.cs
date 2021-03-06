using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hola.Models
{
   public class MessageCreate
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(1000, ErrorMessage = "There are too many characters in this field.")]
        public string Content { get; set; }
        public bool IsLiked { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
