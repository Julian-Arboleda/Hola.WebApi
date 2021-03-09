using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hola.Data
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        public string Name { get; set; }

        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }

        public Guid CreatorId { get; set; }


    }
}
