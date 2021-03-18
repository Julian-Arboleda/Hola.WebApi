using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hola.Models
{
    public class EventEdit
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Host { get; set; }

        public bool IsLiked { get; set; }
        public DateTimeOffset DateCreated { get; set; }

    }
}
