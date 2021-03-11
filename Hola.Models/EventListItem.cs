using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hola.Models
{
    public class EventListItem
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public int? LocationId { get; set; }
    }
}
