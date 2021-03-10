using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hola.Models
{
   public class EventCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Host { get; set; }
        [Required]
        public DateTimeOffset DateCreated { get; set;}
        [Required]
        public int LocationId { get; set; }

    }
}
