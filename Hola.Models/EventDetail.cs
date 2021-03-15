﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hola.Models
{
   public class EventDetail
    {
        public int EventId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public Guid HostId { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? ModifiedDateCreated { get; set; }

    }
}
