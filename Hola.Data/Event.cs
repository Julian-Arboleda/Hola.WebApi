using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hola.Data
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public bool IsLiked { get; set; }

        public Guid HostId { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? ModifiedDateCreated { get; set; }

        [ForeignKey(nameof(Location))]
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
