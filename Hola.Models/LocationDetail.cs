using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hola.Models
{
   public class LocationDetail
    {
        public int LocationId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public Guid CreatorId { get; set; }
    }
}
