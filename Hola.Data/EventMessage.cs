using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hola.Data
{
    public class EventMessage
    {
        [Key]
        public int EventMessageId { get; set; }

        public Guid CreatorId { get; set; }

        [Required]
        public string Content { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? ModifiedDateCreated { get; set; }

        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string Id { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
