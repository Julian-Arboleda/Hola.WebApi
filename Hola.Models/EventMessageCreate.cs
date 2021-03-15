using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hola.Models
{
    public class EventMessageCreate
    {
        [Required]
        [MaxLength(800, ErrorMessage = "There are too many characters in this field.")]
        public string Content { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
